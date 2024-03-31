using System.ComponentModel.DataAnnotations;

namespace BlazorSelect2.Data
{
    public class TbCity
    {
        public string Id { get; set; }

        [StringLength(155)] public string Name { get; set; }
        [StringLength(155)] public string IsoCountryCode { get; set; }
        public static List<TbCountry> GetAll()
        {
            var list = new List<TbCountry>
            {
                new()
                {
                    Id =  Guid.NewGuid().ToString().Substring(0,5),
                    IsoCountryCode = "ID",
                    Name = "Jakarta"
                },
                new()
                {
                    Id =  Guid.NewGuid().ToString().Substring(0,5),
                    IsoCountryCode = "ID",
                    Name = "Bandung"
                },
                new()
                {
                    Id =  Guid.NewGuid().ToString().Substring(0,5),
                    IsoCountryCode = "ID",
                    Name = "Bali"
                },
                new()
                {
                    Id =  Guid.NewGuid().ToString().Substring(0, 5),
                    IsoCountryCode = "ID",
                    Name = "Tegal"
                },
                new()
                {
                    Id =  Guid.NewGuid().ToString().Substring(0,5),
                    IsoCountryCode = "ID",
                    Name = "Surabaya"
                },
                new()
                {
                    Id = Guid.NewGuid().ToString().Substring(0,5),
                    IsoCountryCode = "SG",
                    Name = "Bedok"
                },
                new()
                {
                    Id = Guid.NewGuid().ToString().Substring(0,5),
                    IsoCountryCode = "SG",
                    Name = "Changi"
                },
                new()
                {
                    Id = Guid.NewGuid().ToString().Substring(0,5),
                    IsoCountryCode = "SG",
                    Name = "Pasir Ris"
                },
                new()
                {
                    Id = Guid.NewGuid().ToString().Substring(0,5),
                    IsoCountryCode = "SG",
                    Name = "Tampines"
                }
            };
            return list;
        }
    }
}
