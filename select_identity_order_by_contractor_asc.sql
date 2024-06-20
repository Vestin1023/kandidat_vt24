SELECT TOP (100) i.[Id]
      ,i.[Contractor_Id]
      ,i.[IdentityType]
      ,i.[Value]
      ,i.[IsDeleted]
      ,i.[DeletedDate]
      ,i.[ActivatedDate]
  FROM [SiteAccessControl].[Identity] i JOIN SiteAccessControl.Contractor ct on i.Contractor_Id = ct.Id
    ORDER BY [Contractor_Id] ASC 

    