-- Create Master table
CREATE TABLE MasterRecords (
    Id INT PRIMARY KEY IDENTITY(1,1),
    AccountHolder NVARCHAR(255),
    BranchCode NVARCHAR(50),
    AccountNumber NVARCHAR(50),
    AccountType NVARCHAR(50)
);

