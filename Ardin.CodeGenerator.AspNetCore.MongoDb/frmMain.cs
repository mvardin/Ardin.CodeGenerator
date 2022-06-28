using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ardin.CodeGenerator.AspNetCore.MongoDb
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cbService.Checked)
                GenerateService();
            if (cbController.Checked)
                GenerateController();
            MessageBox.Show("Done");
        }
        private void txtRootPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                txtRootPath.Text = folder.SelectedPath;
            }
        }

        private void GenerateController()
        {
            string templatePath = Application.StartupPath + "\\ControllerTemplate.txt";
            string template = File.ReadAllText(templatePath);
            template = template.Replace("@ArdinNamespace", txtNamespace.Text);
            template = template.Replace("@ArdinModelName", txtCollectionName.Text.Remove(0, 1));
            template = template.Replace("@ArdinModel", txtCollectionName.Text);
            string path = Path.Combine(txtRootPath.Text + "\\Controllers", txtCollectionName.Text.Remove(0, 1) + "Controller.cs");
            File.WriteAllText(path, template);
        }
        private void GenerateService()
        {
            string templatePath = Application.StartupPath + "\\ServiceTemplate.txt";
            string template = File.ReadAllText(templatePath);
            template = template.Replace("@ArdinNamespace", txtNamespace.Text);
            template = template.Replace("@ArdinModel", txtCollectionName.Text);
            string path = Path.Combine(txtRootPath.Text + "\\Service", txtCollectionName.Text.Remove(0, 1) + "Service.cs");
            File.WriteAllText(path, template);
        }
    }
}
