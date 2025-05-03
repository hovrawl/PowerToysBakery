// See https://aka.ms/new-console-template for more information

// Set up device information
string masterPassword = "Kawa.l130695";
string clientId = "user.28681247-8c14-480f-8f12-b130005e4125";
string clientSecret = "eYlN7n7UAjbo1McbEG2HhuxRvluuNm";
string url = "https://vault.bitwarden.com";
using var client = new Bitwarden.Client.BitwardenClient(url, clientId, clientSecret, masterPassword);
var items = client.ListItems();

var hoyoItems = items.Where(i => i.name.Contains("hoyo", StringComparison.CurrentCultureIgnoreCase));

foreach (var item in hoyoItems)
{
    Console.WriteLine(item.name);
}