
namespace Ardin.CodeGenerator.AspNetCore
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cbTables = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetTables = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModelPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Namespace: ";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(134, 21);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(463, 23);
            this.txtNamespace.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Prefix:";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(134, 61);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(117, 23);
            this.txtPrefix.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Connection String:";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(134, 106);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(463, 23);
            this.txtConnectionString.TabIndex = 2;
            this.txtConnectionString.Text = "data source=.;initial catalog=database;user id=userid;password=password;MultipleA" +
    "ctiveResultSets=True";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(226, 257);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(205, 50);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cbTables
            // 
            this.cbTables.FormattingEnabled = true;
            this.cbTables.Location = new System.Drawing.Point(134, 174);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(463, 23);
            this.cbTables.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Select Tables:";
            // 
            // btnGetTables
            // 
            this.btnGetTables.Location = new System.Drawing.Point(134, 135);
            this.btnGetTables.Name = "btnGetTables";
            this.btnGetTables.Size = new System.Drawing.Size(463, 26);
            this.btnGetTables.TabIndex = 3;
            this.btnGetTables.Text = "Get tables";
            this.btnGetTables.UseVisualStyleBackColor = true;
            this.btnGetTables.Click += new System.EventHandler(this.btnGetTables_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Model Path:";
            // 
            // txtModelPath
            // 
            this.txtModelPath.Location = new System.Drawing.Point(134, 218);
            this.txtModelPath.Name = "txtModelPath";
            this.txtModelPath.Size = new System.Drawing.Size(463, 23);
            this.txtModelPath.TabIndex = 5;
            this.txtModelPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtModelPath_MouseClick);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(645, 319);
            this.Controls.Add(this.cbTables);
            this.Controls.Add(this.btnGetTables);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtModelPath);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Ardin Code Generator for Asp.net Core";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ComboBox cbTables;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetTables;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModelPath;
    }
}

