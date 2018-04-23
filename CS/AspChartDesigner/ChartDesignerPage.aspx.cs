using DevExpress.Web;
using DevExpress.XtraCharts.Web;
using DevExpress.XtraCharts.Web.Designer;
using System;
using System.IO;
using System.Web.SessionState;

namespace AspChartDesigner {
    public partial class ChartDesignerPage : System.Web.UI.Page {
        static WebChartControl LoadChartFromSession(HttpSessionState session) {
            var layoutXML = (string)session["ChartLayout"];
            if (layoutXML == null)
                return null;
            var chart = new WebChartControl();
            using (MemoryStream stream = new MemoryStream()) {
                using (StreamWriter writer = new StreamWriter(stream)) {
                    writer.Write(layoutXML);
                    writer.Flush();
                    stream.Seek(0L, SeekOrigin.Begin);
                    chart.LoadFromStream(stream);
                }
            }
            return chart;
        }

        protected void Page_Load(object sender, EventArgs e) {
            ASPxWebControl.GlobalEmbedRequiredClientLibraries = true;
            Header.Title = "Chart Designer";
            if (!IsPostBack) {
                WebChartControl chart = LoadChartFromSession(Session);
                if (chart == null)
                    Response.Redirect("~/MainPage.aspx");
                this.chartDesigner.OpenChart(chart);
            }
        }

        protected void chartDesigner_SaveChartLayout(object sender, SaveChartLayoutEventArgs e) {
            Session["ChartLayout"] = e.ChartLayout;
            ASPxWebControl.RedirectOnCallback("~/MainPage.aspx");
        }
    }
}