

using API.Dtos;
using Aplicacion.UnitOfWork;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PaisController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper ;
        }

        [HttpGet]
        // [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PaisDto>>> Get11()
        {
            var paises = await  unitOfWork.Paises.GetAllAsync();
            return mapper.Map<List<PaisDto>>(paises);
        }
        

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaisDto>> Get(int id)
        {
            var pais = await unitOfWork.Paises.GetByIdAsync(id);
            if(pais == null)
            {
                return NotFound();
            }
            return this.mapper.Map<PaisDto>(pais);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task <ActionResult<Pais>> Post(PaisDto paisDto)
        {
            var pais = this.mapper.Map<Pais>(paisDto);
            this.unitOfWork.Paises.Add(pais);
            await unitOfWork.SaveAsync();
            if(paisDto == null)
            {
                return BadRequest();
            }
            paisDto.Id = pais.Id;
            return CreatedAtAction(nameof(Post), new {id = paisDto.Id}, paisDto);
        }

       /*  
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaisDto>> Put(int id, [FromBody]PaisDto paisDto)
        {
            if(paisDto == null)
                return NotFound();
            var pais = this.mapper.Map<Pais>(paisDto);
            this.unitOfWork.Paises.Update(pais);
            await this.unitOfWork.SaveAsync();
            return paisDto;
        } */

       /*  
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var pais = await this.unitofwork.Paises.GetByIdAsync(id);
            if(pais == null){
                return NotFound(); 
            }
            this.unitofwork.Paises.Remove(pais);
            await unitofwork.SaveAsync();
            return NoContent();
        } */
    }
}