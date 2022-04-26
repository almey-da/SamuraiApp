using AutoMapper;
using Data.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamuraiApp.DTO.Sword;

namespace SamuraiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISamurai _samurais;

        public SamuraisController(IMapper mapper,ISamurai samurai)
        {
            _mapper = mapper;
            _samurais = samurai;

        }
        [HttpGet]
        public async Task<IEnumerable<ViewSamuraiDTO>> Get()
        {
            var results = await _samurais.GetAll();
            var output = _mapper.Map<IEnumerable<ViewSamuraiDTO>>(results);
            return output;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewSamuraiDTO>> GetById(int id)     //tanpa automapper <Samurai>
        {
            var result = await _samurais.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<ViewSamuraiDTO>(result));         //tidak pake IEnumerable karena satu obj saja 
        }

        [HttpGet("getByName/{name}")]
        public async Task<ActionResult<ViewSamuraiDTO>> GetByName(string name)     
        {
            var result = await _samurais.GetByName(name);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<ViewSamuraiDTO>>(result));         
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateSamuraiDTO createSamuraiDTO)         //automapping
        {
            try
            {

                var newSamurai = _mapper.Map<Samurai>(createSamuraiDTO);
                var result = await _samurais.Insert(newSamurai);
                var samuraiDto = _mapper.Map<ViewSamuraiDTO>(result);

                return CreatedAtAction("GetById", new { id = result.Id }, samuraiDto);  //automapper, kembaliannya code 201

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CreateSamuraiDTO createSamuraiDTO)
        {
            try
            {
                var updateSamurai = _mapper.Map<Samurai>(createSamuraiDTO);
                var result = await _samurais.Update(id, updateSamurai);     
                var samuraiDTO = _mapper.Map<ViewSamuraiDTO>(result);
                return Ok(samuraiDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SamuraisController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _samurais.Delete(id);
                return Ok($"record {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
