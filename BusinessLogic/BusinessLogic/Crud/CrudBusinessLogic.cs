using BusinessLayer.BusinessObjects.BusinessObjects;
using BusinessLayer.BusinessObjects.Errors.Errors;
using Am = BusinessLayer.Converters.AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositiories;
using AutoMapper;
using BusinessLayer.Validators.SpecificValidators.Crud;
using BusinessLayer.Helpers.MapperObjectFiller;
using BusinessLayer.BusinessObjects.Communication.API;

namespace BusinessLayer.BusinessLogic.Crud
{
    internal class CrudBusinessLogic<Item, Entity> : BusinessLogicBase, ICrudBusinessLogic<Item>
        where Item : BusinessModelBase
        where Entity : EntityBase
    {
        private IRepository<Entity> Repository { get; }
        private ICrudValidator<Item> Validator { get; }
        private IMapper Mapper { get; }
        private IMapperObjectFiller<Item> ObjectFiller { get; }

        public CrudBusinessLogic(IRepository<Entity> repository, ICrudValidator<Item> validator, IMapperObjectFiller<Item> objectFiller) : base()
        {
            Repository = repository;
            Validator = validator;
            Mapper = Am.AutoMapper.Mapper;
            ObjectFiller = objectFiller;
        }

        public ErrorableResponse<IEnumerable<Item>> Query(Item item)
        {
            IEnumerable<Error> errors = Validator.ValidateQuery(item);
            if (errors.Any())
            {
                return CreateErrorResponse<IEnumerable<Item>>(errors);
            }

            throw new NotImplementedException();
        }

        public ErrorableResponse<Item> GetById(int id)
        {
            IEnumerable<Error> errors = Validator.ValidateGetById(id);

            if (errors.Any())
            {
                return CreateErrorResponse<Item>(errors);
            }

            try
            {
                Item item = Mapper.Map<Entity, Item>(Repository.GetById(id));

                if (item == null)
                {
                    return CreateSuccessEmptyResponse<Item>();
                }
                else
                {
                    return CreateSuccessResponse<Item>(item);
                }
            }
            catch (Exception ex)
            {
                return CreateErrorResponseException<Item>();
            }
        }

        public ErrorableResponse<IEnumerable<Item>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ErrorableResponse<Item> Add(Item item)
        {
            IEnumerable<Error> errors = Validator.ValidateAdd(item);
            if (errors.Any())
            {
                return CreateErrorResponse<Item>(errors);
            }
            item = ObjectFiller.Fill(item);

            try
            {
                Repository.Add(Mapper.Map<Entity>(item));
                if (Repository.SaveChanges())
                {
                    return CreateSuccessEmptyResponse<Item>();
                }
                else
                {
                    return CreateDatabaseErrorResponse<Item>();
                }
            }
            catch (Exception ex)
            {
                return CreateErrorResponseException<Item>();
            }
        }

        public ErrorableResponse<Item> Update(Item item)
        {
            IEnumerable<Error> errors = Validator.ValidateUpdate(item);
            if (errors.Any())
            {
                return CreateErrorResponse<Item>(errors);
            }
            item = ObjectFiller.Fill(item);

            try
            {
                Repository.Update(Mapper.Map<Entity>(item));
                if (Repository.SaveChanges())
                {
                    return CreateSuccessEmptyResponse<Item>();
                }
                else
                {
                    return CreateDatabaseErrorResponse<Item>();
                }
            }
            catch(Exception ex)
            {
                return CreateErrorResponseException<Item>();
            }
        }

        public ErrorableResponse<Item> Delete(Item item)
        {
            IEnumerable<Error> errors = Validator.ValidateDelete(item);
            if (errors.Any())
            {
                return CreateErrorResponse<Item>(errors);
            }

            try
            {
                Repository.Delete(Mapper.Map<Entity>(item));
                if (Repository.SaveChanges())
                {
                    return CreateSuccessEmptyResponse<Item>();
                }
                else
                {
                    return CreateDatabaseErrorResponse<Item>();
                }
            }
            catch (Exception ex)
            {
                return CreateErrorResponseException<Item>();
            }
        }
    }
}
