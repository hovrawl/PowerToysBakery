using System.Linq;
using BitwardenSearch.Commands;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace BitwardenSearch.Pages;

internal sealed partial class ConfigPage : ListPage
{
    public ConfigPage()
    {
        Icon = new("\uF147"); // Dial2
        Title = "Configuration";
        Name = "Open";
    }

    public override IListItem[] GetItems()
    {
        return [ 
            new ListItem(new BitwardenConfigPage())
            {
                Title = "Configuration",
                Subtitle = "Configure your Bitwarden credentials",
            }
        ];
    }
}