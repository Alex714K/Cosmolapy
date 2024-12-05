using System;
using System.Net.Http;
using Cosmolapy.saveHandle.structuresOfData.jsonFormats;
using Cosmolapy.saveHandle.structuresOfData;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using GD = Godot;

namespace Cosmolapy.saveHandle.functions;

public static class RequestToServer
{
	public static bool PostLogPlayer(JsonLogsPlayer jsonLogsPlayer)
	{
		using (var client = new HttpClient())
		{
			string gameUUID = Global.gameUUID;
			string name = Global.playerRegistrationData.name;

			Uri uri = new Uri($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/logs/");

			JsonContent content = JsonContent.Create(jsonLogsPlayer);

			var response = client.PostAsync(uri, content);
		}
		return true;
	}

	public static bool PostLogShop(JsonLogsShop jsonLogsShop)
	{
		using (var client = new HttpClient())
		{
			string gameUUID = Global.gameUUID;
			string name = Global.playerRegistrationData.name;

			Uri uri = new Uri($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/logs/");

			JsonContent content = JsonContent.Create(jsonLogsShop);

			var response = client.PostAsync(uri, content);
		}
		return true;
	}

	public static bool SaveData()
	{
		using (var client = new HttpClient())
		{
			string gameUUID = Global.gameUUID;
			string name = Global.playerRegistrationData.name;

			Uri uri= new Uri($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/{name}");

			JsonPutData jsonPut = new JsonPutData(CreateDataFromGlobal());

			JsonContent content = JsonContent.Create(jsonPut);

			var response = client.PutAsJsonAsync(uri, content).Result;

			return true;
		}
	}

	public static bool LoadData()
	{
		using (var client = new HttpClient())
		{
			string gameUUID = Global.gameUUID;
			string name = Global.playerRegistrationData.name;

			Uri uri= new Uri($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/{name}");

			var response = client.GetAsync(uri).Result;

			JsonGetResourcesData playerData = response.Content.ReadFromJsonAsync<JsonGetResourcesData>().Result;

			LoadDataInGlobal(playerData.resources);
			LoadDataInGlobal(new Dictionary<string, string>(){ 
				{ "name", name } 
			});
		}
		return true;
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
			List<JsonGetResourcesData> listOfPlayers = GetPlayerList();
			if (IsPlayerInList(playerRegistrationData.name, listOfPlayers)) return false;

			string gameUUID = Global.gameUUID;

			Uri uri= new Uri($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/");

			JsonGetResourcesData jsonPlayer = new JsonGetResourcesData()
			{
				name = playerRegistrationData.name,
				resources = new Dictionary<string, string> ()
				{
					{"password", playerRegistrationData.password},
				}
			};

			JsonContent content = JsonContent.Create(jsonPlayer);
			
			var response = client.PostAsync(uri, content).Result;
			
			return true;
		}
	}

	public static bool UnregisterPlayer(PlayerRegistrationData playerRegistrationData)
	{
		using (var client = new HttpClient())
		{
			List<JsonGetResourcesData> listOfPlayers = GetPlayerList();
			if (!IsPlayerInListAndWithRightPassword(playerRegistrationData, listOfPlayers)) return false;

			string gameUUID = Global.gameUUID;
			string name = playerRegistrationData.name;

			Uri uri= new Uri($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/{name}");

			var response = client.DeleteAsync(uri).Result;

			return true;
		} 
	}

	public static bool Auth(PlayerRegistrationData playerRegistrationData)
	{
		List<JsonGetResourcesData> listOfPlayers = GetPlayerList();

		if (IsPlayerInListAndWithRightPassword(playerRegistrationData, listOfPlayers)) 
			return true;

		return false;
	}

    private static void LoadDataInGlobal(Dictionary<string, string> dataTable)
    {
        foreach (string key in dataTable.Keys)
        {
            switch ((DataType)Enum.Parse(typeof(DataType), key))
            {
                case DataType.Wood:
                    Global.mainModel.resources.Wood = Convert.ToInt32(dataTable[key]);
                    break;
                case DataType.Iron:
                    Global.mainModel.resources.Iron = Convert.ToInt32(dataTable[key]);
                    break;
                case DataType.BioFuel:
                    Global.mainModel.resources.BioFuel = Convert.ToInt32(dataTable[key]);
                    break;
                case DataType.Honey:
                    Global.mainModel.resources.Honey = Convert.ToInt32(dataTable[key]);
                    break;
                case DataType.Name:
                    Global.playerRegistrationData.name = dataTable[key];
                    break;
                case DataType.Password:
                    Global.playerRegistrationData.password = dataTable[key];
                    break;
            }
        }
    }

	private static void LoadDataInGlobal(Dictionary<DataType, string> dataTable)
	{
		foreach (DataType key in dataTable.Keys)
		{
			switch (key)
			{
				case DataType.Wood:
					Global.mainModel.resources.Wood = Convert.ToInt32(dataTable[key]);
					break;
				case DataType.Iron:
					Global.mainModel.resources.Iron = Convert.ToInt32(dataTable[key]);
					break;
				case DataType.BioFuel:
					Global.mainModel.resources.BioFuel = Convert.ToInt32(dataTable[key]);
					break;
				case DataType.Honey:
					Global.mainModel.resources.Honey = Convert.ToInt32(dataTable[key]);
					break;
				case DataType.Name:
					Global.playerRegistrationData.name = dataTable[key];
					break;
				case DataType.Password:
					Global.playerRegistrationData.password = dataTable[key];
					break;
			}
		}
	}

    private static Dictionary<string, string> CreateDataFromGlobal()
    {
        Dictionary<string, string> data = new Dictionary<string, string>()
        {
            { DataType.Wood.ToString(), Global.mainModel.resources.Wood.ToString() },
            { DataType.Iron.ToString(), Global.mainModel.resources.Iron.ToString() },
            { DataType.BioFuel.ToString(), Global.mainModel.resources.BioFuel.ToString() },
            { DataType.Honey.ToString(), Global.mainModel.resources.Honey.ToString() },
            { DataType.Password.ToString(), Global.playerRegistrationData.password },

        };
        return data;
    }

	private static List<JsonGetResourcesData> GetPlayerList()
	{
		using (var client = new HttpClient())
		{
			string gameUUID = Global.gameUUID;

			Uri uri = new Uri($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/");

			List<JsonGetResourcesData> listOfPlayers = client.GetFromJsonAsync<List<JsonGetResourcesData>>(uri).Result;

			return listOfPlayers;
		}
	}

	private static bool IsPlayerInListAndWithRightPassword(PlayerRegistrationData playerRegistrationData, List<JsonGetResourcesData> registrations)
	{
		bool flag = false;
		foreach (JsonGetResourcesData item in registrations)
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

	private static bool IsPlayerInList(string name, List<JsonGetResourcesData> registrations)
	{
		bool flag = false;
		foreach (JsonGetResourcesData item in registrations)
		{
			if (name == item.name)
			{
				flag = true;
				break;
			}

		}

		return flag;
	}

	public static bool PingDNS()
	{
		string address = "8.8.8.8";

		try 
		{
			using (Ping ping = new Ping())
			{
				PingReply reply = ping.Send(address);
				return reply.Status == IPStatus.Success;
			}
		}
		catch
		{
			return false;
		}
	}
}
