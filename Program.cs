using System;
using System.IO;
using Bogus;
using System.Collections.Generic;

namespace GettingStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a timer to measure the time it takes to generate the data
            var watch = System.Diagnostics.Stopwatch.StartNew();

            int contractorId = 1, competenceId = 1, qualificationId = 1;
            var languages = new List<string> { "EN", "SV", "PL", "ES", "DE" };

            // Generate Contractors
            var contractorFaker = new Faker<Contractor>()
                .RuleFor(c => c.Id, f => contractorId++)
                .RuleFor(c => c.ContractorId, f => Guid.NewGuid())
                .RuleFor(c => c.Source, f => f.Random.Int(0, 5))
                .RuleFor(c => c.SourceId, f => f.Random.Number(100000, 999999).ToString())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.PhotoUrl, f => "Bogus") // $"https://ssgcardissuestaging.blob.core.windows.net/cardphotos/{Guid.NewGuid()}")
                .RuleFor(c => c.Nationality, f => f.PickRandom(new string[] { "SE", "US" }))
                .RuleFor(c => c.BirthDay, f => f.Date.Past(20).OrNull(f, 0.5f)) // 50% chance to be null
                .RuleFor(c => c.ContractorUpdated, f => DateTime.Now);
            var contractors = contractorFaker.Generate(10000); 

            // Generate Competences
            var competenceFaker = new Faker<Competence>()
                .RuleFor(c => c.Id, f => competenceId++)
                .RuleFor(c => c.CompetenceId, f => Guid.NewGuid())
                .RuleFor(c => c.ContractorId, f => f.PickRandom(contractors).Id)
                .RuleFor(c => c.SourceId, f => Guid.NewGuid().ToString())
                .RuleFor(c => c.Source, f => "Ssg")
                .RuleFor(c => c.Acquired, f => f.Date.Past(2))
                .RuleFor(c => c.Expires, f => f.Date.Future(2))
                .RuleFor(c => c.Lang, f => f.PickRandom(languages)) 
                .RuleFor(c => c.Qualification_Id, f => qualificationId++)
                .RuleFor(c => c.Created, f => DateTime.Now)
                .RuleFor(c => c.CreatedBy, f => "Bogus") // f.Internet.UserName()
                .RuleFor(c => c.Modified, (DateTime?)null)
                .RuleFor(c => c.ModifiedBy, (string)null);
            var competences = competenceFaker.Generate(500); 
            watch.Stop();
            

            // Call methods to write to CSV
            WriteContractorsToCsv(contractors, "contractors_Bogus_10000to500.csv");
            WriteCompetencesToCsv(competences, "competences_Bogus_500to10000.csv");
            Console.WriteLine($"Data generation took {watch.ElapsedMilliseconds} ms.");
            Console.WriteLine("Data exported to CSV files.");
        }

        static void WriteContractorsToCsv(List<Contractor> contractors, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Id,ContractorId,Source,SourceId,FirstName,LastName,PhotoUrl,Nationality,BirthDay,ContractorUpdated");
                foreach (var contractor in contractors)
                {
                    var birthDay = contractor.BirthDay.HasValue ? contractor.BirthDay.Value.ToString("yyyyMMdd") : "NULL";
                    writer.WriteLine($"{contractor.Id},{contractor.ContractorId},{contractor.Source},{contractor.SourceId},{contractor.FirstName},{contractor.LastName},{contractor.PhotoUrl},{contractor.Nationality},{birthDay},{contractor.ContractorUpdated:yyyy-MM-dd HH:mm:ss.fffffff}");
                }
            }
        }

        static void WriteCompetencesToCsv(List<Competence> competences, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Id,CompetenceId,SourceId,Source,Acquired,Expires,Lang,Qualification_Id,Contractor_Id,Created,CreatedBy,Modified,ModifiedBy");
                foreach (var competence in competences)
                {
                    var modifiedDate = competence.Modified.HasValue ? competence.Modified.Value.ToString("yyyy-MM-dd HH:mm:ss.fffffff") : "NULL";
                    writer.WriteLine($"{competence.Id},{competence.CompetenceId},{competence.SourceId},{competence.Source},{competence.Acquired:yyyy-MM-dd HH:mm:ss.fffffff},{competence.Expires:yyyy-MM-dd HH:mm:ss.fffffff},{competence.Lang},{competence.Qualification_Id},{competence.ContractorId},{competence.Created:yyyy-MM-dd HH:mm:ss.fffffff},{competence.CreatedBy},{modifiedDate},{competence.ModifiedBy ?? "NULL"}");
                }
            }
        }
    }

    public class Contractor
    {
        public int Id { get; set; }
        public Guid ContractorId { get; set; }
        public int Source { get; set; }
        public string SourceId { get; set; }
        public string Nationality { get; set; }
        public DateTime? BirthDay { get; set; }
        public string PhotoUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ContractorUpdated { get; set; }
    }

    public class Competence
    {
        public int Id { get; set; }
        public Guid CompetenceId { get; set; }
        public int ContractorId { get; set; }
        public string SourceId { get; set; }
        public string Source { get; set; }
        public DateTime Acquired { get; set; }
        public DateTime Expires { get; set; }
        public string Lang { get; set; }
        public int Qualification_Id { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}