using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

//template https://apalfrey.github.io/select2-bootstrap-5-theme/examples/single-select/

namespace BlazorSelect2.Components.Pages;

//jika value adalah enum gunakan callback
public partial class DropdownSelect<TValue> : InputSelect<TValue>, IAsyncDisposable
{

    [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();
    [Parameter] public string Css { get; set; } = "form-select form-select-sm";
    [Parameter] public string EmptyText { get; set; }
    [Parameter] public ICollection<KeyValuePair<string, string>> DataSource { get; set; }
    [Parameter] public EventCallback<string> EventDropdown { get; set; }
    [Inject] private IJSRuntime Js { get; set; }
    private IJSObjectReference _jsRef;
    public DotNetObjectReference<DropdownSelect<TValue>> DotNetRef;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        DotNetRef = DotNetObjectReference.Create(this);
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            //if use Razor Call Library Project
            //_jsRef = await Js.InvokeAsync<IJSObjectReference>("import", "./_content/WebApp.Shared/dropdown-select2.js");


            _jsRef = await Js.InvokeAsync<IJSObjectReference>("import", "./dropdown-select2.js");
            await Js.InvokeVoidAsync("select2Component.init", Id);
            await Js.InvokeVoidAsync("select2Component.onChange", Id, DotNetRef, "Change_Invokable");
        }
        await base.OnAfterRenderAsync(firstRender);

    }



    [JSInvokable("Change_Invokable")]
    public void Change(string value)
    {
        if (value == "null") value = null;
        if (typeof(TValue) == typeof(string))
        {
            CurrentValue = (TValue)(object)value!;

        }
        else if (typeof(TValue) == typeof(int))
        {
            int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);
            CurrentValue = (TValue)(object)parsedValue;
        }
        else if (typeof(TValue) == typeof(int))
        {
            if (value == null)
            {
                CurrentValue = (TValue)(object)null!;
            }
            else
            {
                int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);
                CurrentValue = (TValue)(object)parsedValue;
            }
        }

        EventDropdown.InvokeAsync(value);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_jsRef != null) await _jsRef.DisposeAsync();
    }

    public async ValueTask DisposeAsync()
    {
        try
        {
            await DisposeAsyncCore();
            GC.SuppressFinalize(this);
        }
        catch (JSDisconnectedException e)
        {
            // Ignore
        }
    }

}