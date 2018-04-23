Imports DevExpress.Web
Imports DevExpress.XtraCharts.Web

Public Class ChartDesignerPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            Dim chart As New WebChartControl()
            chart.Width = New Unit(400, UnitType.Pixel)
            chart.Height = New Unit(225, UnitType.Pixel)
            chart.DataSource = New List(Of Product)()
            SessionHelper.LoadChart(chart, Session)
            Me.chartDesigner.OpenChart(chart)
        End If
    End Sub

    Protected Sub chartDesigner_SaveChartLayout(sender As Object, e As DevExpress.XtraCharts.Web.Designer.SaveChartLayoutEventArgs) Handles chartDesigner.SaveChartLayout
        SessionHelper.SaveChartLayout(e.ChartLayoutXml, Session)
        ASPxWebControl.RedirectOnCallback("~/MainPage.aspx")
    End Sub
End Class