using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _conteactService;

        public ContactController(IContactService conteactService)
        {
            _conteactService = conteactService;
        }
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            contact.Date = Convert.ToDateTime(DateTime.Now.ToString());
            _conteactService.TInsert(contact);
            return Ok();
        }
    }
}
