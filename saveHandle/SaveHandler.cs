using Cosmolapy.saveHandle.structuresOfData;
using Cosmolapy.saveHandle.functions;
using System.Collections.Generic;

namespace Cosmolapy.saveHandle;

public static class SaveHandler
{
    public static bool CheckIthernet()
    {
        return RequestToServer.PingDNS();
    }
    
    public static void SaveData()
    {
        if (RequestToServer.PingDNS())
        {
            RequestToServer.SaveData();
            RequestToDataBase.SaveData();
        }
        else 
        {
            RequestToDataBase.SaveData();
        }
    }

    public static void LoadData()
    {
        if (RequestToServer.PingDNS())
        {
            RequestToDataBase.LoadData();
            RequestToServer.LoadData();
        }
        else 
        {
            RequestToDataBase.LoadData();
        }
    }

    public static bool Auth(PlayerRegistrationData playerRegistrationData)
    {
        if (RequestToServer.PingDNS() && RequestToServer.Auth(playerRegistrationData))
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
        if (!RequestToServer.PingDNS()) return false;

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
        if (!RequestToServer.PingDNS()) return false;

        if (RequestToServer.UnregisterPlayer(playerRegistrationData))
        {
            Global.playerRegistrationData = new PlayerRegistrationData();
            RequestToDataBase.DeleteDataFromTable();
            return true;
        }

        return false;
    }
}
