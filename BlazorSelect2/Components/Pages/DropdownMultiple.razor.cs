using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace BlazorSelect2.Components.Pages;

//jika value  enum gunakan callback
[StreamRendering]

public partial class DropdownMultiple<TValue> : InputSelect<TValue>, IAsyncDisposable
{
    [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();

    [Parameter] public string Css { get; set; } = "form-select";
    [Parameter] public bool EmptyText { get; set; }
    [Parameter] public ICollection<KeyValuePair<string, string>> DataSource { get; set; }

    [Parameter]
    public EventCallback<string[]> EventDropdown { get; set; }

    [Inject] private IJSRuntime Js { get; set; }
    private IJSObjectReference _jsRef;

    public DotNetObjectReference<DropdownMultiple<TValue>> DotNetRef;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        DotNetRef = DotNetObjectReference.Create(this);
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            //_jsRef = await Js.InvokeAsync<IJSObjectReference>("import", "./_content/WebApp.Shared/dropdown-select2.js");
            _jsRef = await Js.InvokeAsync<IJSObjectReference>("import", "./dropdown-select2.js");

            await Js.InvokeVoidAsync("select2Component.init", Id);
            await Js.InvokeVoidAsync("select2Component.onChange", Id, DotNetRef, "Change_Invokable");
            await Js.InvokeVoidAsync("select2Component.onUnSelect", Id, DotNetRef, "Change_Invokable");
        }
        await base.OnAfterRenderAsync(firstRender);

    }

    [JSInvokable("Change_Invokable")]
    public void Change(string[] value)
    {
        if (!value.Any()) value = new[] { "" };
        if (typeof(TValue) == typeof(string[]))
        {
            CurrentValue = (TValue)(object)value;
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
