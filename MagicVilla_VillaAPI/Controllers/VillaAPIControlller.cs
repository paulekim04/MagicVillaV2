using AutoMapper;
using MagicVilla_Data.Entities;
using MagicVilla_Service.Interfaces;
using MagicVilla_VillaAPI.Logging;
using MagicVilla_VillaAPI.Models.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIControlller : ControllerBase
    {
        private IVillaService VillaService { get; }
        private IMapper Mapper { get; }
        private ILogging Logger { get; }

        public VillaAPIControlller(IVillaService villaService, IMapper mapper, ILogging logging)
        {
            VillaService = villaService;
            Mapper = mapper;
            Logger = logging;
        }

        [HttpGet]
        public async Task<IActionResult> GetVillas()
        {
            var villas = await VillaService.GetVillasAsync();

            if (villas == null)
                return NotFound();

            var villasDTO = Mapper.Map<List<VillaDTO>>(villas);

            Logger.Log("Getting all Villas", "");

            return Ok(villasDTO);
        }

        [HttpGet("{id}", Name = "GetVilla")]
        public async Task<IActionResult> GetVilla(int id)
        {
            if (id == 0)
            {
                Logger.Log($"Get Villa Error with Id = {id}", "error");
                return BadRequest();
            }

            var villa = await VillaService.GetVillaAsync(id);

            if (villa == null)
                return NotFound();

            var villaDTO = Mapper.Map<VillaDTO>(villa);

            return Ok(villaDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            var IsExist = VillaService.IsExist(villaDTO.Name);

            if (IsExist)
            {
                ModelState.AddModelError("CustomerError", "Villa already Exists!");
                return BadRequest(ModelState);
            }

            if (villaDTO == null)
                return BadRequest(villaDTO);

            if (villaDTO.Id > 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            Villa villa = Mapper.Map<Villa>(villaDTO);
            villa.CreatedDate = DateTime.UtcNow;

            await VillaService.CreateVillaAsync(villa);

            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            var villa = await VillaService.GetVillaAsync(id);

            if (villa == null)
                return NotFound();

            await VillaService.DeleteVillaAsync(villa);

            return NoContent();
        }

        [HttpPut("{id}", Name = "UpdateVilla")]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null || id != villaDTO.Id)
                return BadRequest();

            var villa = await VillaService.GetVillaAsync(id);

            if (villa == null)
                return NotFound();

            var updatedVilla = Mapper.Map<Villa>(villaDTO);

            await VillaService.UpdateVillaAsync(updatedVilla);

            return NoContent();
        }

        [HttpPatch("{id}", Name = "UpdateVilla")]

        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
                return BadRequest();

            var villa = await VillaService.GetVillaAsync(id);

            if (villa == null)
                return NotFound();

            var updatedVillaDTO = Mapper.Map<VillaDTO>(villa);

            patchDTO.ApplyTo(updatedVillaDTO, ModelState);

            var updatedVilla = Mapper.Map<Villa>(updatedVillaDTO);

            await VillaService.UpdateVillaAsync(updatedVilla);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }
    }
}
