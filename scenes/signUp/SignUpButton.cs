using Godot;
using System;
using Cosmolapy.saveHandle;
using Cosmolapy.saveHandle.structuresOfData;

public partial class SignUpButton : Button
{
    TextEdit loginTextEdit;
    TextEdit passwordTextEdit;

    public override void _Ready()
    {
        Pressed += buttonPressed;
        loginTextEdit = GetTree().Root.GetNode("SignUp").GetNode<TextEdit>("LoginTextEdit");
        passwordTextEdit = GetTree().Root.GetNode("SignUp").GetNode<TextEdit>("PasswordTextEdit");
    }

    public override void _Process(double delta)
    {
    }

    public void buttonPressed()
    {
        if (SaveHandler.RegisterPlayer(new PlayerRegistrationData(
            loginTextEdit.Text, passwordTextEdit.Text
            )))
            GetTree().ChangeSceneToFile("res://scenes/main/main.tscn");
    }
}
