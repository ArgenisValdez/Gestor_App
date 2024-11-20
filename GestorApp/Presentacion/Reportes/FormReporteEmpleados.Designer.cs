namespace GestorApp.Presentacion.Reportes
{
    partial class FormReporteEmpleados
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet = new GestorApp.Presentacion.Reportes.DataSet();
            this.dataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sPLISTAREMPLEADOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_LISTAR_EMPLEADOSTableAdapter = new GestorApp.Presentacion.Reportes.DataSetTableAdapters.SP_LISTAR_EMPLEADOSTableAdapter();
            this.textFiltrar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPLISTAREMPLEADOSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sPLISTAREMPLEADOSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GestorApp.Presentacion.Reportes.ReporteEmpleados.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(963, 515);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetBindingSource
            // 
            this.dataSetBindingSource.DataSource = this.dataSet;
            this.dataSetBindingSource.Position = 0;
            // 
            // sPLISTAREMPLEADOSBindingSource
            // 
            this.sPLISTAREMPLEADOSBindingSource.DataMember = "SP_LISTAR_EMPLEADOS";
            this.sPLISTAREMPLEADOSBindingSource.DataSource = this.dataSet;
            // 
            // sP_LISTAR_EMPLEADOSTableAdapter
            // 
            this.sP_LISTAR_EMPLEADOSTableAdapter.ClearBeforeFill = true;
            // 
            // textFiltrar
            // 
            this.textFiltrar.Location = new System.Drawing.Point(12, 40);
            this.textFiltrar.Name = "textFiltrar";
            this.textFiltrar.Size = new System.Drawing.Size(100, 20);
            this.textFiltrar.TabIndex = 1;
            this.textFiltrar.Visible = false;
            // 
            // FormReporteEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 516);
            this.Controls.Add(this.textFiltrar);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReporteEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Empleados";
            this.Load += new System.EventHandler(this.FormReporteEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPLISTAREMPLEADOSBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sPLISTAREMPLEADOSBindingSource;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource dataSetBindingSource;
        private DataSetTableAdapters.SP_LISTAR_EMPLEADOSTableAdapter sP_LISTAR_EMPLEADOSTableAdapter;
        internal System.Windows.Forms.TextBox textFiltrar;
    }
}