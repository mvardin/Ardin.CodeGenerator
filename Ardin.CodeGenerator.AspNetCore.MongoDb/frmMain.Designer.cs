
namespace Ardin.CodeGenerator.AspNetCore.MongoDb
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
            this.txtCollectionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRootPath = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.cbService = new System.Windows.Forms.CheckBox();
            this.cbController = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Collection Name:";
            // 
            // txtCollectionName
            // 
            this.txtCollectionName.Location = new System.Drawing.Point(117, 35);
            this.txtCollectionName.Name = "txtCollectionName";
            this.txtCollectionName.Size = new System.Drawing.Size(513, 23);
            this.txtCollectionName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Root:";
            // 
            // txtRootPath
            // 
            this.txtRootPath.Location = new System.Drawing.Point(117, 118);
            this.txtRootPath.Name = "txtRootPath";
            this.txtRootPath.Size = new System.Drawing.Size(513, 23);
            this.txtRootPath.TabIndex = 1;
            this.txtRootPath.Click += new System.EventHandler(this.txtRootPath_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(117, 155);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(513, 53);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Namespace:";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(117, 64);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(513, 23);
            this.txtNamespace.TabIndex = 1;
            // 
            // cbService
            // 
            this.cbService.AutoSize = true;
            this.cbService.Location = new System.Drawing.Point(117, 93);
            this.cbService.Name = "cbService";
            this.cbService.Size = new System.Drawing.Size(113, 19);
            this.cbService.TabIndex = 3;
            this.cbService.Text = "Generate Service";
            this.cbService.UseVisualStyleBackColor = true;
            // 
            // cbController
            // 
            this.cbController.AutoSize = true;
            this.cbController.Location = new System.Drawing.Point(236, 93);
            this.cbController.Name = "cbController";
            this.cbController.Size = new System.Drawing.Size(129, 19);
            this.cbController.TabIndex = 3;
            this.cbController.Text = "Generate Controller";
            this.cbController.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Prefix:";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(117, 6);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(513, 23);
            this.txtPrefix.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 220);
            this.Controls.Add(this.cbController);
            this.Controls.Add(this.cbService);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtRootPath);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.txtCollectionName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Ardin.CodeGenerator.AspNetCore.MongoDb";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCollectionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRootPath;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.CheckBox cbService;
        private System.Windows.Forms.CheckBox cbController;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrefix;
    }
}

