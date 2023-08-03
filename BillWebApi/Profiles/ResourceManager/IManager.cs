namespace BillWebApi.Profiles.ResourceManager
{
    public interface IManager<DboModel, GuiModel>
    {
        ICollection<GuiModel>  MapResource(List<DboModel> DatabaseData);
    }
}
