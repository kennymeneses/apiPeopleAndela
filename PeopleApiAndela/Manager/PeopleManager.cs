using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PeopleApiAndela.DataAccess;
using PeopleApiAndela.Models;

namespace PeopleApiAndela.Manager
{
    public class PeopleManager : IPeopleManager
    {
        private string urlJobProfileApi = "https://andelajobapidemo.azurewebsites.net/api/jobProfiles/";
        private DataContext _context;

        public PeopleManager(DataContext context)
        {
            _context = context;
        }

        public async Task<List<People>> GetAllPeople()
        {           
            try
            {
                var peopleList = await _context.peoples.ToListAsync();

                return peopleList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<People> GetSpecifiedPeople(int peopleId)
        {
            try
            {
                var people = await _context.peoples.FirstOrDefaultAsync(x => x.PersonId == peopleId);

                var externalInformation = await GetExternalInformation(people.JobProfileId);

                people.JobDescription = externalInformation.JobDescription;
                people.JobLocation = externalInformation.JobDescription;
                people.JobTitle = externalInformation.JobTitle;

                return people;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<JobProfileInformation> GetExternalInformation(int id)
        {
            try
            {
                var completeUrl = urlJobProfileApi + id.ToString();
                JobProfileInformation jobProfileInformation;

                using (var client = new HttpClient())
                {
                    var message = await client.GetAsync(completeUrl);

                    if (!message.IsSuccessStatusCode)
                        throw new Exception();

                    var response = await message.Content.ReadAsStringAsync();

                    jobProfileInformation = JsonConvert.DeserializeObject<JobProfileInformation>(response);

                }
                return jobProfileInformation;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
