using DataLayer;

namespace BusinessLayer.Implementations
{
    public class PoiRepository : Repository
    {
        public PoiRepository(PoiContext poiContext) : base(poiContext)
        {
        }
    }
}
