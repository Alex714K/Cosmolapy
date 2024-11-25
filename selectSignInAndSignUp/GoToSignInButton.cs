using Godot;
using System;

public partial class GoToSignInButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += buttonPressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void buttonPressed()
	{
        GetTree().ChangeSceneToFile("res://signIn/sign_in.tscn");
    }

}
