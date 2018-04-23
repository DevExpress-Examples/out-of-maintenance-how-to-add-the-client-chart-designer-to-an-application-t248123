<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="ClientChartDesignerSample.MainPage" %>

<%@ Register Assembly="DevExpress.XtraCharts.v15.1.Web, Version=15.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.XtraCharts.v15.1, Version=15.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Client Chart Designer Sample
    </title>
    <style>
        .center {
            margin: 0 auto
        }
        .top-margin {
            margin-top: 16px
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
        <div>
            <dx:ASPxCallbackPanel
                ID="ASPxCallbackPanel1"
                runat="server"
                Width="960px"
                CssClass="center">
                <PanelCollection>
                    <dx:PanelContent>
                        <dxchartsui:WebChartControl
                            ID="chart"
                            runat="server"
                            CrosshairEnabled="True"
                            Height="540px"
                            Width="960"
                            PaletteName="Office 2013"
                            SelectionMode="Single">
                            <titles>
                                <cc1:ChartTitle Text="Product Prices Comparison" />
                            </titles> 
                        </dxchartsui:WebChartControl>
                        <asp:Button
                            ID="btnRunDesigner"
                            runat="server"
                            CssClass="top-margin"
                            Text="Run Client Chart Designer"
                            OnClick="btnRunDesigner_Click"/>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>
        </div>
    </form>
</body>
</html>