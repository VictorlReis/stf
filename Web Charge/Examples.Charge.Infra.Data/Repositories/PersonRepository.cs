using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Person>> FindAllAsync() => await Task.Run(() => _context.Person);

        public async Task<IEnumerable<PersonPhone>> FindPersonPhone(int businessEntityID) => await Task.Run(() => _context.PersonPhone);

        public async Task<string> UpdatePersonPhone(string oldPersonPhoneNumber, PersonPhone personPhone)
        {
            var oldPersonPhone = _context.PersonPhone.Where(x => x.PhoneNumber == oldPersonPhoneNumber).FirstOrDefault();
            
            _context.PersonPhone.Remove(personPhone);

            var phoneNumber = _context.Set<PersonPhone>().AddAsync(personPhone).Result.Entity.PhoneNumber;

            if(!(await _context.SaveChangesAsync(true) > 0)) return null;

            return phoneNumber;
        }

        public async Task<string> CreatePersonPhone(PersonPhone personPhone)
        {
            var phoneNumber = _context.Set<PersonPhone>().AddAsync(personPhone).Result.Entity.PhoneNumber;
            
            if (!(await _context.SaveChangesAsync(true) > 0)) return null;

            return phoneNumber;
        }

        public async Task<string> DeletePersonPhone(string phoneNumber)
        {
            var personPhone = _context.PersonPhone.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefault();
            
            var deletedPhoneNumber = _context.PersonPhone.Remove(personPhone).Entity.PhoneNumber;

            if (!(await _context.SaveChangesAsync(true) > 0)) return null;

            return deletedPhoneNumber;
        }

    }
}
