using Godot;
using System;

public partial class GoToSignUpButton : Button
{

	public override void _Ready()
	{
        Pressed += buttonPressed;
    }

	public override void _Process(double delta)
	{
	}

	private void buttonPressed()
	{
        GetTree().ChangeSceneToFile("res://scenes/signUp/sign_up.tscn");
    }

}
