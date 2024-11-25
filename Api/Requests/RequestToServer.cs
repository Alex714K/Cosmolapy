using System;
using System.Net.Http;
using Cosmolapy.scenes;
using Cosmolapy.Api.StructuresOfData.JsonFormats;
using Cosmolapy.Api.StructuresOfData;
using System.Net.Http.Json;
using System.Collections.Generic;

namespace Cosmolapy.Api.Requests;

public static class RequestToServer
{
    public static void RegisterPlayer(PlayerRegistrationData playerRegistrationData)
    {
        using (var client = new HttpClient())
        {
            string gameUUID = Global.gameUUID;

            Uri uri= new Uri($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/");
            
            JsonPlayerRegistration jsonPlayer = new JsonPlayerRegistration();
            jsonPlayer.name = playerRegistrationData.name;
            jsonPlayer.resources = new Dictionary<string, string> () 
            {
                {"password", playerRegistrationData.password}
            };

            JsonContent content = JsonContent.Create(jsonPlayer);

            client.PostAsync(uri, content);
        }
    }

    public static void UnregisterPlayer(PlayerRegistrationData playerRegistrationData)
    {
        using (var client = new HttpClient())
        {
            string gameUUID = Global.gameUUID;

            Uri uri= new Uri($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/");

            List<JsonPlayerRegistration> listOfPlayers = client.GetFromJsonAsync<List<JsonPlayerRegistration>>(uri).Result;

            JsonPlayerRegistration jsonPlayer = new JsonPlayerRegistration();
            jsonPlayer.name = playerRegistrationData.name;
            jsonPlayer.resources = new Dictionary<string, string> () 
            {
                {"password", playerRegistrationData.password}
            };

            JsonContent content = JsonContent.Create(jsonPlayer);

            client.DeleteAsync(uri);
        } 
    }

    private static bool IsPlayerInListAndWithRightPassword(PlayerRegistrationData playerRegistrationData, List<JsonPlayerRegistration> registrations)
    {
        bool flag = false;
        foreach (JsonPlayerRegistration item in registrations)
        {
            if (playerRegistrationData.name == item.name && playerRegistrationData.password == item.resources["password"])
            {
                flag = true;
                break;
            }
            else if (playerRegistrationData.name == item.name) break;
        }
        return flag;
    }
}
