SELECT TOP (100) [Id] AS Contractor_Id
      ,[ContractorId]
      ,[Source]
      ,[SourceId]
      ,[FirstName]
      ,[LastName]
      ,[PhotoUrl]
      ,[Nationality]
      ,[BirthDay]
      ,[ContractorUpdated]
  FROM [SiteAccessControl].[Contractor]
  ORDER BY [Id] ASC
