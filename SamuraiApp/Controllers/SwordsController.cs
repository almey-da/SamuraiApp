using AutoMapper;
using Data.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamuraiApp.DTO.Sword;

namespace swordApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwordsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISword _swords;

        public SwordsController(IMapper mapper, ISword sword)
        {
            _mapper = mapper;
            _swords = sword;

        }
        [HttpGet]
        public async Task<IEnumerable<ViewSwordDTO>> Get()
        {
            var results = await _swords.GetAll();
            var output = _mapper.Map<IEnumerable<ViewSwordDTO>>(results);
            return output;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewSwordDTO>> GetById(int id)     //tanpa automapper <sword>
        {
            var result = await _swords.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<ViewSwordDTO>(result));         //tidak pake IEnumerable karena satu obj saja 
        }

        [HttpGet("getByName/{name}")]
        public async Task<ActionResult<ViewSwordDTO>> GetByName(string name)     //tanpa automapper <sword>
        {
            var result = await _swords.GetByName(name);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<ViewSwordDTO>>(result));         
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateSwordDTO createSwordDTO)         //automapping
        {
            try
            {
                var newSword = _mapper.Map<Sword>(createSwordDTO);
                var result = await _swords.Insert(newSword);
                var swordDto = _mapper.Map<ViewSwordDTO>(result);

                return CreatedAtAction("GetById", new { id = result.id }, swordDto);  //automapper, kembaliannya code 201

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CreateSwordDTO createSwordDTO)
        {
            try
            {
                var updateSword = _mapper.Map<Sword>(createSwordDTO);
                var result = await _swords.Update(id, updateSword);
                var swordDTO = _mapper.Map<ViewSwordDTO>(result);
                return Ok(swordDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<swordsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _swords.Delete(id);
                return Ok($"record {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
