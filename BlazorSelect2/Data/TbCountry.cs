using System.ComponentModel.DataAnnotations;

namespace BlazorSelect2.Data
{
    public class TbCountry
    {
        public string Id { get; set; }

        [StringLength(155)] public string IsoCountryCode { get; set; }
        [StringLength(155)] public string Name { get; set; }

        public static List<TbCountry> GetAll()
        {
            var list= new List<TbCountry>
            {
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    IsoCountryCode = "ID",
                    Name = "Indonesia",
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    IsoCountryCode = "SG",
                    Name = "Singapore",
                }
            };
            return list;
        }
    }
}
