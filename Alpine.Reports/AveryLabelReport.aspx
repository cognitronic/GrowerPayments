<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AveryLabelReport.aspx.cs" Inherits="Alpine.Reports.AveryLabelReport1" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=7.1.13.802, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span style="font-family:'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', 'DejaVu Sans Condensed', sans-serif; color:aliceblue; text-decoration:none;">
            <a href="http://gp.alpinepacificnut.com/GrowerProfile">Back To Grower Payments System</a>
        </span>
    </div>
    <div>
    <telerik:ReportViewer 
        ID="ReportViewer1"
        Width="1124" 
        Height="800"
        runat="server">
        </telerik:ReportViewer>
    </div>
    </form>
</body>
</html>
