using System;
using System.Web.SessionState;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Web;

namespace ClientChartDesignerSample {
    public static class SessionHelper {
        const string chartLayoutName = "ChartLayout";

        public static void SaveChartLayout(String layoutXml, HttpSessionState session) {
            session[chartLayoutName] = layoutXml;
        }

        public static void SaveChart(WebChartControl chart, HttpSessionState session) {
            SaveChartLayout(chart.SaveToXml(), session);
        }

        public static void LoadChart(WebChartControl chart, HttpSessionState session) {
            if (session[chartLayoutName] != null) {
                String layoutXml = session[chartLayoutName] as String;
                if (layoutXml != null)
                    chart.LoadFromXml(layoutXml);
            }
            else
                InitSeries(chart);
        }

        static void InitSeries(WebChartControl chart) {
            using (NWindEntities dbContext = new NWindEntities()) {
                SideBySideBarSeriesView view = new SideBySideBarSeriesView();
                view.FillStyle.FillMode = FillMode.Solid;
                Series series = new Series() {
                    Name = "Product Price",
                    View = view
                };
                series.ArgumentDataMember = "ProductName";
                series.ValueDataMembers.AddRange(new string[] { "UnitPrice" });
                chart.Series.Add(series);
            }
        }
    }
}