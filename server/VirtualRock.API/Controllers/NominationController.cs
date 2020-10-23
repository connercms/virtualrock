using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using VirtualRock.API.Resources;
using VirtualRock.Core.Services;
using VirtualRock.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualRock.API.Controllers
{
    [Route("api/[controller]")]
    public class NominationController : Controller
    {
        private readonly INominationService _nominationService;
        private readonly IMapper _mapper;

        public NominationController(INominationService nominationService, IMapper mapper)
        {
            _nominationService = nominationService;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NominationResource>>> Get()
        {
            var nominations = await _nominationService.GetAllWithUser();

            var nominationResources = _mapper.Map<IEnumerable<NominationResource>>(nominations);

            return Ok(nominationResources);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NominationResource>> Get(int id)
        {
            var nomination = await _nominationService.GetNominationById(id);

            var nominationResource = _mapper.Map<NominationResource>(nomination);

            return Ok(nominationResource);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<NominationResource>> Post([FromBody] SaveNominationResource saveNominationResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nominationToCreate = _mapper.Map<SaveNominationResource, Nomination>(saveNominationResource);

            var newNomination = await _nominationService.CreateNomination(nominationToCreate);

            var nomination = await _nominationService.GetNominationById(newNomination.Id);

            var nominationResource = _mapper.Map<Nomination, NominationResource>(nomination);

            return Ok(nominationResource);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<NominationResource>> Put(int id, [FromBody] SaveNominationResource saveNominationResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nominationToBeUpdated = await _nominationService.GetNominationById(id);

            if (nominationToBeUpdated == null)
                return NotFound();

            var nomination = _mapper.Map<SaveNominationResource, Nomination>(saveNominationResource);

            await _nominationService.UpdateNomination(nominationToBeUpdated, nomination);

            var updatedNomination = await _nominationService.GetNominationById(id);

            var updatedNominationResource = _mapper.Map<Nomination, SaveNominationResource>(updatedNomination);

            return Ok(updatedNominationResource);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var nomination = await _nominationService.GetNominationById(id);

            if (nomination == null)
                return NotFound();

            await _nominationService.DeleteNomination(nomination);

            return NoContent();
        }
    }
}
