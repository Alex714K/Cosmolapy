using System;
using System.Collections.Generic;

namespace Cosmolapy.saveHandle.structuresOfData.jsonFormats;

public struct JsonLogsPlayer
{
    public string comment;
    public string player_name;
    public Dictionary<string, string> resources_changed;
}
