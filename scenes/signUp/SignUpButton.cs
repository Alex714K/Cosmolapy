using Godot;
using System;

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
        GetTree().ChangeSceneToFile("res://scenes/selectSignInAndSignUp/select_sig_in_or_sign_up.tscn");
    }
}
