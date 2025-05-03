using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using Bitwarden.Client;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace BitwardenSearch.Commands;

internal sealed partial class BitwardenLoginForm : FormContent
{
    public BitwardenClient Client;
    private string _username;
    private string _password;
    private string _url = "https://vault.bitwarden.com";
    
    public BitwardenLoginForm(string username, string password, string url = "")
    {
        var _applicationName = "Bitwarden Search Login";
        _username = username;
        _password = password;
        if (!string.IsNullOrEmpty(url)) _url = url;
        
        TemplateJson = $$"""
                          {
                              "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
                              "type": "AdaptiveCard",
                              "version": "1.6",
                              "body": [
                                  {
                                      "type": "TextBlock",
                                      "size": "Medium",
                                      "weight": "Bolder",
                                      "text": " ${ApplicationInfo.title}",
                                      "horizontalAlignment": "Center",
                                      "wrap": true,
                                      "style": "heading"
                                  },
                                  {
                                      "type": "Input.Text",
                                      "id": "UserVal",
                                      "label": "Username",
                                      "isRequired": true,
                                      "value": {{{JsonSerializer.Serialize(_username)}}},
                                      "errorMessage": "Username is required"
                                  },
                                  {
                                      "type": "Input.Text",
                                      "id": "PassVal",
                                      "style": "Password",
                                      "label": "Password",
                                      "value": {{JsonSerializer.Serialize(password)}},
                                      "isRequired": true,
                                      "errorMessage": "Password is required"
                                  }
                              ],
                              "actions": [
                                  {
                                      "type": "Action.Submit",
                                      "title": "Login",
                                      "data": {
                                          "id": "LoginVal"
                                      }
                                  }
                              ]
                          }
                          """;
        
        DataJson = $$"""
                     {
                         "ApplicationInfo": {
                             "title": "{{_applicationName}}"
                         }
                     }
                     """;
    }
    public override CommandResult SubmitForm(string payload)
    {
        var formInput = JsonNode.Parse(payload)?.AsObject();
        if (formInput == null)
        {
            return CommandResult.GoHome();
        }

        //var url = formInput["UrlVal"]?.ToString();
        var username = formInput["UserVal"]?.ToString();
        var password = formInput["PassVal"]?.ToString();

        if (Client == null)
        {
            Client = new BitwardenClient(_url, username, password);
        }
        else
        {
            var result = Client.LogIn(_url, username, password);
        }
        
        return CommandResult.GoBack();
    }
}