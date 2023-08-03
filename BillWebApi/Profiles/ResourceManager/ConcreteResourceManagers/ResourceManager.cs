using AutoMapper;

namespace BillWebApi.Profiles.ResourceManager.ConcreteResourceManagers
{
    public class ResourceManager<GuiModel, DboModel> : IManager<DboModel, GuiModel>
    {
        private IMapper _mapper;
        public ResourceManager(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ICollection<GuiModel> MapResource(List<DboModel> DatabaseData)
        {
            if(!DatabaseData.Any())
            {
                throw new ArgumentException();
            }

            try
            {
                ICollection<GuiModel> guiModels = new List<GuiModel>();
                foreach (DboModel model in DatabaseData)
                {
                    guiModels.Add(_mapper.Map<GuiModel>(model));
                }
                return guiModels;
            }catch (AutoMapperMappingException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
