/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000)
		[Id]
      ,[MasterRecordId]
      ,[TransactionDate]
      ,[Amount]
      ,[Status]
      ,[EffectiveStatusDate]
  FROM [BankingApp].[dbo].[DetailRecords]

  --DELETE FROM [dbo].[DetailRecords];