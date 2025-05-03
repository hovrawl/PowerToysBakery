// See https://aka.ms/new-console-template for more information

// Set up device information
string masterPassword = "Kawa.l130695";
string clientId = "user.28681247-8c14-480f-8f12-b130005e4125";
string clientSecret = "eYlN7n7UAjbo1McbEG2HhuxRvluuNm";
string url = "https://vault.bitwarden.com";

var available = Bitwarden.Client.BitwardenClient.CliAvailable();
if (!available)
{
    Console.WriteLine("CLI not available, downloading...");
    var progress = new Progress<double>(percent => 
    {
        Console.Write($"\rDownloading: {percent:F1}%");
    });
    
    var cancellationTokenSource = new CancellationTokenSource();
    try
    {
        await Bitwarden.Client.BitwardenClient.DownloadCli(progress, cancellationTokenSource.Token);
        Console.WriteLine("\nDownload complete!");
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("\nDownload was cancelled.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nError downloading CLI: {ex.Message}");
    }
}

using var client = new Bitwarden.Client.BitwardenClient(url, clientId, clientSecret, masterPassword);
var items = client.ListItems();

var hoyoItems = items.Where(i => i.name.Contains("hoyo", StringComparison.CurrentCultureIgnoreCase));

foreach (var item in hoyoItems)
{
    Console.WriteLine(item.name);
}