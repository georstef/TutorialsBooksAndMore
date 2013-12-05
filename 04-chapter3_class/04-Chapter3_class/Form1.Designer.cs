namespace _04_Chapter3_class
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
      this.btnGiveToBob = new System.Windows.Forms.Button();
      this.btnGiveToJoe = new System.Windows.Forms.Button();
      this.edtGiveToBob = new System.Windows.Forms.TextBox();
      this.edtGiveToJoe = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblJoeCash = new System.Windows.Forms.Label();
      this.lblBobCash = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnGiveToBob
      // 
      this.btnGiveToBob.Location = new System.Drawing.Point(23, 105);
      this.btnGiveToBob.Name = "btnGiveToBob";
      this.btnGiveToBob.Size = new System.Drawing.Size(75, 23);
      this.btnGiveToBob.TabIndex = 2;
      this.btnGiveToBob.Text = "Give to Bob";
      this.btnGiveToBob.UseVisualStyleBackColor = true;
      this.btnGiveToBob.Click += new System.EventHandler(this.btnGiveToBob_Click);
      // 
      // btnGiveToJoe
      // 
      this.btnGiveToJoe.Location = new System.Drawing.Point(170, 105);
      this.btnGiveToJoe.Name = "btnGiveToJoe";
      this.btnGiveToJoe.Size = new System.Drawing.Size(75, 23);
      this.btnGiveToJoe.TabIndex = 3;
      this.btnGiveToJoe.Text = "Give to Joe";
      this.btnGiveToJoe.UseVisualStyleBackColor = true;
      this.btnGiveToJoe.Click += new System.EventHandler(this.btnGiveToJoe_Click);
      // 
      // edtGiveToBob
      // 
      this.edtGiveToBob.Location = new System.Drawing.Point(12, 79);
      this.edtGiveToBob.Name = "edtGiveToBob";
      this.edtGiveToBob.Size = new System.Drawing.Size(100, 20);
      this.edtGiveToBob.TabIndex = 0;
      // 
      // edtGiveToJoe
      // 
      this.edtGiveToJoe.Location = new System.Drawing.Point(158, 79);
      this.edtGiveToJoe.Name = "edtGiveToJoe";
      this.edtGiveToJoe.Size = new System.Drawing.Size(100, 20);
      this.edtGiveToJoe.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(52, 38);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(24, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Joe";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(184, 38);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(26, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Bob";
      // 
      // lblJoeCash
      // 
      this.lblJoeCash.AutoSize = true;
      this.lblJoeCash.Location = new System.Drawing.Point(45, 51);
      this.lblJoeCash.Name = "lblJoeCash";
      this.lblJoeCash.Size = new System.Drawing.Size(31, 13);
      this.lblJoeCash.TabIndex = 0;
      this.lblJoeCash.Text = "100$";
      this.lblJoeCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblBobCash
      // 
      this.lblBobCash.AutoSize = true;
      this.lblBobCash.Location = new System.Drawing.Point(184, 51);
      this.lblBobCash.Name = "lblBobCash";
      this.lblBobCash.Size = new System.Drawing.Size(25, 13);
      this.lblBobCash.TabIndex = 7;
      this.lblBobCash.Text = "50$";
      this.lblBobCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 201);
      this.Controls.Add(this.lblBobCash);
      this.Controls.Add(this.lblJoeCash);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.edtGiveToJoe);
      this.Controls.Add(this.edtGiveToBob);
      this.Controls.Add(this.btnGiveToJoe);
      this.Controls.Add(this.btnGiveToBob);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnGiveToBob;
    private System.Windows.Forms.Button btnGiveToJoe;
    private System.Windows.Forms.TextBox edtGiveToBob;
    private System.Windows.Forms.TextBox edtGiveToJoe;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblJoeCash;
    private System.Windows.Forms.Label lblBobCash;
  }
}

