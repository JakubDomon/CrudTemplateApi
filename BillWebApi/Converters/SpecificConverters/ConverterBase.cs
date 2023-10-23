using Gui = BillWebApi.Communication;
using Bl = BusinessLayer.BusinessObjects;

namespace BillWebApi.Converters.SpecificConverters
{
    public abstract class ConverterBase
    {
        public IEnumerable<Gui.Errors.Error>? ConvertErrors(IEnumerable<Bl.Errors.Errors.Error>? blErrors)
        {
            if(blErrors == null)
            {
                yield break;
            }

            foreach(var error in blErrors)
            {
                yield return new Gui.Errors.Error()
                {
                    Message = error.Message,
                };
            }
        }
    }
}
