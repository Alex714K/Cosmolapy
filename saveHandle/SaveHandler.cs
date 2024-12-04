using Cosmolapy.saveHandle.structuresOfData;
using Cosmolapy.saveHandle.functions;
using System.Collections.Generic;

namespace Cosmolapy.saveHandle;

public static class SaveHandler
{
    public static void SaveData()
    {
        RequestToServer.SaveData();
        RequestToDataBase.SaveData();
    }

    public static void LoadData()
    {
        RequestToDataBase.LoadData();
        RequestToServer.LoadData();
    }

    public static bool Auth(PlayerRegistrationData playerRegistrationData)
    {
        if (RequestToServer.Auth(playerRegistrationData))
        {
            if (Global.playerRegistrationData.name == playerRegistrationData.name && 
                Global.playerRegistrationData.password == playerRegistrationData.password) 
                return true;
            
            Global.playerRegistrationData = playerRegistrationData;
            RequestToDataBase.SaveData();
            return true;
        }
        else 
        {
            if (Global.playerRegistrationData.name == playerRegistrationData.name && 
                Global.playerRegistrationData.password == playerRegistrationData.password) 
                return true;
            else 
                return false;
        }
    }

    public static bool RegisterPlayer(PlayerRegistrationData playerRegistrationData)
    {
        RequestToDataBase.CreateTable();
        if (RequestToServer.RegisterPlayer(playerRegistrationData))
        {
            Global.playerRegistrationData = playerRegistrationData;
            RequestToDataBase.SaveData();
            return true;
        }

        return false;
    }

    public static bool UnregisterPlayer(PlayerRegistrationData playerRegistrationData)
    {
        if (RequestToServer.UnregisterPlayer(playerRegistrationData))
        {
            Global.playerRegistrationData = new PlayerRegistrationData();
            RequestToDataBase.DeleteDataFromTable();
            return true;
        }

        return false;
    }
}
