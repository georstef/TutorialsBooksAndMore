namespace ParsingXML_HTML
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
            DevExpress.XtraCharts.TextAnnotation textAnnotation1 = new DevExpress.XtraCharts.TextAnnotation();
            DevExpress.XtraCharts.ChartAnchorPoint chartAnchorPoint1 = new DevExpress.XtraCharts.ChartAnchorPoint();
            DevExpress.XtraCharts.FreePosition freePosition1 = new DevExpress.XtraCharts.FreePosition();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.RangeAreaSeriesView rangeAreaSeriesView1 = new DevExpress.XtraCharts.RangeAreaSeriesView();
            this.edtProduct1 = new System.Windows.Forms.TextBox();
            this.edtPrice1 = new System.Windows.Forms.TextBox();
            this.edtLowestPrice1 = new System.Windows.Forms.TextBox();
            this.edtDiff1 = new System.Windows.Forms.TextBox();
            this.edtPercentDiff1 = new System.Windows.Forms.TextBox();
            this.edtPercentDiff2 = new System.Windows.Forms.TextBox();
            this.edtDiff2 = new System.Windows.Forms.TextBox();
            this.edtLowestPrice2 = new System.Windows.Forms.TextBox();
            this.edtPrice2 = new System.Windows.Forms.TextBox();
            this.edtProduct2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnParse1 = new System.Windows.Forms.Button();
            this.btnParse2 = new System.Windows.Forms.Button();
            this.edtResult = new System.Windows.Forms.ListBox();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(textAnnotation1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(rangeAreaSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // edtProduct1
            // 
            this.edtProduct1.Location = new System.Drawing.Point(43, 54);
            this.edtProduct1.Name = "edtProduct1";
            this.edtProduct1.Size = new System.Drawing.Size(344, 20);
            this.edtProduct1.TabIndex = 0;
            this.edtProduct1.Text = "Όρθια Σκούπα AEG AG 5020 ULTRA POWER";
            // 
            // edtPrice1
            // 
            this.edtPrice1.AcceptsReturn = true;
            this.edtPrice1.Location = new System.Drawing.Point(394, 54);
            this.edtPrice1.Name = "edtPrice1";
            this.edtPrice1.Size = new System.Drawing.Size(62, 20);
            this.edtPrice1.TabIndex = 1;
            this.edtPrice1.Text = "177.00";
            this.edtPrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtLowestPrice1
            // 
            this.edtLowestPrice1.Location = new System.Drawing.Point(462, 54);
            this.edtLowestPrice1.Name = "edtLowestPrice1";
            this.edtLowestPrice1.Size = new System.Drawing.Size(62, 20);
            this.edtLowestPrice1.TabIndex = 2;
            this.edtLowestPrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtDiff1
            // 
            this.edtDiff1.Location = new System.Drawing.Point(530, 54);
            this.edtDiff1.Name = "edtDiff1";
            this.edtDiff1.Size = new System.Drawing.Size(62, 20);
            this.edtDiff1.TabIndex = 3;
            this.edtDiff1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPercentDiff1
            // 
            this.edtPercentDiff1.Location = new System.Drawing.Point(598, 54);
            this.edtPercentDiff1.Name = "edtPercentDiff1";
            this.edtPercentDiff1.Size = new System.Drawing.Size(62, 20);
            this.edtPercentDiff1.TabIndex = 4;
            this.edtPercentDiff1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPercentDiff2
            // 
            this.edtPercentDiff2.Location = new System.Drawing.Point(598, 80);
            this.edtPercentDiff2.Name = "edtPercentDiff2";
            this.edtPercentDiff2.Size = new System.Drawing.Size(62, 20);
            this.edtPercentDiff2.TabIndex = 9;
            this.edtPercentDiff2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtDiff2
            // 
            this.edtDiff2.Location = new System.Drawing.Point(530, 80);
            this.edtDiff2.Name = "edtDiff2";
            this.edtDiff2.Size = new System.Drawing.Size(62, 20);
            this.edtDiff2.TabIndex = 8;
            this.edtDiff2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtLowestPrice2
            // 
            this.edtLowestPrice2.Location = new System.Drawing.Point(462, 80);
            this.edtLowestPrice2.Name = "edtLowestPrice2";
            this.edtLowestPrice2.Size = new System.Drawing.Size(62, 20);
            this.edtLowestPrice2.TabIndex = 7;
            this.edtLowestPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPrice2
            // 
            this.edtPrice2.AcceptsReturn = true;
            this.edtPrice2.Location = new System.Drawing.Point(394, 80);
            this.edtPrice2.Name = "edtPrice2";
            this.edtPrice2.Size = new System.Drawing.Size(62, 20);
            this.edtPrice2.TabIndex = 6;
            this.edtPrice2.Text = "35.00";
            this.edtPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtProduct2
            // 
            this.edtProduct2.Location = new System.Drawing.Point(43, 80);
            this.edtProduct2.Name = "edtProduct2";
            this.edtProduct2.Size = new System.Drawing.Size(344, 20);
            this.edtProduct2.TabIndex = 5;
            this.edtProduct2.Text = "PHILIPS HD 7462 ΜΑΥΡΗ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "LowestPrice";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Diff";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(595, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "PercentDiff";
            // 
            // btnParse1
            // 
            this.btnParse1.Location = new System.Drawing.Point(666, 51);
            this.btnParse1.Name = "btnParse1";
            this.btnParse1.Size = new System.Drawing.Size(75, 23);
            this.btnParse1.TabIndex = 16;
            this.btnParse1.Text = "Parse 1";
            this.btnParse1.UseVisualStyleBackColor = true;
            this.btnParse1.Click += new System.EventHandler(this.btnParse1_Click);
            // 
            // btnParse2
            // 
            this.btnParse2.Location = new System.Drawing.Point(666, 80);
            this.btnParse2.Name = "btnParse2";
            this.btnParse2.Size = new System.Drawing.Size(75, 23);
            this.btnParse2.TabIndex = 17;
            this.btnParse2.Text = "Parse 2";
            this.btnParse2.UseVisualStyleBackColor = true;
            this.btnParse2.Click += new System.EventHandler(this.btnParse2_Click);
            // 
            // edtResult
            // 
            this.edtResult.FormattingEnabled = true;
            this.edtResult.Location = new System.Drawing.Point(43, 119);
            this.edtResult.Name = "edtResult";
            this.edtResult.Size = new System.Drawing.Size(493, 264);
            this.edtResult.TabIndex = 19;
            // 
            // chartControl1
            // 
            textAnnotation1.AnchorPoint = chartAnchorPoint1;
            textAnnotation1.Name = "Annotation 1";
            textAnnotation1.ShapePosition = freePosition1;
            textAnnotation1.Visible = false;
            this.chartControl1.AnnotationRepository.AddRange(new DevExpress.XtraCharts.Annotation[] {
            textAnnotation1});
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartControl1.Location = new System.Drawing.Point(545, 161);
            this.chartControl1.Name = "chartControl1";
            series1.Name = "#1";
            series1.View = lineSeriesView1;
            series2.Name = "Series 2";
            series2.View = lineSeriesView2;
            series3.Name = "Range";
            rangeAreaSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(205)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            rangeAreaSeriesView1.Transparency = ((byte)(200));
            series3.View = rangeAreaSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3};
            this.chartControl1.Size = new System.Drawing.Size(300, 200);
            this.chartControl1.TabIndex = 20;
            this.chartControl1.Click += new System.EventHandler(this.chartControl1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 468);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.edtResult);
            this.Controls.Add(this.btnParse2);
            this.Controls.Add(this.btnParse1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtPercentDiff2);
            this.Controls.Add(this.edtDiff2);
            this.Controls.Add(this.edtLowestPrice2);
            this.Controls.Add(this.edtPrice2);
            this.Controls.Add(this.edtProduct2);
            this.Controls.Add(this.edtPercentDiff1);
            this.Controls.Add(this.edtDiff1);
            this.Controls.Add(this.edtLowestPrice1);
            this.Controls.Add(this.edtPrice1);
            this.Controls.Add(this.edtProduct1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(textAnnotation1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(rangeAreaSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtProduct1;
        private System.Windows.Forms.TextBox edtPrice1;
        private System.Windows.Forms.TextBox edtLowestPrice1;
        private System.Windows.Forms.TextBox edtDiff1;
        private System.Windows.Forms.TextBox edtPercentDiff1;
        private System.Windows.Forms.TextBox edtPercentDiff2;
        private System.Windows.Forms.TextBox edtDiff2;
        private System.Windows.Forms.TextBox edtLowestPrice2;
        private System.Windows.Forms.TextBox edtPrice2;
        private System.Windows.Forms.TextBox edtProduct2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnParse1;
        private System.Windows.Forms.Button btnParse2;
        private System.Windows.Forms.ListBox edtResult;
        private DevExpress.XtraCharts.ChartControl chartControl1;
    }
}

