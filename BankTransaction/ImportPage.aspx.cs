using System;
using System.Configuration; // Add this namespace for ConfigurationManager
using System.IO;
using System.Linq;
using System.Web;
using BankTransaction.Models; // Make sure to import your DbContext namespace

namespace BankTransaction
{
    public partial class ImportPage : System.Web.UI.Page
    {
        // This method gets the connection string from the web.config file
        protected string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Now you can use the connection string in your code
            string connectionString = GetConnectionString();

            // Handle the file upload asynchronously
            if (Request.Files.Count > 0)
            {
                // Process the uploaded file here
                HttpPostedFile file = Request.Files[0];
                System.Threading.Thread.Sleep(10000);
                // Check if the file exists
                if (file != null && file.ContentLength > 0)
                {
                    try
                    {
                        // Read the CSV data from the uploaded file
                        using (var reader = new StreamReader(file.InputStream))
                        {
                            // Skip the header row if necessary
                            reader.ReadLine();

                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(',');

                                // Insert data into the MasterRecords table
                                var masterRecord = new MasterRecord
                                {
                                    AccountHolder = values[0],       // Replace with your column indices
                                    BranchCode = values[1],
                                    AccountNumber = values[2],
                                    AccountType = values[3]
                                };

                                using (var dbContext = new ApplicationDbContext(connectionString))
                                {
                                    dbContext.MasterRecords.Add(masterRecord);
                                    dbContext.SaveChanges();
                                }

                                // Insert data into the DetailRecords table
                                var detailRecord = new DetailRecord
                                {
                                    MasterRecordId = masterRecord.Id, // Assuming Id is an identity column
                                    TransactionDate = DateTime.Parse(values[4]), // Replace with your column indices
                                    Amount = decimal.Parse(values[5]),
                                    Status = values[6],
                                    EffectiveStatusDate = DateTime.Parse(values[7])
                                };

                                using (var dbContext = new ApplicationDbContext(connectionString))
                                {
                                    dbContext.DetailRecords.Add(detailRecord);
                                    dbContext.SaveChanges();
                                }
                            }
                        }

                        // You can handle the uploaded file and perform any necessary operations here
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions here
                    }
                }
            }
        }
    }
}
