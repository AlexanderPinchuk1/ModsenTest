using AutoMapper;
using MeetupAPI.Models;
using MeetupAPI.Services.Interfaces;
using MeetupAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace MeetupAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetupController : ControllerBase
    {
        private const string scope = "AdminMeetupApi";

        private readonly IMeetupService _meetupService;
        private readonly IMapper _mapper;


        public MeetupController(IMapper mapper, IMeetupService meetupService)
        {
            _mapper = mapper;
            _meetupService = meetupService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetupViewModel>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<MeetupViewModel>>(await _meetupService.GetAllMeetupsAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeetupViewModel?>> Get(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }

            var meetupViewmodel = _mapper.Map<MeetupViewModel>(await _meetupService.GetMeetupByIdAsync(id));
            if (meetupViewmodel == null)
            {
                return NotFound();
            }

            return Ok(meetupViewmodel);
        }

        [HttpPost]
        [Authorize]
        [RequiredScope(scope)]
        public async Task<ActionResult> Post(MeetupViewModel meetupViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _meetupService.AddMeetupAsync(_mapper.Map<Meetup>(meetupViewModel));

            return Ok(meetupViewModel);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [RequiredScope(scope)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }

            var meetup = await _meetupService.GetMeetupByIdAsync(id);
            if(meetup == null)
            {
                return NotFound();
            }

            await _meetupService.DeleteMeetupAsync(meetup);
            
            return Ok();
        }

        [HttpPut]
        [Authorize]
        [RequiredScope(scope)]
        public async Task<IActionResult> Put(MeetupViewModel meetupViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var meetup = await _meetupService.GetMeetupByIdAsync(meetupViewModel.Id);
            if (meetup == null)
            {
                return NotFound();
            }

            await _meetupService.UpdateMeetupAsync(meetup);

            return Ok();
        }
    }
}