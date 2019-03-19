using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PainGuestApplication.Model.DTO;
using PainGuestApplication.Model.Repositories;
using PainGuestApplication.Utility;

namespace PainGuestApplication.Controllers
{
    public class HomeController : Controller
    {
        private B2BAccountRepository _b2bAccountRepository;
        public HomeController(B2BAccountRepository b2bAccountRepository)
        {
            _b2bAccountRepository = b2bAccountRepository;
        }
        [HttpGet("api/clients")]
        public IActionResult GetB2BAccounts()
        {
            var response = new DataAccessResult<List<B2BAccountDTO>>() { Success = false, ReturnedObject = null };
            try
            {
                var getClientsResult = _b2bAccountRepository.Get();
                if (!getClientsResult.Success)
                {
                    return BadRequest(response);
                }
                response.ReturnedObject = new List<B2BAccountDTO>();
                getClientsResult.Data.ForEach(item => { response.ReturnedObject.Add(new B2BAccountDTO(item)); });
            }
            catch (Exception ex)
            {
                return BadRequest(response);
            }
            response.Success = true;
            return Ok(response);
        }
    }
}