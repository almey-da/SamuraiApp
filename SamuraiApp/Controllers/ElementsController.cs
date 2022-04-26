using AutoMapper;
using Data.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamuraiApp.DTO.Element;

namespace ElementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IElement _elements;

        public ElementsController(IMapper mapper, IElement element)
        {
            _mapper = mapper;
            _elements = element;

        }
        [HttpGet]
        public async Task<IEnumerable<ViewElementDTO>> Get()
        {
            var results = await _elements.GetAll();
            var output = _mapper.Map<IEnumerable<ViewElementDTO>>(results);
            return output;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewElementDTO>> GetById(int id)     //tanpa automapper <Element>
        {
            var result = await _elements.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<ViewElementDTO>(result));         //tidak pake IEnumerable karena satu obj saja 
        }

        [HttpGet("getByName/{name}")]
        public async Task<ActionResult<ViewElementDTO>> GetByName(string name)     //tanpa automapper <Element>
        {
            var result = await _elements.GetByName(name);
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<ViewElementDTO>>(result));         //tidak pake IEnumerable karena satu obj saja 
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateElementDTO createElementDTO)         //automapping
        {
            try
            {

                var newElement = _mapper.Map<Element>(createElementDTO);
                var result = await _elements.Insert(newElement);
                var ElementDto = _mapper.Map<ViewElementDTO>(result);

                return CreatedAtAction("GetById", new { id = result.Id }, ElementDto);  //automapper, kembaliannya code 201

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CreateElementDTO createElementDTO)
        {
            try
            {
                var updateElement = _mapper.Map<Element>(createElementDTO);
                var result = await _elements.Update(id, updateElement);
                var ElementDTO = _mapper.Map<ViewElementDTO>(result);
                return Ok(ElementDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ElementsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _elements.Delete(id);
                return Ok($"record {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
