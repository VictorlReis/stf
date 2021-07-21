using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonResponse> FindAllAsync();
        Task<PersonPhoneEditResponse> UpdatePersonPhone(PersonPhoneUpdateDto personPhoneEditDTO);
        Task<PersonPhoneResponse> FindPersonPhone(int businessEntityID);
        Task<PersonPhoneEditResponse> DeletePersonPhone(string phoneNumber);
        Task<PersonPhoneEditResponse> CreatePersonPhone(PersonPhoneDto personPhoneDto);
    }
}