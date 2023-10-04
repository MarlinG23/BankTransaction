using BankTransaction.Models;
using BankTransaction;
using CsvHelper.Configuration;
using CsvHelper;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

public class CsvImporter
{
    private readonly string _connectionString;

    public CsvImporter(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void ImportCsvData(string csvFilePath)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var records = csv.GetRecords<CsvRecordTypeDB>(); // Define YourCsvRecordType to match your CSV structure

                using (var dbContext = new ApplicationDbContext(_connectionString)) // Pass the connection string to ApplicationDbContext
                {
                    foreach (var record in records)
                    {
                        var masterRecord = new MasterRecord
                        {
                            AccountHolder = record.AccountHolder,
                            BranchCode = record.BranchCode,
                            AccountNumber = record.AccountNumber,
                            AccountType = record.AccountType
                        };

                        dbContext.MasterRecords.Add(masterRecord);

                        var detailRecord = new DetailRecord
                        {
                            MasterRecordId = masterRecord.Id,
                            TransactionDate = record.TransactionDate,
                            Amount = record.Amount,
                            Status = record.Status,
                            EffectiveStatusDate = record.EffectiveStatusDate
                        };

                        dbContext.DetailRecords.Add(detailRecord);
                    }

                    dbContext.SaveChanges(); // Save changes to the database
                }
            }
            conn.Close();
        }
    }
}
