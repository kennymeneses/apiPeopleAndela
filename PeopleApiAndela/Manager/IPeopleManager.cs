using PeopleApiAndela.Models;

namespace PeopleApiAndela.Manager
{
    public interface IPeopleManager
    {

        Task<List<People>> GetAllPeople();

        Task<People> GetSpecifiedPeople(int peopleId);
    }
}
