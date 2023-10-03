using Fluent.Infrastructure.FluentModel;
using System;
using System.Data;
using System.Web.UI.WebControls;
using BankTransaction.Models;
using System.Linq;

namespace BankTransaction
{
    public partial class ViewImports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Bind Master Grid during page load
            if (!IsPostBack)
            {
                BindMasterGrid();
            }
        }

        protected void BindMasterGrid()
        {
            // Get the connection string from web.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Specify the full namespace of the ApplicationDbContext class you want to use
            using (var dbContext = new BankTransaction.Models.ApplicationDbContext(connectionString))
            {
                gvMaster.DataSource = dbContext.MasterRecords.ToList();
                gvMaster.DataBind();
            }

        }

        protected void SelectMasterRecord(object sender, EventArgs e)
        {
            int selectedMasterId = int.Parse(gvMaster.SelectedValue.ToString());

            // Get the connection string from web.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var dbContext = new BankTransaction.Models.ApplicationDbContext(connectionString))
            {
                var detailRecords = dbContext.DetailRecords.Where(d => d.MasterRecordId == selectedMasterId).ToList();
                gvDetail.DataSource = detailRecords;
                gvDetail.DataBind();
            }
        }
    }
}
