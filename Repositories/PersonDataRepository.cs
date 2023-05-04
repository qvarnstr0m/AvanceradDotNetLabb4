using AvanceradDotNetLabb4.Data;
using AvanceradDotNetLabb4.DTO;
using AvanceradDotNetLabb4.Models;
using AvanceradDotNetLabb4.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AvanceradDotNetLabb4.Repositories
{
    public class PersonDataRepository : IPersonDataRepository
    {
        private readonly ThisDbContext _thisDbContext;

        public PersonDataRepository(ThisDbContext thisDbContext)
        {
            _thisDbContext = thisDbContext;
        }

        public async Task<int> AddNewInterestToPerson(int interestId, int personId)
        {
            var interest = await _thisDbContext.Interests.FindAsync(interestId);
            var person = await _thisDbContext.Persons.FindAsync(personId);

            if (interest == null || person == null)
            {
                return 0;
            }

            var interestPerson = new InterestPerson
            {
                FkInterest = interest,
                FkPerson = person
            };

            await _thisDbContext.InterestsPersons.AddAsync(interestPerson);
            return await _thisDbContext.SaveChangesAsync();
        }



        public async Task<int> AddNewLink(string url, int fkInterestPersonId)
        {
            var interestPerson = await _thisDbContext.InterestsPersons.FindAsync(fkInterestPersonId);

            if (interestPerson == null || url == null)
            {
                return 0;
            }

            var link = new Link
            {
                Url = url,
                FkInterestPerson = interestPerson
            };

            await _thisDbContext.Links.AddAsync(link);
            return await _thisDbContext.SaveChangesAsync();
        }

        public async Task<List<Person>> GetAllPersons()
        {
            var personList = await _thisDbContext.Persons.ToListAsync();
            return personList;
        }

        public async Task<List<LinkWithInterestPersonId>> GetAllPersonsLinks(int personId)
        {
            var links = await _thisDbContext.Links
                .Where(x => x.FkInterestPerson.FkPerson.Id == personId)
                .Select(x => new LinkWithInterestPersonId
                {
                    Id = x.Id,
                    Url = x.Url,
                    FkInterestPersonId = x.FkInterestPerson.Id
                })
                .ToListAsync();
            return links;
        }


        public async Task<List<Interest>> GetPersonsInterests(int personId)
        {
            var interests = await _thisDbContext.InterestsPersons
                .Where(x => x.FkPerson.Id == personId)
                .Select(x => x.FkInterest)
                .ToListAsync();
            return interests;
        }
    }
}
