using Fluent.Infrastructure.FluentModel;
using System;
using System.Data;
using System.Web.UI.WebControls;
using BankTransaction.Models;
using System.Linq;
using System.Data.Entity.Core;

namespace BankTransaction
{
    public partial class ViewImports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load master data and bind the GridViews
                BindMasterGrid();
            }
        }

        protected void BindMasterGrid()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var dbContext = new BankTransaction.Models.ApplicationDbContext(connectionString))
            {
                try
                {
                    gvMaster.DataSource = dbContext.MasterRecords.ToList();
                    gvMaster.DataBind();
                }
                catch (EntityCommandExecutionException ex)
                {
                    Exception innerException = ex.InnerException;
                    while (innerException != null)
                    {
                        innerException = innerException.InnerException;
                    }
                }
            }
        }

        protected void SelectMasterRecord(object sender, EventArgs e)
        {
            int selectedMasterId = int.Parse(gvMaster.SelectedValue.ToString());

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var dbContext = new BankTransaction.Models.ApplicationDbContext(connectionString))
            {
                var detailRecords = dbContext.DetailRecords.Where(d => d.MasterRecordId == selectedMasterId).ToList();
                gvDetail.DataSource = detailRecords;
                gvDetail.DataBind();
            }
        }

        protected string CalculateTimeBreached(DateTime transactionDate, DateTime effectiveStatusDate)
        {
            TimeSpan timeDifference = effectiveStatusDate - transactionDate;
            return (timeDifference.Days > 7) ? "Yes" : "No";
        }

        // Other helper methods as needed

        // You can also add code to import CSV data and populate the database here
        // Ensure the data import logic is added when the "View Imports" link is clicked
    }

}


    

