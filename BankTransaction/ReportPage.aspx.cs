using System;
using System.Data;
using System.Web.UI.WebControls;

namespace BankTransaction
{
    public partial class ReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSummaryReport();
            }
        }

        protected void BindSummaryReport()
        {
            // Here, you need to fetch the summary data from your database.
            // You can use LINQ or any other data access method.

            var summaryData = GetSummaryData(); // Implement this method to retrieve data.

            gvSummaryReport.DataSource = summaryData;
            gvSummaryReport.DataBind();
        }

        private DataTable GetSummaryData()
        {
            // Simulated data for demonstration purposes.
            var dt = new DataTable();
            dt.Columns.Add("BranchCode");
            dt.Columns.Add("AccountType");
            dt.Columns.Add("Status");
            dt.Columns.Add("TotalCount", typeof(int));
            dt.Columns.Add("TotalAmount", typeof(decimal));

            // Add some sample data.
            dt.Rows.Add("12345", "Savings", "Successful", 4, 1000.45);
            dt.Rows.Add("12345", "Cheque", "Disputed", 12, 12321.18);
            dt.Rows.Add("54321", "Savings", "Failed", 1, 100);

            return dt;
        }
    }
}
