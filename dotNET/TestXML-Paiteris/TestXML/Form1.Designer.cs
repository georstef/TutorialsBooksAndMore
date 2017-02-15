namespace TestXML
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRule2ColorScale formatConditionRule2ColorScale1 = new DevExpress.XtraEditors.FormatConditionRule2ColorScale();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar1 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule5 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleIconSet formatConditionRuleIconSet1 = new DevExpress.XtraEditors.FormatConditionRuleIconSet();
            DevExpress.XtraEditors.FormatConditionIconSet formatConditionIconSet1 = new DevExpress.XtraEditors.FormatConditionIconSet();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon1 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon2 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon3 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule6 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleTopBottom formatConditionRuleTopBottom1 = new DevExpress.XtraEditors.FormatConditionRuleTopBottom();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule7 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleAboveBelowAverage formatConditionRuleAboveBelowAverage1 = new DevExpress.XtraEditors.FormatConditionRuleAboveBelowAverage();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule8 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRule3ColorScale formatConditionRule3ColorScale1 = new DevExpress.XtraEditors.FormatConditionRule3ColorScale();
            this.coldiff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnewCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colitem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpercentAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bsTestXML = new System.Windows.Forms.BindingSource(this.components);
            this.View1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colmanufacturer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmodel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnIncrease = new DevExpress.XtraEditors.SimpleButton();
            this.btnDecrease = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTestXML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View1)).BeginInit();
            this.SuspendLayout();
            // 
            // coldiff
            // 
            this.coldiff.FieldName = "diff";
            this.coldiff.Name = "coldiff";
            this.coldiff.Visible = true;
            this.coldiff.VisibleIndex = 6;
            // 
            // colnewCost
            // 
            this.colnewCost.FieldName = "newCost";
            this.colnewCost.Name = "colnewCost";
            this.colnewCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "newCost", "{0:0.##}")});
            this.colnewCost.Visible = true;
            this.colnewCost.VisibleIndex = 5;
            // 
            // colitem
            // 
            this.colitem.FieldName = "item";
            this.colitem.Name = "colitem";
            this.colitem.Visible = true;
            this.colitem.VisibleIndex = 0;
            // 
            // colpercentAdd
            // 
            this.colpercentAdd.FieldName = "percentAdd";
            this.colpercentAdd.Name = "colpercentAdd";
            this.colpercentAdd.Visible = true;
            this.colpercentAdd.VisibleIndex = 4;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bsTestXML;
            this.gridControl1.Location = new System.Drawing.Point(1, 53);
            this.gridControl1.MainView = this.View1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(755, 311);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.View1});
            // 
            // bsTestXML
            // 
            this.bsTestXML.DataSource = typeof(TestXML.Part);
            // 
            // View1
            // 
            this.View1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colitem,
            this.colmanufacturer,
            this.colmodel,
            this.colcost,
            this.colpercentAdd,
            this.colnewCost,
            this.coldiff});
            gridFormatRule1.Column = this.coldiff;
            gridFormatRule1.ColumnApplyTo = this.coldiff;
            gridFormatRule1.Name = "Red";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "[diff] < 0";
            formatConditionRuleValue1.PredefinedName = "Red Text";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.Column = this.coldiff;
            gridFormatRule2.ColumnApplyTo = this.coldiff;
            gridFormatRule2.Name = "Green";
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Green;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Greater;
            formatConditionRuleValue2.Value1 = "0";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule3.Column = this.colnewCost;
            gridFormatRule3.ColumnApplyTo = this.colnewCost;
            gridFormatRule3.Enabled = false;
            gridFormatRule3.Name = "Paiteris";
            formatConditionRule2ColorScale1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            formatConditionRule2ColorScale1.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
            formatConditionRule2ColorScale1.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
            formatConditionRule2ColorScale1.PredefinedName = "Yellow, Orange, Coral";
            gridFormatRule3.Rule = formatConditionRule2ColorScale1;
            gridFormatRule4.Column = this.colnewCost;
            gridFormatRule4.ColumnApplyTo = this.colnewCost;
            gridFormatRule4.Enabled = false;
            gridFormatRule4.Name = "MeMpares";
            formatConditionRuleDataBar1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            formatConditionRuleDataBar1.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleDataBar1.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleDataBar1.PredefinedName = "Mint Gradient";
            gridFormatRule4.Rule = formatConditionRuleDataBar1;
            gridFormatRule5.Column = this.colnewCost;
            gridFormatRule5.ColumnApplyTo = this.colnewCost;
            gridFormatRule5.Enabled = false;
            gridFormatRule5.Name = "FlagsAndStars";
            formatConditionIconSet1.CategoryName = "Symbols";
            formatConditionIconSetIcon1.PredefinedName = "Flags3_1.png";
            formatConditionIconSetIcon1.Value = new decimal(new int[] {
            67,
            0,
            0,
            0});
            formatConditionIconSetIcon1.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon2.PredefinedName = "Flags3_2.png";
            formatConditionIconSetIcon2.Value = new decimal(new int[] {
            33,
            0,
            0,
            0});
            formatConditionIconSetIcon2.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon3.PredefinedName = "Flags3_3.png";
            formatConditionIconSetIcon3.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon1);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon2);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon3);
            formatConditionIconSet1.Name = "Flags3";
            formatConditionIconSet1.ValueType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
            formatConditionRuleIconSet1.IconSet = formatConditionIconSet1;
            gridFormatRule5.Rule = formatConditionRuleIconSet1;
            gridFormatRule6.Column = this.colnewCost;
            gridFormatRule6.ColumnApplyTo = this.colnewCost;
            gridFormatRule6.Enabled = false;
            gridFormatRule6.Name = "WithPlithos";
            formatConditionRuleTopBottom1.PredefinedName = "Yellow Fill, Yellow Text";
            formatConditionRuleTopBottom1.Rank = new decimal(new int[] {
            50,
            0,
            0,
            0});
            formatConditionRuleTopBottom1.RankType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
            formatConditionRuleTopBottom1.TopBottom = DevExpress.XtraEditors.FormatConditionTopBottomType.Bottom;
            gridFormatRule6.Rule = formatConditionRuleTopBottom1;
            gridFormatRule7.Column = this.colnewCost;
            gridFormatRule7.ColumnApplyTo = this.colnewCost;
            gridFormatRule7.Enabled = false;
            gridFormatRule7.Name = "AboveAvg";
            formatConditionRuleAboveBelowAverage1.PredefinedName = "Green Fill, Green Text";
            gridFormatRule7.Rule = formatConditionRuleAboveBelowAverage1;
            gridFormatRule8.Column = this.colnewCost;
            gridFormatRule8.ColumnApplyTo = this.colnewCost;
            gridFormatRule8.Enabled = false;
            gridFormatRule8.Name = "Paiteris2";
            formatConditionRule3ColorScale1.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            formatConditionRule3ColorScale1.MaximumColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            formatConditionRule3ColorScale1.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
            formatConditionRule3ColorScale1.Middle = new decimal(new int[] {
            50,
            0,
            0,
            0});
            formatConditionRule3ColorScale1.MiddleColor = System.Drawing.Color.Red;
            formatConditionRule3ColorScale1.MiddleType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
            formatConditionRule3ColorScale1.MinimumColor = System.Drawing.Color.Aqua;
            formatConditionRule3ColorScale1.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
            gridFormatRule8.Rule = formatConditionRule3ColorScale1;
            this.View1.FormatRules.Add(gridFormatRule1);
            this.View1.FormatRules.Add(gridFormatRule2);
            this.View1.FormatRules.Add(gridFormatRule3);
            this.View1.FormatRules.Add(gridFormatRule4);
            this.View1.FormatRules.Add(gridFormatRule5);
            this.View1.FormatRules.Add(gridFormatRule6);
            this.View1.FormatRules.Add(gridFormatRule7);
            this.View1.FormatRules.Add(gridFormatRule8);
            this.View1.GridControl = this.gridControl1;
            this.View1.Name = "View1";
            this.View1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.View1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.View1.OptionsSelection.EnableAppearanceHideSelection = false;
            this.View1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.View1.OptionsView.ShowFooter = true;
            // 
            // colmanufacturer
            // 
            this.colmanufacturer.FieldName = "manufacturer";
            this.colmanufacturer.Name = "colmanufacturer";
            this.colmanufacturer.Visible = true;
            this.colmanufacturer.VisibleIndex = 1;
            // 
            // colmodel
            // 
            this.colmodel.FieldName = "model";
            this.colmodel.Name = "colmodel";
            this.colmodel.Visible = true;
            this.colmodel.VisibleIndex = 2;
            // 
            // colcost
            // 
            this.colcost.FieldName = "cost";
            this.colcost.Name = "colcost";
            this.colcost.Visible = true;
            this.colcost.VisibleIndex = 3;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(149, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load XML";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnIncrease
            // 
            this.btnIncrease.Location = new System.Drawing.Point(452, 12);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(149, 23);
            this.btnIncrease.TabIndex = 3;
            this.btnIncrease.Text = "Increase";
            this.btnIncrease.Click += new System.EventHandler(this.btnRaise_Click);
            // 
            // btnDecrease
            // 
            this.btnDecrease.Location = new System.Drawing.Point(607, 12);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(149, 23);
            this.btnDecrease.TabIndex = 4;
            this.btnDecrease.Text = "Decrease";
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 413);
            this.Controls.Add(this.btnDecrease);
            this.Controls.Add(this.btnIncrease);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTestXML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView View1;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private System.Windows.Forms.BindingSource bsTestXML;
        private DevExpress.XtraEditors.SimpleButton btnIncrease;
        private DevExpress.XtraGrid.Columns.GridColumn colitem;
        private DevExpress.XtraGrid.Columns.GridColumn colmanufacturer;
        private DevExpress.XtraGrid.Columns.GridColumn colmodel;
        private DevExpress.XtraGrid.Columns.GridColumn colcost;
        private DevExpress.XtraGrid.Columns.GridColumn colpercentAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colnewCost;
        private DevExpress.XtraGrid.Columns.GridColumn coldiff;
        private DevExpress.XtraEditors.SimpleButton btnDecrease;
    }
}

