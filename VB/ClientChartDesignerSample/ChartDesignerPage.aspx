<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ChartDesignerPage.aspx.vb" Inherits="ClientChartDesignerSample.ChartDesignerPage" %>

<%@ Register assembly="DevExpress.XtraCharts.v15.1.Web, Version=15.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web.Designer" tagprefix="dxchartdesigner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dxchartdesigner:ASPxChartDesigner ID="chartDesigner" runat="server">
        </dxchartdesigner:ASPxChartDesigner>
    
    </div>
    </form>
</body>
</html>
