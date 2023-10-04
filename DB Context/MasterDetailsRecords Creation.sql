-- Create MasterRecords table
CREATE TABLE MasterRecords
(
    Id INT PRIMARY KEY IDENTITY(1,1), -- Primary key with auto-increment
    AccountHolder NVARCHAR(255) NOT NULL,
    BranchCode NVARCHAR(50) NOT NULL,
    AccountNumber NVARCHAR(50) NOT NULL,
    AccountType NVARCHAR(50) NOT NULL
);

-- Create DetailRecords table with a foreign key reference to MasterRecords
CREATE TABLE DetailRecords
(
    Id INT PRIMARY KEY IDENTITY(1,1), -- Primary key with auto-increment
    MasterRecordId INT NOT NULL,
    TransactionDate DATETIME NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    EffectiveStatusDate DATETIME NOT NULL,
    FOREIGN KEY (MasterRecordId) REFERENCES MasterRecords(Id)
);
