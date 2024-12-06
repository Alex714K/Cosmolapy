using System.Collections.Generic;

namespace Cosmolapy.saveHandle.structuresOfData.jsonFormats;

public struct JsonPutData
{
    public JsonPutData(Dictionary<string, string> _resources)
    {
        resources = _resources;
    }
    public Dictionary<string, string> resources;
}
