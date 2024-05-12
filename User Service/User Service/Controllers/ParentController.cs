using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User_Service.DTO;
using User_Service.Service;
using User_Service.Service.Interfaces;

namespace User_Service.Controllers
{
    [Authorize(Roles = "Therapist")]
    [ApiController]
    [Route("[controller]")]
    public class ParentController : Controller
    {
        private readonly IParentService _parentService;

        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }

        //Create
        [HttpPost("add")]
        public IActionResult AddParent([FromBody] ParentDTO parent, int childID)
        {
            // Add child to your data store
            //  _parentService.Create(parent);
            return Ok();
        }

        //Modify
        [HttpPost("modify")]
        public IActionResult ModifyParent([FromBody] ParentDTO parent, int childID)
        {
            // Add child to your data store
            //  _parentService.Create(parent);
            return Ok();
        }

        //findbyid

        //getall (childid)

        //Remove
    }
}
