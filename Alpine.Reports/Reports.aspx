<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Alpine.Reports.Reports" %>


<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=7.1.13.802, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <telerik:ReportViewer 
        ID="ReportViewer1"
        Width="1024" 
        Height="650"
        runat="server">
        </telerik:ReportViewer>
    </div>
    </form>
</body>
</html>
