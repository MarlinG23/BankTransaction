/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[AccountHolder]
      ,[BranchCode]
      ,[AccountNumber]
      ,[AccountType]
  FROM [BankingApp].[dbo].[MasterRecords]

    --DELETE FROM [dbo].[MasterRecords];