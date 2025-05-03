using BitwardenSearch.Commands;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace BitwardenSearch.Pages;

internal sealed partial class BitwardenConfigPage : ContentPage
{
    private readonly BitwardenLoginForm loginForm = new BitwardenLoginForm("", "");
    public BitwardenConfigPage()
    {
        Icon = IconHelpers.FromRelativePath("Assets\\light.png");
        Title = "Bitwarden Search Configuration";
        Name = "Open";
    }
    
    public override IContent[] GetContent() => [loginForm];

}