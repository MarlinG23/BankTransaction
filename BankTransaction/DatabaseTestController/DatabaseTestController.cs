using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace BankTransaction.Controllers
{
    public class DatabaseTestController : Controller
    {
        public ActionResult TestConnection()
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=BankingApp;Integrated Security=true;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    ViewBag.Message = "Connection succeeded.";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Connection failed: " + ex.Message;
                }
            }

            return View();
        }
    }
}
