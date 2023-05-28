using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace BlazorSelect2.Components;

public partial class DropdownSelect<TValue> : InputBase<TValue>, IAsyncDisposable
{

    [Parameter] public string Id { get; set; } 
    [Parameter] public string Css { get; set; }
    [Parameter] public string EmptyText { get; set; } 
    [Parameter] public ICollection<KeyValuePair<string, string>>? DataSource { get; set; }

    

    [Inject] private IJSRuntime JS { get; set; }
    private IJSObjectReference? _jsRef;
    public DotNetObjectReference<DropdownSelect<TValue>>? DotNetRef;


    public async ValueTask DisposeAsync()
    {
        if (_jsRef is not null) await _jsRef.DisposeAsync();
    }

    protected override bool TryParseValueFromString(string? value, out TValue result, out string validationErrorMessage)
    {
        if (value == "null" || value == null) value = null;
        if (typeof(TValue) == typeof(string))
        {
            result = (TValue)(object)value!;
            validationErrorMessage = null!;

            return true;
        }

        if (typeof(TValue) == typeof(int) || typeof(TValue) == typeof(int?))
        {
            int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);
            result = (TValue)(object)parsedValue;
            validationErrorMessage = null!;

            return true;
        }

        throw new InvalidOperationException($"{GetType()} does not support the type '{typeof(TValue)}'.");
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        DotNetRef = DotNetObjectReference.Create(this);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (firstRender)
        {
            _jsRef = await JS.InvokeAsync<IJSObjectReference>("import", "./js/dropdown.js");
            await JS.InvokeVoidAsync("select2Component.init", Id);
            await JS.InvokeVoidAsync("select2Component.onChange", Id, DotNetRef, "Change_SelectWithFilterBase");
        }
    }

    [JSInvokable("Change_SelectWithFilterBase")]
    public void Change(string? value)
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
        else if (typeof(TValue) == typeof(int?))
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
    }
}