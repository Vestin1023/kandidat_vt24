SELECT TOP (100) c.[Id]
      ,c.[CompetenceId]
      ,c.[SourceId]
      ,c.[Source]
      ,c.[Acquired]
      ,c.[Expires]
      ,c.[Lang]
      ,c.[Qualification_Id]
      ,c.[Contractor_Id]
      ,c.[Created]
      ,c.[CreatedBy]
      ,c.[Modified]
      ,c.[ModifiedBy]
  FROM [SiteAccessControl].[Competence] c
  JOIN [SiteAccessControl].[Contractor] ct ON Contractor_Id = ct.Id 
  ORDER BY [Contractor_Id] ASC