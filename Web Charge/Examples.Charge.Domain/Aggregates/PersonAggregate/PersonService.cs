using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<string> CreatePersonPhone(PersonPhone personPhone)
        {
            return _personRepository.CreatePersonPhone(personPhone);
        }

        public async Task<string> DeletePersonPhone(string phoneNumber)
        {
            return await _personRepository.DeletePersonPhone(phoneNumber);
        }

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();

        public async Task<List<PersonPhone>> FindPersonPhone(int businessEntityID) => (await _personRepository.FindPersonPhone(businessEntityID)).ToList();

        public async Task<string> UpdatePersonPhone(string oldPersonPhoneNumber, PersonPhone personPhone)
        {
            return await _personRepository.UpdatePersonPhone(oldPersonPhoneNumber, personPhone);
        }
    }
}
