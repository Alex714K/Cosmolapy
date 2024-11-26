using System;
using System.Collections.Generic;
using System.Linq;
using Cosmolapy.Api.StructuresOfData;
using Cosmolapy.Api.StructuresOfData.JsonFormats;
using Cosmolapy.Api.Requests;

namespace Cosmolapy.Api;

public static class Api
{
    public static void UpdateResources(List<ResourceForServer> resources)
    {

    }

    public static void RegisterPlayer(PlayerRegistrationData playerRegistrationData)
    {
        RequestToServer.RegisterPlayer(playerRegistrationData);
    }
}
