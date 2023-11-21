namespace Blazr.ComponentRegistration.Components;

public class BlazrOptionContext
{
    private List<OptionData> _items = new List<OptionData>();

    public IEnumerable<OptionData> Items => _items.AsEnumerable();

    public void Register(OptionData option)
    {
        if (!_items.Contains(option))
            _items.Add(option);
    }
}
