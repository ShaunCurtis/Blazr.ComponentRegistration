using Microsoft.AspNetCore.Components;

namespace Blazr.ComponentRegistration.Components;

public class BlazrOption : ComponentBase
{
    private bool _hasRegistered;

    [Parameter, EditorRequired] public string? Id { get; set; }
    [Parameter, EditorRequired] public string? Value { get; set; }
    [CascadingParameter] private BlazrOptionContext? Context { get; set; }

    public override Task SetParametersAsync(ParameterView parameters)
    {
        // We only need to do anything if we haven't yet registered
        if (!_hasRegistered)
        {
            // Manually get our parameters from the ParameterView
            var id = parameters.GetValueOrDefault<string>("Id");
            var value = parameters.GetValueOrDefault<string>("Value");
            this.Context = parameters.GetValueOrDefault<BlazrOptionContext>("Context");

            // Check we have everything.  If hot throw an exception
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(value);
            ArgumentNullException.ThrowIfNull(Context);

            // Register
            this.Context.Register(new(id, value));
            _hasRegistered = true;
        }
        // Short circuit the Lifecycle process.  We are wasting processor time doing it for no purpose.
        return Task.CompletedTask;
    }
}
