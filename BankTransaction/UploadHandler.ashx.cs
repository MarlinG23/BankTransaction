using System;
using System.Data;
using System.IO;
using System.Threading; // Add this namespace for Thread.Sleep
using System.Web;
using System.Data.SqlClient;
using BankTransaction.Models;
using System.Globalization;

namespace BankTransaction
{
    public class UploadHandler : IHttpHandler
    {
        private readonly string _connectionString; // Add a private field to store the connection string

        public UploadHandler()
        {
            // Initialize the connection string in the constructor
            _connectionString = @"Data Source=localhost;Initial Catalog=BankingApp; Integrated Security=true";
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            try
            {
                if (context.Request.Files.Count > 0)
                {
                    HttpPostedFile file = context.Request.Files[0];

                    // Validate and handle the uploaded file here (e.g., save it or process its content)

                    // Use the connection string in your code here
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();

                        // Parse the uploaded CSV file and insert data into the database tables
                        using (StreamReader reader = new StreamReader(file.InputStream))
                        {
                            // Skip the header row if necessary
                            reader.ReadLine();

                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(',');

                                // Insert data into the MasterRecords table
                                string insertMasterRecordSql = "INSERT INTO MasterRecords (AccountHolder, BranchCode, AccountNumber, AccountType) VALUES (@AccountHolder, @BranchCode, @AccountNumber, @AccountType); SELECT SCOPE_IDENTITY()";
                                using (SqlCommand cmd = new SqlCommand(insertMasterRecordSql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@AccountHolder", values[1]);
                                    cmd.Parameters.AddWithValue("@BranchCode", values[2]);
                                    cmd.Parameters.AddWithValue("@AccountNumber", values[3]);
                                    cmd.Parameters.AddWithValue("@AccountType", values[4]);

                                    // Execute the insert and retrieve the newly inserted ID
                                    int masterRecordId = Convert.ToInt32(cmd.ExecuteScalar());

                                    // Simulate a 10-second delay (for testing cancellation)
                                    //Thread.Sleep(10000);

                                    // Now that you have the master record ID, use it when inserting detail records
                                    string insertDetailRecordSql = "INSERT INTO DetailRecords (MasterRecordId, TransactionDate, Amount, Status, EffectiveStatusDate) VALUES (@MasterRecordId, @TransactionDate, @Amount, @Status, @EffectiveStatusDate)";
                                    cmd.CommandText = insertDetailRecordSql;
                                    cmd.Parameters.Clear(); // Clear parameters from the previous command
                                    cmd.Parameters.AddWithValue("@MasterRecordId", masterRecordId);
                                    cmd.Parameters.AddWithValue("@TransactionDate", values[5]);
                                    cmd.Parameters.AddWithValue("@Amount", values[6]);
                                    cmd.Parameters.AddWithValue("@Status", values[7]);
                                    cmd.Parameters.AddWithValue("@EffectiveStatusDate", values[8]);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        conn.Close();
                    }

                    context.Response.Write("File uploaded successfully! Data inserted into the database.");
                }
                else
                {
                    context.Response.Write("No file uploaded.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions by sending a detailed error message to the client
                context.Response.StatusCode = 500; // Internal Server Error
                context.Response.Write("Error: " + ex.Message);
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
