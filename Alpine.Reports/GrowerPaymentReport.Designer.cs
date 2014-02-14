namespace Alpine.Reports
{
    partial class GrowerPaymentReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlGrowerPaymentReport = new Telerik.Reporting.SqlDataSource();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.tbGrower = new Telerik.Reporting.TextBox();
            this.tbWeight = new Telerik.Reporting.TextBox();
            this.tbPayment1ActualDate = new Telerik.Reporting.TextBox();
            this.tbPayment1ContractDate = new Telerik.Reporting.TextBox();
            this.tbPayment1Amount = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.tbPayment2ActualDate = new Telerik.Reporting.TextBox();
            this.tbPayment2ContractDate = new Telerik.Reporting.TextBox();
            this.tbPayment2Amount = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.tbPayment3ActualDate = new Telerik.Reporting.TextBox();
            this.tbPayment3ContractDate = new Telerik.Reporting.TextBox();
            this.tbPayment3Amount = new Telerik.Reporting.TextBox();
            this.tbFinalAmount = new Telerik.Reporting.TextBox();
            this.tbTotalOtherAmount = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlGrowerPaymentReport
            // 
            this.sqlGrowerPaymentReport.CommandTimeout = 120;
            this.sqlGrowerPaymentReport.ConnectionString = "Alpine";
            this.sqlGrowerPaymentReport.Name = "sqlGrowerPaymentReport";
            this.sqlGrowerPaymentReport.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@cropyear", System.Data.DbType.AnsiString, "=Parameters.cropyear.Value")});
            this.sqlGrowerPaymentReport.SelectCommand = "dbo.selectGrowerPaymentReportByCropYear";
            this.sqlGrowerPaymentReport.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.39176520705223083D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            this.labelsGroupHeaderSection.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(10.50015926361084D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "GrowerPaymentReport";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(1.0187501907348633D);
            this.reportFooter.Name = "reportFooter";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.tbGrower,
            this.tbWeight,
            this.tbPayment1ActualDate,
            this.tbPayment1ContractDate,
            this.tbPayment1Amount,
            this.tbPayment2ActualDate,
            this.tbPayment2ContractDate,
            this.tbPayment2Amount,
            this.tbPayment3ActualDate,
            this.tbPayment3ContractDate,
            this.tbPayment3Amount,
            this.tbFinalAmount,
            this.tbTotalOtherAmount});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D), Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0998818874359131D), Telerik.Reporting.Drawing.Unit.Inch(0.39164701104164124D));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.textBox1.Style.Color = System.Drawing.Color.White;
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "Calibri";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "Grower";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69992130994796753D), Telerik.Reporting.Drawing.Unit.Inch(0.39172583818435669D));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.textBox2.Style.Color = System.Drawing.Color.White;
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Name = "Calibri";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "Delivered Weight";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.8000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69999980926513672D), Telerik.Reporting.Drawing.Unit.Inch(0.39172583818435669D));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.textBox3.Style.Color = System.Drawing.Color.White;
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Name = "Calibri";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "Payment 1 Actual Date";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.5D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.7000001072883606D), Telerik.Reporting.Drawing.Unit.Inch(0.39172583818435669D));
            this.textBox4.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.textBox4.Style.Color = System.Drawing.Color.White;
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Name = "Calibri";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "Payment 1 Contract Date";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70000046491622925D), Telerik.Reporting.Drawing.Unit.Inch(0.39172583818435669D));
            this.textBox5.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.textBox5.Style.Color = System.Drawing.Color.White;
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.Font.Name = "Calibri";
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "Payment 1 Amount";
            // 
            // tbGrower
            // 
            this.tbGrower.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tbGrower.Name = "tbGrower";
            this.tbGrower.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9998818635940552D), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866D));
            this.tbGrower.Style.Font.Name = "Calibri";
            this.tbGrower.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbGrower.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbGrower.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbGrower.Value = "= Fields.Name";
            // 
            // tbWeight
            // 
            this.tbWeight.Format = "{0:N0}";
            this.tbWeight.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69992130994796753D), Telerik.Reporting.Drawing.Unit.Inch(0.19999994337558746D));
            this.tbWeight.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tbWeight.Style.Font.Name = "Calibri";
            this.tbWeight.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbWeight.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbWeight.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbWeight.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbWeight.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.tbWeight.Value = "= Fields.wght";
            // 
            // tbPayment1ActualDate
            // 
            this.tbPayment1ActualDate.Format = "{0:d}";
            this.tbPayment1ActualDate.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.8000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tbPayment1ActualDate.Name = "tbPayment1ActualDate";
            this.tbPayment1ActualDate.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69999980926513672D), Telerik.Reporting.Drawing.Unit.Inch(0.19999994337558746D));
            this.tbPayment1ActualDate.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tbPayment1ActualDate.Style.Font.Name = "Calibri";
            this.tbPayment1ActualDate.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbPayment1ActualDate.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment1ActualDate.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment1ActualDate.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tbPayment1ActualDate.Value = "= Fields.Payment1TransactionDate";
            // 
            // tbPayment1ContractDate
            // 
            this.tbPayment1ContractDate.Format = "{0:d}";
            this.tbPayment1ContractDate.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.5D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tbPayment1ContractDate.Name = "tbPayment1ContractDate";
            this.tbPayment1ContractDate.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.7000001072883606D), Telerik.Reporting.Drawing.Unit.Inch(0.19999994337558746D));
            this.tbPayment1ContractDate.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tbPayment1ContractDate.Style.Font.Name = "Calibri";
            this.tbPayment1ContractDate.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbPayment1ContractDate.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment1ContractDate.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment1ContractDate.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tbPayment1ContractDate.Value = "= Fields.Payment1ContractDate";
            // 
            // tbPayment1Amount
            // 
            this.tbPayment1Amount.Format = "{0:C2}";
            this.tbPayment1Amount.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.tbPayment1Amount.Name = "tbPayment1Amount";
            this.tbPayment1Amount.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70000046491622925D), Telerik.Reporting.Drawing.Unit.Inch(0.19996052980422974D));
            this.tbPayment1Amount.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tbPayment1Amount.Style.Font.Name = "Calibri";
            this.tbPayment1Amount.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbPayment1Amount.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment1Amount.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment1Amount.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment1Amount.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.tbPayment1Amount.Value = "= Fields.Payment1Amount";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.3000006675720215D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70000046491622925D), Telerik.Reporting.Drawing.Unit.Inch(0.39172583818435669D));
            this.textBox6.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.textBox6.Style.Color = System.Drawing.Color.White;
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Name = "Calibri";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "Payment 2 Amount";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.7000001072883606D), Telerik.Reporting.Drawing.Unit.Inch(0.39172583818435669D));
            this.textBox7.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.textBox7.Style.Color = System.Drawing.Color.White;
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.Font.Name = "Calibri";
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "Payment 2 Contract Date";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.9000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69999980926513672D), Telerik.Reporting.Drawing.Unit.Inch(0.39172583818435669D));
            this.textBox8.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.textBox8.Style.Color = System.Drawing.Color.White;
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.Font.Name = "Calibri";
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.Value = "Payment 2 Actual Date";
            // 
            // tbPayment2ActualDate
            // 
            this.tbPayment2ActualDate.Format = "{0:d}";
            this.tbPayment2ActualDate.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.9000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tbPayment2ActualDate.Name = "tbPayment2ActualDate";
            this.tbPayment2ActualDate.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69999980926513672D), Telerik.Reporting.Drawing.Unit.Inch(0.19999994337558746D));
            this.tbPayment2ActualDate.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tbPayment2ActualDate.Style.Font.Name = "Calibri";
            this.tbPayment2ActualDate.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbPayment2ActualDate.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment2ActualDate.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment2ActualDate.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tbPayment2ActualDate.Value = "= Fields.Payment2TransactionDate";
            // 
            // tbPayment2ContractDate
            // 
            this.tbPayment2ContractDate.Format = "{0:d}";
            this.tbPayment2ContractDate.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tbPayment2ContractDate.Name = "tbPayment2ContractDate";
            this.tbPayment2ContractDate.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70000046491622925D), Telerik.Reporting.Drawing.Unit.Inch(0.19999994337558746D));
            this.tbPayment2ContractDate.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tbPayment2ContractDate.Style.Font.Name = "Calibri";
            this.tbPayment2ContractDate.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbPayment2ContractDate.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment2ContractDate.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment2ContractDate.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tbPayment2ContractDate.Value = "= Fields.Payment2ContractDate";
            // 
            // tbPayment2Amount
            // 
            this.tbPayment2Amount.Format = "{0:C2}";
            this.tbPayment2Amount.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.3000006675720215D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tbPayment2Amount.Name = "tbPayment2Amount";
            this.tbPayment2Amount.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70000046491622925D), Telerik.Reporting.Drawing.Unit.Inch(0.19996052980422974D));
            this.tbPayment2Amount.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tbPayment2Amount.Style.Font.Name = "Calibri";
            this.tbPayment2Amount.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbPayment2Amount.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment2Amount.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment2Amount.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment2Amount.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.tbPayment2Amount.Value = "= Fields.Payment2Amount";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.0041670799255371D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69575470685958862D), Telerik.Reporting.Drawing.Unit.Inch(0.39172583818435669D));
            this.textBox9.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.textBox9.Style.Color = System.Drawing.Color.White;
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.Font.Name = "Calibri";
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "Payment 3 Actual Date";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.7000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.7000001072883606D), Telerik.Reporting.Drawing.Unit.Inch(0.39172583818435669D));
            this.textBox10.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.textBox10.Style.Color = System.Drawing.Color.White;
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.Style.Font.Name = "Calibri";
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.Value = "Payment 3 Contract Date";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.40000057220459D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70000046491622925D), Telerik.Reporting.Drawing.Unit.Inch(0.39172583818435669D));
            this.textBox11.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.textBox11.Style.Color = System.Drawing.Color.White;
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Font.Name = "Calibri";
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.Value = "Payment 3 Amount";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.1000795364379883D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70000046491622925D), Telerik.Reporting.Drawing.Unit.Inch(0.39172583818435669D));
            this.textBox12.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.textBox12.Style.Color = System.Drawing.Color.White;
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.Style.Font.Name = "Calibri";
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.Value = "Final Amount";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.8001594543457031D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70000046491622925D), Telerik.Reporting.Drawing.Unit.Inch(0.39172583818435669D));
            this.textBox13.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            this.textBox13.Style.Color = System.Drawing.Color.White;
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Name = "Calibri";
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "Total Other Payments";
            // 
            // tbPayment3ActualDate
            // 
            this.tbPayment3ActualDate.Format = "{0:d}";
            this.tbPayment3ActualDate.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.9999222755432129D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tbPayment3ActualDate.Name = "tbPayment3ActualDate";
            this.tbPayment3ActualDate.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69999980926513672D), Telerik.Reporting.Drawing.Unit.Inch(0.19999994337558746D));
            this.tbPayment3ActualDate.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tbPayment3ActualDate.Style.Font.Name = "Calibri";
            this.tbPayment3ActualDate.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbPayment3ActualDate.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment3ActualDate.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment3ActualDate.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tbPayment3ActualDate.Value = "= Fields.Payment3TransactionDate";
            // 
            // tbPayment3ContractDate
            // 
            this.tbPayment3ContractDate.Format = "{0:d}";
            this.tbPayment3ContractDate.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.6999993324279785D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tbPayment3ContractDate.Name = "tbPayment3ContractDate";
            this.tbPayment3ContractDate.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70000046491622925D), Telerik.Reporting.Drawing.Unit.Inch(0.19999994337558746D));
            this.tbPayment3ContractDate.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tbPayment3ContractDate.Style.Font.Name = "Calibri";
            this.tbPayment3ContractDate.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbPayment3ContractDate.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment3ContractDate.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment3ContractDate.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tbPayment3ContractDate.Value = "= Fields.Payment3ContractDate";
            // 
            // tbPayment3Amount
            // 
            this.tbPayment3Amount.Format = "{0:C2}";
            this.tbPayment3Amount.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.4000787734985352D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tbPayment3Amount.Name = "tbPayment3Amount";
            this.tbPayment3Amount.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70000046491622925D), Telerik.Reporting.Drawing.Unit.Inch(0.19996052980422974D));
            this.tbPayment3Amount.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tbPayment3Amount.Style.Font.Name = "Calibri";
            this.tbPayment3Amount.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbPayment3Amount.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment3Amount.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment3Amount.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbPayment3Amount.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.tbPayment3Amount.Value = "= Fields.Payment3Amount";
            // 
            // tbFinalAmount
            // 
            this.tbFinalAmount.Format = "{0:C2}";
            this.tbFinalAmount.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.10015869140625D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tbFinalAmount.Name = "tbFinalAmount";
            this.tbFinalAmount.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70000046491622925D), Telerik.Reporting.Drawing.Unit.Inch(0.19996052980422974D));
            this.tbFinalAmount.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tbFinalAmount.Style.Font.Name = "Calibri";
            this.tbFinalAmount.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbFinalAmount.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbFinalAmount.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbFinalAmount.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbFinalAmount.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.tbFinalAmount.Value = "= Fields.FinalAmount";
            // 
            // tbTotalOtherAmount
            // 
            this.tbTotalOtherAmount.Format = "{0:C2}";
            this.tbTotalOtherAmount.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.8002386093139648D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tbTotalOtherAmount.Name = "tbTotalOtherAmount";
            this.tbTotalOtherAmount.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69972199201583862D), Telerik.Reporting.Drawing.Unit.Inch(0.19996052980422974D));
            this.tbTotalOtherAmount.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tbTotalOtherAmount.Style.Font.Name = "Calibri";
            this.tbTotalOtherAmount.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbTotalOtherAmount.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbTotalOtherAmount.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbTotalOtherAmount.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.tbTotalOtherAmount.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.tbTotalOtherAmount.Value = "= Fields.TotalOtherAmount";
            // 
            // GrowerPaymentReport
            // 
            this.DataSource = this.sqlGrowerPaymentReport;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.reportHeader,
            this.reportFooter,
            this.detail});
            this.Name = "GrowerPaymentReport";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.25D), Telerik.Reporting.Drawing.Unit.Inch(0.25D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "cropyear";
            reportParameter1.Text = "cropyear";
            reportParameter1.Value = "2011";
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            styleRule1.Style.Font.Name = "Tahoma";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            styleRule2.Style.Color = System.Drawing.Color.White;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Color = System.Drawing.Color.Black;
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Color = System.Drawing.Color.Black;
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(10.500160217285156D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlGrowerPaymentReport;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox tbGrower;
        private Telerik.Reporting.TextBox tbWeight;
        private Telerik.Reporting.TextBox tbPayment1ActualDate;
        private Telerik.Reporting.TextBox tbPayment1ContractDate;
        private Telerik.Reporting.TextBox tbPayment1Amount;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox tbPayment2ActualDate;
        private Telerik.Reporting.TextBox tbPayment2ContractDate;
        private Telerik.Reporting.TextBox tbPayment2Amount;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox tbPayment3ActualDate;
        private Telerik.Reporting.TextBox tbPayment3ContractDate;
        private Telerik.Reporting.TextBox tbPayment3Amount;
        private Telerik.Reporting.TextBox tbFinalAmount;
        private Telerik.Reporting.TextBox tbTotalOtherAmount;

    }
}