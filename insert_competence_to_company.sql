INSERT INTO [SiteAccessControl].[Competence] (
    [CompetenceId],
    [SourceId],
    [Source],
    [Acquired],
    [Expires],
    [Lang],
    [Qualification_Id],
    [Contractor_Id],
    [Created],
    [CreatedBy],
    [Modified],
    [ModifiedBy]
)
SELECT 
    [CompetenceId],
    comp.[SourceId],
    comp.[Source],
    TRY_CONVERT(datetime2, [Acquired], 121),
    TRY_CONVERT(datetime2, [Expires], 121),
    [Lang],
    [Qualification_Id],
    ctemp.Id,
    TRY_CONVERT(datetime2, [Created], 121),
    [CreatedBy],
    TRY_CONVERT(datetime2, [Modified], 121),
    [ModifiedBy]
FROM 
    [dbo].[competence_HMAdata] comp
inner join [dbo].[contractor_HMAdata] cont on cont.Contractor_Id=comp.Contractor_Id 
inner join [SiteAccessControl].Contractor ctemp on ctemp.ContractorId=cont.ContractorId
--where CompetenceId = '42b2c59b-eda3-4393-ad91-68002beaa287'