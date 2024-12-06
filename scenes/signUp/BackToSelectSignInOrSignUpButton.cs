using Godot;
using System;

public partial class BackToSelectSignInOrSignUpButton : Button
{
	public override void _Ready()
	{
		Pressed += buttonPressed;
	}

	public override void _Process(double delta)
	{
        
    }

	public void buttonPressed()
	{
        GetTree().ChangeSceneToFile("res://scenes/selectSignInAndSignUp/select_sig_in_or_sign_up.tscn");
    }

}
