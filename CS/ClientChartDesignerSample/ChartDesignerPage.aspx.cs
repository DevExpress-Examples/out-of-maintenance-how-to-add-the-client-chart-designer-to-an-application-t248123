using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.XtraCharts.Web;
using DevExpress.XtraCharts.Web.Designer;

namespace ClientChartDesignerSample {
    public partial class ChartDesignerPage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                WebChartControl chart = new WebChartControl {
                    Width = (Unit)400,
                    Height = (Unit)225,
                    DataSource = new List<Product>()
                };
                SessionHelper.LoadChart(chart, Session);
                this.chartDesigner.OpenChart(chart);
            }
        }

        protected void chartDesigner_SaveChartLayout(object sender, SaveChartLayoutEventArgs e) {
            SessionHelper.SaveChartLayout(e.ChartLayoutXml, Session);
            ASPxWebControl.RedirectOnCallback("~/MainPage.aspx");
        }
    }
}