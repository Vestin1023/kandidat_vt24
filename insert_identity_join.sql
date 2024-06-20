INSERT INTO [SiteAccessControl].[Identity] (
    [Contractor_Id],[IdentityType],[Value],[IsDeleted],[DeletedDate],[ActivatedDate]
)
SELECT distinct
     ctemp.Id,[IdentityType],[Value],[IsDeleted],[DeletedDate],[ActivatedDate]
FROM 
    [dbo].[identity_HMAdata] comp
inner join [dbo].[contractor_HMAdata] cont on cont.Contractor_Id=comp.Contractor_Id 
inner join [SiteAccessControl].Contractor ctemp on ctemp.ContractorId=cont.ContractorId

--=(CONCAT('HMA', FORMAT(ctemp.Id,'D6')))