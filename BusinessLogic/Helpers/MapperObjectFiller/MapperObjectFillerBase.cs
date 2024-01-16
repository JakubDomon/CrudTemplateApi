using AutoMapper;
using BusinessLayer.BusinessObjects.BusinessObjects;
using Conv = BusinessLayer.Converters;
using DataAccessLayer.Models;
using DataAccessLayer.Repositiories;

namespace BusinessLayer.Helpers.MapperObjectFiller
{
    internal abstract class MapperObjectFillerBase<Item, Entity> : IMapperObjectFiller<Item>
        where Item : IBusinessModel
    {
        protected IMapper Mapper { get; set; }

        public MapperObjectFillerBase()
        {
            Mapper = Conv.AutoMapper.AutoMapper.Mapper;
        }

        public abstract Item Fill(Item item);
    }
}
