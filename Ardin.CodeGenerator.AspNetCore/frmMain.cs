using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ardin.CodeGenerator.AspNetCore
{
    public partial class frmMain : Form
    {
        #region Props
        private string[] standardColumns = new string[] { "InsertUserId", "InsertDateTime", "UpdateUserId", "UpdateDateTime", "Version" };
        #endregion

        #region Ctor
        public frmMain()
        {
            InitializeComponent();
            loadDataFromHistory();
        }
        #endregion

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(txtModelPath.Text, "IBase.cs"), generateIBase());
            File.WriteAllText(Path.Combine(txtModelPath.Text, txtPrefix.Text + "Context.cs"), generateContext());
            File.WriteAllText(Path.Combine(txtModelPath.Text, cbTables.Text + ".cs"), generateEO());
            SaveToHistory();
            MessageBox.Show("Done ;)");
        }
        private void btnGetTables_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(txtConnectionString.Text);
                conn.Open();
                DataTable table = conn.GetSchema("Tables");
                cbTables.Items.Clear();
                foreach (System.Data.DataRow row in table.Rows)
                {
                    foreach (System.Data.DataColumn col in table.Columns)
                    {
                        if (col.ColumnName == "TABLE_NAME")
                        {
                            cbTables.Items.Add(row[col]);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(getExceptionMessage(ex));
            }
        }
        private void loadDataFromHistory()
        {
            txtNamespace.Text = ConfigurationManager.AppSettings["Namespace"];
            txtPrefix.Text = ConfigurationManager.AppSettings["Prefix"];
            txtConnectionString.Text = ConfigurationManager.AppSettings["ConnectionString"];
            txtModelPath.Text = ConfigurationManager.AppSettings["ModelPath"];
        }
        private void SaveToHistory()
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Namespace");
            config.AppSettings.Settings.Add("Namespace", txtNamespace.Text);

            config.AppSettings.Settings.Remove("Prefix");
            config.AppSettings.Settings.Add("Prefix", txtPrefix.Text);

            config.AppSettings.Settings.Remove("ConnectionString");
            config.AppSettings.Settings.Add("ConnectionString", txtConnectionString.Text);

            config.AppSettings.Settings.Remove("ModelPath");
            config.AppSettings.Settings.Add("ModelPath", txtModelPath.Text);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            config.Save(ConfigurationSaveMode.Minimal);
        }
        private string generateEO()
        {
            string path = Application.StartupPath + "\\Pattern\\Models.txt";
            FileInfo fi = new FileInfo(path);
            StreamReader sr = fi.OpenText();
            string retVal = sr.ReadToEnd();
            sr.Dispose();

            string loop = retVal.Remove(0, retVal.IndexOf("<BLOX::Loop::BLOXColumns>") + "<BLOX::Loop::BLOXColumns>".Length);
            loop = loop.Remove(loop.IndexOf("</BLOX::Loop::BLOXColumns>"));

            List<KeyValuePair<string, string>> columns = getColumns(cbTables.Text);
            string columnsManipulates = string.Empty;
            foreach (var column in columns)
            {
                if (isNotStandardColumns(column.Key))
                {
                    if (isPrimaryKeyColumn(column.Key, cbTables.Text))
                    {
                        string annotation = "[System.ComponentModel.DataAnnotations.Key]";
                        columnsManipulates += annotation + "\r\n";
                        columnsManipulates += "[DefaultValue(\"\")]"+ "\r\n";
                        columnsManipulates += (loop.Replace("BLOXColumnName", column.Key).Replace("BLOXColumnType", GetClrType(column.Value)) + " = Guid.Empty;");
                    }
                    else
                    {
                        columnsManipulates += loop.Replace("BLOXColumnName", column.Key).Replace("BLOXColumnType", GetClrType(column.Value));
                    }
                }
            }

            retVal = retVal.Replace("BLOXTableName", cbTables.Text);
            retVal = retVal.Replace("BLOXNameSpace", txtNamespace.Text);
            retVal = retVal.Replace("BLOXPrefix", txtPrefix.Text);
            retVal = retVal.Replace(loop, columnsManipulates);
            retVal = retVal.Replace("<BLOX::Loop::BLOXColumns>", string.Empty);
            retVal = retVal.Replace("</BLOX::Loop::BLOXColumns>", string.Empty);
            return retVal;
        }
        private string generateIBase()
        {
            string path = Application.StartupPath + "\\Pattern\\Ibase.txt";
            FileInfo fi = new FileInfo(path);
            StreamReader sr = fi.OpenText();
            string retVal = sr.ReadToEnd();
            sr.Dispose();

            retVal = retVal.Replace("BLOXNameSpace", txtNamespace.Text);

            return retVal;
        }
        private string generateContext()
        {
            string path = Application.StartupPath + "\\Pattern\\Context.txt";
            FileInfo fi = new FileInfo(path);
            StreamReader sr = fi.OpenText();
            string retVal = sr.ReadToEnd();
            sr.Dispose();

            string loop = retVal.Remove(0, retVal.IndexOf("<BLOX::Loop::TableForContext>") + "<BLOX::Loop::TableForContext>".Length);
            loop = loop.Remove(loop.IndexOf("</BLOX::Loop::TableForContext>"));

            List<string> tables = getTables();
            string tablesManipulates = string.Empty;
            foreach (var table in tables)
                tablesManipulates += loop.Replace("BLOXTableName", table);

            retVal = retVal.Replace("BLOXNameSpace", txtNamespace.Text);
            retVal = retVal.Replace("BLOXPrefix", txtPrefix.Text);
            retVal = retVal.Replace(loop, tablesManipulates);
            retVal = retVal.Replace("<BLOX::Loop::TableForContext>", string.Empty);
            retVal = retVal.Replace("</BLOX::Loop::TableForContext>", string.Empty);
            return retVal;
        }
        private bool isPrimaryKeyColumn(string column, string tableName)
        {
            return column.Equals(tableName + "Id");
        }
        private bool isNotStandardColumns(string column)
        {
            return !standardColumns.Contains(column);
        }
        private List<KeyValuePair<string, string>> getColumns(string tableName)
        {
            List<KeyValuePair<string, string>> columns = new List<KeyValuePair<string, string>>();
            SqlConnection conn = new SqlConnection(txtConnectionString.Text);
            conn.Open();

            String[] columnRestrictions = new String[4];
            DataTable departmentIDSchemaTable = conn.GetSchema("Columns", columnRestrictions);
            var selectedRows = from info in departmentIDSchemaTable.AsEnumerable()
                               select new
                               {
                                   TableCatalog = info["TABLE_CATALOG"],
                                   TableSchema = info["TABLE_SCHEMA"],
                                   TableName = info["TABLE_NAME"],
                                   ColumnName = info["COLUMN_NAME"],
                                   DataType = info["DATA_TYPE"]
                               };
            var columnNames = selectedRows.Where(a => a.TableName.ToString().Equals(cbTables.Text));
            foreach (var row in columnNames)
            {
                columns.Add(new KeyValuePair<string, string>(row.ColumnName.ToString(), row.DataType.ToString()));
            }
            return columns;
        }
        private List<string> getTables()
        {
            List<string> tables = new List<string>();
            SqlConnection conn = new SqlConnection(txtConnectionString.Text);
            conn.Open();
            DataTable table = conn.GetSchema("Tables");
            foreach (System.Data.DataRow row in table.Rows)
            {
                foreach (System.Data.DataColumn col in table.Columns)
                {
                    if (col.ColumnName == "TABLE_NAME")
                    {
                        tables.Add(row[col].ToString());
                        break;
                    }
                }
            }
            return tables;
        }
        public string GetClrType(string sqlType)
        {
            switch (sqlType)
            {
                case "bigint":
                    return "long";

                case "binary":
                case "image":
                case "timestamp":
                case "varbinary":
                    return "byte[]";

                case "bit":
                    return "bool";

                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    return "string";

                case "datetime":
                case "smalldatetime":
                case "date":
                case "time":
                case "datetime2":
                    return "DateTime";

                case "decimal":
                case "money":
                case "smallmoney":
                    return "decimal";

                case "float":
                    return "double";

                case "int":
                    return "int";

                case "real":
                    return "float";

                case "uniqueidentifier":
                    return "Guid";

                case "smallint":
                    return "short";

                case "tinyint":
                    return "byte";

                case "variant":
                case "udt":
                    return "object";

                case "structured":
                    return "DataTable";

                case "datetimeoffset":
                    return "DateTimeOffset";

                case "geography":
                    return "Location";

                default:
                    throw new ArgumentOutOfRangeException("sqlType " + sqlType);
            }
        }
        private string getExceptionMessage(Exception ex)
        {
            string message = ex.Message;
            if (ex.InnerException != null)
            {
                message += "\r\n" + ex.InnerException.Message;
                if (ex.InnerException.InnerException != null)
                {
                    message += "\r\n" + ex.InnerException.InnerException.Message;
                    if (ex.InnerException.InnerException.InnerException != null)
                    {
                        message += "\r\n" + ex.InnerException.InnerException.InnerException.Message;
                    }
                }
            }
            return message;
        }
        private void txtModelPath_MouseClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                txtModelPath.Text = folder.SelectedPath;
            }
        }
    }
}
