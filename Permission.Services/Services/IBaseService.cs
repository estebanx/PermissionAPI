using System;
using AutoMapper;
using FluentValidation;
using Permission.Models.Entities;
using Permission.Models.Repositories;
using Permission.Services.Dtos;
using Permission.Services.Validators;

namespace Permission.Services.Services
{
    public interface IBaseService<TEntity, TEntityDto> where TEntity : class, IAudit
      where TEntityDto : class, IAuditDto
    {
        TEntityDto GetById(int id);
        IList<TEntityDto> GetAll();
        Task<IEntityValidationResult<TEntityDto>> Create(TEntityDto entity);
        Task<IEntityValidationResult<TEntityDto>> Update(TEntityDto entity);
        void Delete(int id);
    }

    public class BaseService<TEntity, TEntityDto> : IBaseService<TEntity, TEntityDto> where TEntity : class, IAudit
      where TEntityDto : class, IAuditDto
    {
        protected readonly IMapper _mapper;
        protected readonly IRepositoryBase<TEntity> _repository;
        protected readonly IValidator<TEntityDto> _validator;

        public BaseService(IMapper mapper, IValidator<TEntityDto> validator, IRepositoryBase<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public virtual TEntityDto GetById(int id)
        {
            TEntity entity = _repository.GetById(id);

            if (entity is null)
                return null;

            TEntityDto dto = _mapper.Map<TEntityDto>(entity);

            return dto;
        }

        public virtual IList<TEntityDto> GetAll()
        {
            IQueryable<TEntity> list = _repository.GetAll();
            IList<TEntityDto> listDto = _mapper.Map<IList<TEntityDto>>(list);
            return listDto;
        }

        public virtual async Task<IEntityValidationResult<TEntityDto>> Create(TEntityDto entityDto)
        {
            if (_validator.CanValidateInstancesOfType(typeof(TEntityDto)))
            {
                var operation = _validator.Validate(entityDto);
                if (!operation.IsValid)
                    return new EntityValidationResult<TEntityDto>(false, operation.Errors.Select(e => new ValidationFailedModel(e)));
            }

            TEntity entity = _mapper.Map<TEntity>(entityDto);

            _repository.Create(entity);

            entityDto = _mapper.Map<TEntityDto>(entity);

            return new EntityValidationResult<TEntityDto>(true, entityDto);
        }

        public virtual async Task<IEntityValidationResult<TEntityDto>> Update(TEntityDto entityDto)
        {
            if (entityDto.Id is null)
                return null;

            TEntity entity = _repository.GetById(entityDto.Id.Value);

            if (entity is null)
                return null;

            if (_validator.CanValidateInstancesOfType(typeof(TEntityDto)))
            {
                var operation = _validator.Validate(entityDto);
                if (operation.IsValid is false)
                    return new EntityValidationResult<TEntityDto>(false, operation.Errors.Select(e => new ValidationFailedModel(e)));
            }

            _mapper.Map(entityDto, entity);

            _repository.Update(entity);

            entityDto = _mapper.Map(entity, entityDto);

            return new EntityValidationResult<TEntityDto>(true, entityDto);
        }

        public virtual void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}

