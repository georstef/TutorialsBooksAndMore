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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bsTestXML = new System.Windows.Forms.BindingSource(this.components);
            this.View1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnRaise = new DevExpress.XtraEditors.SimpleButton();
            this.colitem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmanufacturer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmodel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpercentAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnewCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldiff = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTestXML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bsTestXML;
            this.gridControl1.Location = new System.Drawing.Point(1, 53);
            this.gridControl1.MainView = this.View1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(701, 311);
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
            this.View1.GridControl = this.gridControl1;
            this.View1.Name = "View1";
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
            // btnRaise
            // 
            this.btnRaise.Location = new System.Drawing.Point(452, 12);
            this.btnRaise.Name = "btnRaise";
            this.btnRaise.Size = new System.Drawing.Size(149, 23);
            this.btnRaise.TabIndex = 3;
            this.btnRaise.Text = "Raise";
            this.btnRaise.Click += new System.EventHandler(this.btnRaise_Click);
            // 
            // colitem
            // 
            this.colitem.FieldName = "item";
            this.colitem.Name = "colitem";
            this.colitem.Visible = true;
            this.colitem.VisibleIndex = 0;
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
            // colpercentAdd
            // 
            this.colpercentAdd.FieldName = "percentAdd";
            this.colpercentAdd.Name = "colpercentAdd";
            this.colpercentAdd.Visible = true;
            this.colpercentAdd.VisibleIndex = 4;
            // 
            // colnewCost
            // 
            this.colnewCost.FieldName = "newCost";
            this.colnewCost.Name = "colnewCost";
            this.colnewCost.Visible = true;
            this.colnewCost.VisibleIndex = 5;
            // 
            // coldiff
            // 
            this.coldiff.FieldName = "diff";
            this.coldiff.Name = "coldiff";
            this.coldiff.Visible = true;
            this.coldiff.VisibleIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 413);
            this.Controls.Add(this.btnRaise);
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
        private DevExpress.XtraEditors.SimpleButton btnRaise;
        private DevExpress.XtraGrid.Columns.GridColumn colitem;
        private DevExpress.XtraGrid.Columns.GridColumn colmanufacturer;
        private DevExpress.XtraGrid.Columns.GridColumn colmodel;
        private DevExpress.XtraGrid.Columns.GridColumn colcost;
        private DevExpress.XtraGrid.Columns.GridColumn colpercentAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colnewCost;
        private DevExpress.XtraGrid.Columns.GridColumn coldiff;
    }
}

