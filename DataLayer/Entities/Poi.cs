using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Poi : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Poi()
        {
        }
    }
}
