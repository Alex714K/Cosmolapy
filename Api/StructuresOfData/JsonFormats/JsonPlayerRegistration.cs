using System;
using System.Collections.Generic;

namespace Cosmolapy.Api.StructuresOfData.JsonFormats;

public struct JsonPlayerRegistration
{
    public string name;
    public Dictionary<string, string> resources;
}
