using Cosmolapy.saveHandle.structuresOfData;
using Cosmolapy.saveHandle.functions;
using System.Collections.Generic;

namespace Cosmolapy.saveHandle;

public static class SaveHandler
{
    public static void UpdateResources(List<DataForServer> resources)
    {
        RequestToDataBase.GetDataFromTable();
        RequestToServer.UpdateResources();
    }

    public static bool RegisterPlayer(PlayerRegistrationData playerRegistrationData)
    {
        return RequestToServer.RegisterPlayer(playerRegistrationData);
    }

    public static bool UnregisterPlayer(PlayerRegistrationData playerRegistrationData)
    {
        return RequestToServer.UnregisterPlayer(playerRegistrationData);
    }
}
