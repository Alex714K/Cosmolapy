namespace Cosmolapy.saveHandle.structuresOfData;

public struct PlayerRegistrationData
{
    public string name;
    public string password;
    public PlayerRegistrationData()
    {
        name = "";
        password = "";
    }
    public PlayerRegistrationData(string _name, string _password)
    {
        name = _name;
        password = _password;
    }
}
