using BitwardenSearch.Commands;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace BitwardenSearch.Pages;

internal sealed partial class BitwardenSearchPage : ListPage
{
    public BitwardenSearchPage()
    {
        Icon = IconHelpers.FromRelativePath("Assets\\light.png");
        Title = "Bitwarden Search";
        Name = "Open";
    }

    public override IListItem[] GetItems()
    {
        var command = new OpenUrlCommand("https://github.com/hovrawl/PowerToysBakery");
        return [
            new ListItem(command)
            {
                Title = "View Source Code",
            },
            new ListItem(new BitwardenConfigPage())
            {
                Title = "Configuration",
                Subtitle = "Configure your Bitwarden credentials",
            }
        ];
    }
}
