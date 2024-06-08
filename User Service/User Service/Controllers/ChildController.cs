using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User_Service.DTO;
using User_Service.Models;
using User_Service.Service.Interfaces;

namespace User_Service.Controllers
{
    [Authorize(Roles = "SpeechTherapist")]
    [ApiController]
    [Route("api/[controller]")]
    public class ChildController : ControllerBase
    {
        private readonly IChildService _childService;

        public ChildController(IChildService childService)
        {
            _childService = childService;
        }

        [HttpPost("add")]
        public IActionResult AddChild([FromBody] ChildDTO c)
        {
            // Add child to your data store
            Child child = new Child
            {
                FirstName = c.LastName,
                LastName = c.FirstName,
                Birthdate = c.Birthdate,
                Archived = false

            };
            _childService.Create(child);
            return Ok();
        }

        [HttpPut("modify")]
        public IActionResult ModifyChild([FromBody] ChildDTO c)
        {
            Child modifiedChild = new Child
            {
                FirstName = c.LastName,
                LastName = c.FirstName,
                Birthdate = c.Birthdate,
                Archived = false

            };
            _childService.ModifyChild(modifiedChild);
            return Ok();
        }

        [HttpPost("archive/{childId}")]
        public IActionResult ArchiveChild(int childId)
        {
            _childService.ArchiveChild(childId, true);
            return Ok();
        }

        [HttpGet("view/{childId}")]
        public async Task<IActionResult> ViewChild(int childId)
        {
            Child child = await _childService.GetInformation(childId);

            if(child == null)
            {
                return BadRequest("No child found with this id.");
            }

            return Ok(child);
        }

        [HttpGet("view/all/{speechTherapistID}")]
        public async Task<IActionResult> ViewAllChildren(int speechTherapistID)
        {
            List<Child> children  = await _childService.GetChildren(speechTherapistID);
            
            if(children == null)
            {
                return Ok("No children found.");
            }
            return Ok(children);
        }

    }
}
