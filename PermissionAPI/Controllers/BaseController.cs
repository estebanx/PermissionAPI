using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FluentValidation;
using Permission.Models.Entities;
using Permission.Services.Dtos;
using Permission.Services.Services;

namespace PermissionAPI.Controllers
{
    public interface IBaseController
    {
        Type TypeDto { get; set; }
        IMapper Mapper { get; set; }
        IValidatorFactory ValidationFactory { get; set; }
        UnprocessableEntityObjectResult UnprocessableEntity(object error);
        string TypeName { get; set; }
    }

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BaseController<TEntity, TEntityDto> : ControllerBase, IBaseController
            where TEntity : class, IAudit
            where TEntityDto : class, IAuditDto
    {

        public IMapper Mapper { get; set; }
        public Type TypeDto { get; set; }
        public string TypeName { get; set; }
        public IValidatorFactory ValidationFactory { get; set; }
        protected readonly IBaseService<TEntity, TEntityDto> _baseService;

        public BaseController(IBaseService<TEntity, TEntityDto> baseService, IValidatorFactory validationFactory, IMapper mapper)
        {
            _baseService = baseService;
            ValidationFactory = validationFactory;
            TypeDto = typeof(List<TEntityDto>);
            TypeName = typeof(TEntity).Name;
            Mapper = mapper;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            var data = _baseService.GetAll();
            return Ok(data.ToList());
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            return Ok(_baseService.GetById(id));
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] TEntityDto entity)
        {
            var createdEntity = _baseService.Create(entity);
            return Ok(createdEntity);
        }

        [HttpPut]
        public virtual IActionResult Put([FromBody] TEntityDto entity)
        {
            _baseService.Update(entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            _baseService.Delete(id);
            return Ok();
        }
    }
}

