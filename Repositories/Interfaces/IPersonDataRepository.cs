using AvanceradDotNetLabb4.DTO;
using AvanceradDotNetLabb4.Models;

namespace AvanceradDotNetLabb4.Repositories.Interfaces
{
    public interface IPersonDataRepository
    {
        Task<List<Person>> GetAllPersons();
        Task<List<Interest>> GetPersonsInterests(int personId);
        Task<List<LinkWithInterestPersonId>> GetAllPersonsLinks(int personId);
        Task<int> AddNewInterestToPerson(int interestId, int personId);
        Task<int> AddNewLink(string url, int fkInterestPersonId);
    }
}
