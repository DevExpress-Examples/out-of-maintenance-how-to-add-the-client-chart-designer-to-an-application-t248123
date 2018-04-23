using DevExpress.XtraCharts.Web;
using System;
using System.IO;
using System.Web.SessionState;

namespace AspChartDesigner {
    public partial class MainPage : System.Web.UI.Page {
        void SaveChartToSession(WebChartControl chart, HttpSessionState session) {
            using (Stream stream = new MemoryStream()) {
                using (StreamReader reader = new StreamReader(stream)) {
                    chart.SaveToStream(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    session["ChartLayout"] = reader.ReadToEnd();
                }
            }
            session["ChartWidth"] = chart.Width;
            session["ChartHeight"] = chart.Height;
        }

        void LoadChartFromSession(WebChartControl chart, HttpSessionState session) {
            var xmlLayout = (byte[])session["ChartLayout"];
            using (var stream = new MemoryStream(xmlLayout))
                chart.LoadFromStream(stream);
        }
        
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
                if (Session["ChartLayout"] != null)
                    LoadChartFromSession(chart, Session);
        }

        protected void btnRunDesigner_Click(object sender, EventArgs e) {
            SaveChartToSession(chart, Session);
            Response.Redirect("~/ChartDesignerPage.aspx");
        }
    }
}