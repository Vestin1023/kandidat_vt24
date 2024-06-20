INSERT INTO [SiteAccessControl].[Contractor](
      [ContractorId]
      ,[Source]
      ,[SourceId]
      ,[FirstName]
      ,[LastName]
      ,[PhotoUrl]
      ,[Nationality]
      ,[BirthDay]
      ,[ContractorUpdated]
)
SELECT
      [ContractorId]
      ,[Source]
      ,NEWID()
      ,[FirstName]
      ,[LastName]
      ,[PhotoUrl]
      ,[Nationality]
      ,[BirthDay]
      ,[ContractorUpdated]
  FROM [dbo].[contractor_HMAdata]