-- Create Detail table
CREATE TABLE DetailRecords (
    Id INT PRIMARY KEY IDENTITY(1,1),
    MasterRecordId INT,
    TransactionDate DATETIME,
    Amount DECIMAL(18,2),
    Status NVARCHAR(50),
    EffectiveStatusDate DATETIME
);
