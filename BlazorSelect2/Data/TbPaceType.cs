using System.ComponentModel.DataAnnotations;

namespace BlazorSelect2.Data
{
    public class TbPaceType
    {
        public string Id { get; set; }
        [StringLength(155)] public string Name { get; set; }
        public int Order { get; set; }


        public static List<TbPaceType> GetAll()
        {
            var list = new List<TbPaceType>
            {
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Room",
                    Order = 1
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Office Room",
                    Order = 2
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Meeting Room",
                    Order = 3
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Hall Room",
                    Order = 4
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Restaurant",
                    Order = 5
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Cafe",
                    Order = 6
                }
            };
            return list;
        }
    }
}
