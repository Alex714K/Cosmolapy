using System;
using System.Net.Http;
using Cosmolapy.scenes;
using Cosmolapy.saveHandle.structuresOfData.jsonFormats;
using Cosmolapy.saveHandle.structuresOfData;
using System.Net.Http.Json;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using GD = Godot;

namespace Cosmolapy.saveHandle.functions;

public static class RequestToServer
{
    // public static bool UpdateResources(PlayerRegistrationData playerRegistrationData, List<ResourceForServer> resources)
    public static void UpdateResources()
    {

    }

    /// <summary>
    /// Регистрирует игрока. При неуспешной регистрации возвращает false. При успешной - true.
    /// </summary>
    /// <param name="playerRegistrationData"></param>
    /// <returns>Статус успеха регистрации</returns>
    public static bool RegisterPlayer(PlayerRegistrationData playerRegistrationData)
    {
        using (var client = new HttpClient())
        {
            List<JsonPlayerData> listOfPlayers = GetPlayerList();
            if (IsPlayerInList(playerRegistrationData.name, listOfPlayers)) return false;

            string gameUUID = Global.gameUUID;

            Uri uri= new Uri($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/");

            JsonPlayerData jsonPlayer = new JsonPlayerData()
            {
                name = playerRegistrationData.name,
                resources = new Dictionary<string, string> ()
                {
                    {"password", playerRegistrationData.password},
                }
            };

            JsonContent content = JsonContent.Create(jsonPlayer);

            client.PostAsync(uri, content);

            return true;
        }
    }

    public static bool UnregisterPlayer(PlayerRegistrationData playerRegistrationData)
    {
        using (var client = new HttpClient())
        {
            List<JsonPlayerData> listOfPlayers = GetPlayerList();
            if (!IsPlayerInListAndWithRightPassword(playerRegistrationData, listOfPlayers)) return false;

            string gameUUID = Global.gameUUID;

            Uri uri= new Uri($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/");

            // JsonPlayerData jsonPlayer = new JsonPlayerData()
            // {
            //     name = playerRegistrationData.name,
            //     resources = new Dictionary<string, string> ()
            //     {
            //         {"password", playerRegistrationData.password},
            //     }
            // };

            // JsonContent content = JsonContent.Create(jsonPlayer);

            client.DeleteAsync(uri);

            return true;
        } 
    }

    public static bool TrySignIn(PlayerRegistrationData playerRegistrationData)
    {
        List<JsonPlayerData> listOfPlayers = GetPlayerList();

        if (IsPlayerInListAndWithRightPassword(playerRegistrationData, listOfPlayers)) return true;

        return false;
    }

    private static List<JsonPlayerData> GetPlayerList()
    {
        using (var client = new HttpClient())
        {
            string gameUUID = Global.gameUUID;

            Uri uri = new Uri($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/");

            List<JsonPlayerData> listOfPlayers = client.GetFromJsonAsync<List<JsonPlayerData>>(uri).Result;

            return listOfPlayers;
        }
    }

    private static bool IsPlayerInListAndWithRightPassword(PlayerRegistrationData playerRegistrationData, List<JsonPlayerData> registrations)
    {
        bool flag = false;
        foreach (JsonPlayerData item in registrations)
        {
            if (playerRegistrationData.name == item.name)
            {
                if (playerRegistrationData.password == item.resources["password"])
                    flag = true;
                break;
            }

        }

        return flag;
    }

    private static bool IsPlayerInList(string name, List<JsonPlayerData> registrations)
    {
        bool flag = false;
        foreach (JsonPlayerData item in registrations)
        {
            if (name == item.name)
            {
                flag = true;
                break;
            }

        }

        return flag;
    }

}