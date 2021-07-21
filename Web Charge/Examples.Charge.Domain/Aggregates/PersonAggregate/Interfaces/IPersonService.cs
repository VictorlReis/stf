using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> FindAllAsync();
        Task<List<PersonPhone>> FindPersonPhone(int businessEntityID);
        Task<string> UpdatePersonPhone(string oldPersonPhone, PersonPhone personPhone);
        Task<string> CreatePersonPhone(PersonPhone personPhone);
        Task<string> DeletePersonPhone(string phoneNumber);
    }
}