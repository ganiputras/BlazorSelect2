using System.ComponentModel.DataAnnotations;

namespace BlazorSelect2.Data
{
    public class TbPlace
    {
        [StringLength(155)] public string Id { get; set; }
        [StringLength(155)] public string Name { get; set; }
        public PlaceCategory Category { get; set; }
        [StringLength(500)] public string Types { get; set; }
        public virtual string[] TypesArray { get; set; }

        public string CountryId { get; set; }
        public string CityId { get; set; }

        //public virtual string[] TypesArray => Types?.Split(',').Select(str => str.Trim()).ToArray();
    }
}
