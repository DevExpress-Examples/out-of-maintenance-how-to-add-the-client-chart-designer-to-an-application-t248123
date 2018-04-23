Imports DevExpress.Web
Imports DevExpress.XtraCharts.Web
Imports DevExpress.XtraCharts.Web.Designer
Imports System
Imports System.IO
Imports System.Web.SessionState

Namespace AspChartDesigner
    Partial Public Class ChartDesignerPage
        Inherits System.Web.UI.Page

        Private Shared Function LoadChartFromSession(ByVal session As HttpSessionState) As WebChartControl
            Dim layoutXML = DirectCast(session("ChartLayout"), String)
            If layoutXML Is Nothing Then
                Return Nothing
            End If
            Dim chart = New WebChartControl()
            Using stream As New MemoryStream()
                Using writer As New StreamWriter(stream)
                    writer.Write(layoutXML)
                    writer.Flush()
                    stream.Seek(0L, SeekOrigin.Begin)
                    chart.LoadFromStream(stream)
                End Using
            End Using
            Return chart
        End Function

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            ASPxWebControl.GlobalEmbedRequiredClientLibraries = True
            Header.Title = "Chart Designer"
            If Not IsPostBack Then
                Dim chart As WebChartControl = LoadChartFromSession(Session)
                If chart Is Nothing Then
                    Response.Redirect("~/MainPage.aspx")
                End If
                Me.chartDesigner.OpenChart(chart)
            End If
        End Sub

        Protected Sub chartDesigner_SaveChartLayout(ByVal sender As Object, ByVal e As SaveChartLayoutEventArgs)
            Session("ChartLayout") = e.ChartLayout
            ASPxWebControl.RedirectOnCallback("~/MainPage.aspx")
        End Sub
    End Class
End Namespace