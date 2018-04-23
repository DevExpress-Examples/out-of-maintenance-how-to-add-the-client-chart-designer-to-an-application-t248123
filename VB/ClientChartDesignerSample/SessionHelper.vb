Imports DevExpress.XtraCharts.Web
Imports DevExpress.XtraCharts

Public NotInheritable Class SessionHelper
    Const chartLayoutName As String = "ChartLayout"

    Public Shared Sub SaveChartLayout(layoutXml As String, session As HttpSessionState)
        session(chartLayoutName) = layoutXml
    End Sub

    Public Shared Sub SaveChart(chart As WebChartControl, session As HttpSessionState)
        SaveChartLayout(chart.SaveToXml(), session)
    End Sub

    Public Shared Sub LoadChart(chart As WebChartControl, session As HttpSessionState)
        If (session(chartLayoutName) IsNot Nothing) Then
            Dim layoutXml As String = TryCast(session(chartLayoutName), String)
            If (layoutXml IsNot Nothing) Then
                chart.LoadFromXml(layoutXml)
            End If
        Else
            InitSeries(chart)
        End If

    End Sub

    Public Shared Sub InitSeries(chart As WebChartControl)
        Using dbContext As New NWindEntities()
            Dim view As SideBySideBarSeriesView = New SideBySideBarSeriesView()
            view.FillStyle.FillMode = FillMode.Solid
            Dim series As Series = New Series()
            series.Name = "Product Price"
            series.View = view
            series.ArgumentDataMember = "ProductName"
            series.ValueDataMembers.AddRange(New String() {"UnitPrice"})
            chart.Series.Add(Series)
        End Using
    End Sub
End Class
