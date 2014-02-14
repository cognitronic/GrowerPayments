namespace Alpine.Reports
{
    partial class AveryLabelReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.nameDataTextBox = new Telerik.Reporting.TextBox();
            this.addressDataTextBox = new Telerik.Reporting.TextBox();
            this.cityDataTextBox = new Telerik.Reporting.TextBox();
            this.stateDataTextBox = new Telerik.Reporting.TextBox();
            this.zipDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Alpine";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.SelectCommand = "dbo.selectAveryLabelReport";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.nameDataTextBox,
            this.addressDataTextBox,
            this.cityDataTextBox,
            this.stateDataTextBox,
            this.zipDataTextBox,
            this.textBox1});
            this.detail.Name = "detail";
            // 
            // nameDataTextBox
            // 
            this.nameDataTextBox.CanGrow = false;
            this.nameDataTextBox.CanShrink = false;
            this.nameDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.33750000596046448D));
            this.nameDataTextBox.Name = "nameDataTextBox";
            this.nameDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6300919055938721D), Telerik.Reporting.Drawing.Unit.Inch(0.20000006258487701D));
            this.nameDataTextBox.Style.Font.Name = "Calibri";
            this.nameDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.nameDataTextBox.Value = "=Fields.name";
            // 
            // addressDataTextBox
            // 
            this.addressDataTextBox.CanGrow = false;
            this.addressDataTextBox.CanShrink = false;
            this.addressDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.56875008344650269D));
            this.addressDataTextBox.Name = "addressDataTextBox";
            this.addressDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6300525665283203D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.addressDataTextBox.Style.Font.Name = "Calibri";
            this.addressDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.addressDataTextBox.Value = "=Fields.address";
            // 
            // cityDataTextBox
            // 
            this.cityDataTextBox.CanGrow = false;
            this.cityDataTextBox.CanShrink = false;
            this.cityDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.800000011920929D));
            this.cityDataTextBox.Name = "cityDataTextBox";
            this.cityDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1998029947280884D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.cityDataTextBox.Style.Font.Name = "Calibri";
            this.cityDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.cityDataTextBox.Value = "=Fields.city";
            // 
            // stateDataTextBox
            // 
            this.stateDataTextBox.CanGrow = false;
            this.stateDataTextBox.CanShrink = false;
            this.stateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1999212503433228D), Telerik.Reporting.Drawing.Unit.Inch(0.800000011920929D));
            this.stateDataTextBox.Name = "stateDataTextBox";
            this.stateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.20000021159648895D));
            this.stateDataTextBox.Style.Font.Name = "Calibri";
            this.stateDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.stateDataTextBox.Value = "=Fields.state";
            // 
            // zipDataTextBox
            // 
            this.zipDataTextBox.CanGrow = false;
            this.zipDataTextBox.CanShrink = false;
            this.zipDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.7000001668930054D), Telerik.Reporting.Drawing.Unit.Inch(0.800000011920929D));
            this.zipDataTextBox.Name = "zipDataTextBox";
            this.zipDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.72333335876464844D), Telerik.Reporting.Drawing.Unit.Inch(0.20000021159648895D));
            this.zipDataTextBox.Style.Font.Name = "Calibri";
            this.zipDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.zipDataTextBox.Value = "=Fields.zip";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = false;
            this.textBox1.CanShrink = false;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6300919055938721D), Telerik.Reporting.Drawing.Unit.Inch(0.20000006258487701D));
            this.textBox1.Style.Font.Name = "Calibri";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox1.Value = "= Fields.grower";
            // 
            // AveryLabelReport
            // 
            this.DataSource = this.sqlDataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "AveryLabelReport";
            this.PageSettings.ColumnCount = 3;
            this.PageSettings.ColumnSpacing = Telerik.Reporting.Drawing.Unit.Inch(0.11999999731779099D);
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421D), Telerik.Reporting.Drawing.Unit.Inch(0.17960630357265472D), Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.49960631132125854D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(2.630000114440918D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox nameDataTextBox;
        private Telerik.Reporting.TextBox addressDataTextBox;
        private Telerik.Reporting.TextBox cityDataTextBox;
        private Telerik.Reporting.TextBox stateDataTextBox;
        private Telerik.Reporting.TextBox zipDataTextBox;
        private Telerik.Reporting.TextBox textBox1;

    }
}