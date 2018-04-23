using System;
using System.Linq;

namespace ClientChartDesignerSample {
    public partial class MainPage : System.Web.UI.Page {
        void LoadData() {
            using (NWindEntities dbContext = new NWindEntities()) {
                chart.DataSource = (from products
                                        in dbContext.Products
                                    select products).ToList();
            }
        }
        
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                SessionHelper.LoadChart(chart, Session);
                LoadData();
                this.chart.DataBind();
            }  
        }

        protected void btnRunDesigner_Click(object sender, EventArgs e) {
            SessionHelper.SaveChart(chart, Session);
            Response.Redirect("~/ChartDesignerPage.aspx");
        }
    }
}