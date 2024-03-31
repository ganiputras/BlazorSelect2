using BlazorSelect2.Data;

namespace BlazorSelect2.Common;

public class MasterDataService
{
    //private readonly IMediator _mediator;
    //private readonly ApplicationDbContext _context;
    public MasterDataService()
    {
    }


    public Dictionary<string, string> DropdownCountry()
    {
        var data = TbCountry.GetAll();
        return data.ToDictionary(key => key.IsoCountryCode, value => value.Name);
    }

    public Dictionary<string, string> DropdownCityGetIso(string isoCountryCode)
    {
        var data = TbCity.GetAll().Where(x => x.IsoCountryCode == isoCountryCode);
        return data.ToDictionary(key => key.Id, value => value.Name);
    }
    public Dictionary<string, string> DropdownPlaceType()
    {
        var data = TbPaceType.GetAll();
        return data.ToDictionary(key => key.Name, value => value.Name);
    }

    //enum list
    public Dictionary<string, string> DropdownPlaceCategory()
    {
        var data = Enum.GetValues(typeof(PlaceCategory))
            .Cast<PlaceCategory>()
            .ToDictionary(x => x.ToString(), x => x.ToString().AddSpacesToSentence());

        return data;
    }


}