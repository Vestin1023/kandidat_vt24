SELECT TOP(500)
    Con.Id AS ContractorId,
    Con.ContractorId AS ContractorGUID,
    Con.Source AS ContractorSource,
    Con.SourceId AS ContractorSourceId,
    Con.FirstName,
    Con.LastName,
    Con.PhotoUrl,
    Con.Nationality,
    Con.BirthDay,
    --Con.IsActive,
    Con.ContractorUpdated,
    Comp.Id AS CompetenceId,
    Comp.CompetenceId AS CompetenceGUID,
    Comp.SourceId AS CompetenceSourceId,
    Comp.Source AS CompetenceSource,
    Comp.Acquired,
    Comp.Expires,
    Comp.Lang,
    Comp.Qualification_Id,
    Comp.Contractor_Id,
    Comp.Created,
    Comp.CreatedBy,
    Comp.Modified,
    Comp.ModifiedBy
FROM SiteAccessControl.Contractor AS Con
FULL OUTER JOIN SiteAccessControl.Competence AS Comp ON Con.Id = Comp.Contractor_Id;
