Imports DevExpress.XtraCharts.Web
Imports System
Imports System.IO
Imports System.Web.SessionState

Namespace AspChartDesigner
    Partial Public Class MainPage
        Inherits System.Web.UI.Page

        Private Sub SaveChartToSession(ByVal chart As WebChartControl, ByVal session As HttpSessionState)
            Using stream As Stream = New MemoryStream()
                Using reader As New StreamReader(stream)
                    chart.SaveToStream(stream)
                    stream.Seek(0, SeekOrigin.Begin)
                    session("ChartLayout") = reader.ReadToEnd()
                End Using
            End Using
            session("ChartWidth") = chart.Width
            session("ChartHeight") = chart.Height
        End Sub

        Private Sub LoadChartFromSession(ByVal chart As WebChartControl, ByVal session As HttpSessionState)
            Dim xmlLayout = DirectCast(session("ChartLayout"), Byte())
            Using stream = New MemoryStream(xmlLayout)
                chart.LoadFromStream(stream)
            End Using
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            If Not IsPostBack Then
                If Session("ChartLayout") IsNot Nothing Then
                    LoadChartFromSession(chart, Session)
                End If
            End If
        End Sub

        Protected Sub btnRunDesigner_Click(ByVal sender As Object, ByVal e As EventArgs)
            SaveChartToSession(chart, Session)
            Response.Redirect("~/ChartDesignerPage.aspx")
        End Sub
    End Class
End Namespace