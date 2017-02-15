namespace AlterHelper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.edtFolder = new DevExpress.XtraEditors.ButtonEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.openFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnAlter = new System.Windows.Forms.Button();
            this.edtMemo = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMemo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edtFolder
            // 
            this.edtFolder.EditValue = "E:\\dotNET\\resourceTest\\resourceTest\\Properties";
            this.edtFolder.Location = new System.Drawing.Point(12, 38);
            this.edtFolder.Name = "edtFolder";
            this.edtFolder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtFolder.Size = new System.Drawing.Size(524, 20);
            this.edtFolder.TabIndex = 0;
            this.edtFolder.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Target Application Folder:";
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // btnAlter
            // 
            this.btnAlter.Location = new System.Drawing.Point(15, 76);
            this.btnAlter.Name = "btnAlter";
            this.btnAlter.Size = new System.Drawing.Size(165, 23);
            this.btnAlter.TabIndex = 2;
            this.btnAlter.Text = "Alter Resource";
            this.btnAlter.UseVisualStyleBackColor = true;
            this.btnAlter.Click += new System.EventHandler(this.btnAlter_Click);
            // 
            // edtMemo
            // 
            this.edtMemo.Location = new System.Drawing.Point(12, 106);
            this.edtMemo.Name = "edtMemo";
            this.edtMemo.Size = new System.Drawing.Size(547, 150);
            this.edtMemo.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 268);
            this.Controls.Add(this.edtMemo);
            this.Controls.Add(this.btnAlter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtFolder);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.edtFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMemo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit edtFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog openFolder;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnAlter;
        private DevExpress.XtraEditors.MemoEdit edtMemo;
    }
}

