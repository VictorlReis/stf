using AutoMapper;
using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task<PersonPhoneResponse> FindPersonPhone(int businessEntityID)
        {
            var result = await _personService.FindPersonPhone(businessEntityID);
            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.AddRange(result.Select(p => _mapper.Map<PersonPhoneDto>(p)));

            return response;
        }

        public async Task<PersonPhoneEditResponse> UpdatePersonPhone(PersonPhoneUpdateDto personPhoneUpdateDto)
        {
            if (personPhoneUpdateDto.BusinessEntityID <= 0) return null;

            if (string.IsNullOrEmpty(personPhoneUpdateDto.OldPhoneNumber)) return null;

            if (string.IsNullOrEmpty(personPhoneUpdateDto.PhoneNumber)) return null;

            var personPhoneDto = new PersonPhoneDto(personPhoneUpdateDto.BusinessEntityID, 
                personPhoneUpdateDto.PhoneNumber, 
                personPhoneUpdateDto.PhoneNumberTypeID);

            var phoneNumber = await _personService.UpdatePersonPhone(personPhoneUpdateDto.OldPhoneNumber, _mapper.Map<PersonPhone>(personPhoneDto));

            var response = new PersonPhoneEditResponse
            {
                PhoneNumber = phoneNumber
            };

            return response;
        }
        public async Task<PersonPhoneEditResponse> CreatePersonPhone(PersonPhoneDto personPhoneDto)
        {
            var phoneNumber = await _personService.CreatePersonPhone(_mapper.Map<PersonPhone>(personPhoneDto));
            var response = new PersonPhoneEditResponse
            {
                PhoneNumber = phoneNumber
            };

            return response;
        }

        public async Task<PersonPhoneEditResponse> DeletePersonPhone(string phoneNumber)
        {
            var deletedPhoneNumber = await _personService.DeletePersonPhone(phoneNumber);
            var response = new PersonPhoneEditResponse
            {
                PhoneNumber = deletedPhoneNumber
            };

            return response;
        }
    }
}
