using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonAggregate.Person>> FindAllAsync();
        Task <IEnumerable<PersonPhone>> FindPersonPhone(int personId);
        Task<string> UpdatePersonPhone(string oldPersonPhoneNumber, PersonPhone personPhone);
        Task<string> CreatePersonPhone(PersonPhone personPhone);
        Task<string> DeletePersonPhone(string phoneNumber);
    }
}
