using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IPersonFacade _facade;

        public PersonController(IPersonFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet("Person")]
        public async Task<ActionResult<PersonResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("PersonPhone")]
        public async Task<ActionResult<PersonPhoneResponse>> GetPersonPhone(int businessEntityID) => Response(await _facade.FindPersonPhone(businessEntityID));

        [HttpPut("PersonPhone")]
        public async Task<ActionResult> UpdatePersonPhone([FromBody] PersonPhoneUpdateDto personPhoneUpdateDto) => Response(await _facade.UpdatePersonPhone(personPhoneUpdateDto));

        [HttpPost("PersonPhone")]
        public async Task<ActionResult> CreatePersonPhone([FromBody] PersonPhoneDto personPhoneDto) => Response(await _facade.CreatePersonPhone(personPhoneDto));

        [HttpDelete("PersonPhone/{phoneNumber}")]
        public async Task<ActionResult> DeletePersonPhone(string phoneNumber) => Response(await _facade.DeletePersonPhone(phoneNumber));


    }
}
