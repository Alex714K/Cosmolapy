using System;
using System.Collections.Generic;

namespace Cosmolapy.saveHandle.structuresOfData.jsonFormats;

public struct JsonLogsShop
{
    public string comment;
    public string player_name;
    public string shop_name;
    public Dictionary<string, string> resources_changed;
}

