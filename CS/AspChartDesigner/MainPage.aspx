<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="AspChartDesigner.MainPage" %>

<%@ Register Assembly="DevExpress.XtraCharts.v15.1.Web, Version=15.1.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>

<%@ Register assembly="DevExpress.XtraCharts.v15.1, Version=15.1.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxchartsui:WebChartControl ID="chart" Width="800px" Height="450px" runat="server" CrosshairEnabled="True" DataSourceID="SqlDataSource1" PaletteName="Office 2013">
            <diagramserializable>
                <cc1:XYDiagram>
                    <axisx visibleinpanesserializable="-1">
                    </axisx>
                    <axisy visibleinpanesserializable="-1">
                    </axisy>
                </cc1:XYDiagram>
            </diagramserializable>
            <seriesserializable>
                <cc1:Series ArgumentDataMember="ProductName" Name="Series 1" ValueDataMembersSerializable="UnitPrice">
                </cc1:Series>
            </seriesserializable>
        </dxchartsui:WebChartControl>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:nwindConnectionString %>" ProviderName="<%$ ConnectionStrings:nwindConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Products]"></asp:SqlDataSource>
        </br>
        <asp:Button ID="btnRunDesigner" runat="server" Text="Run Chart Designer" OnClick="btnRunDesigner_Click" />
    </div>
    </form>
</body>
</html>
