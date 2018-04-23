Public Class MainPage
    Inherits System.Web.UI.Page
    Protected Sub LoadData()
        Using dbContext As New NWindEntities()
            chart.DataSource = (From products
                                In dbContext.Products
                                Select products).ToList()
        End Using
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SessionHelper.LoadChart(chart, Session)
            LoadData()
            Me.chart.DataBind()
        End If
    End Sub

    Protected Sub btnRunDesigner_Click(sender As Object, e As EventArgs) Handles btnRunDesigner.Click
        SessionHelper.SaveChart(chart, Session)
        Response.Redirect("~/ChartDesignerPage.aspx")
    End Sub
End Class