<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="ChartDesignerPage.aspx.vb" Inherits="AspChartDesigner.ChartDesignerPage" %>

<%@ Register Assembly="DevExpress.XtraCharts.v15.1.Web, Version=15.1.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web.Designer" TagPrefix="dxchartdesigner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxchartdesigner:ASPxChartDesigner ID="chartDesigner" runat="server" OnSaveChartLayout="chartDesigner_SaveChartLayout"/>
    </div>
    </form>
</body>
</html>