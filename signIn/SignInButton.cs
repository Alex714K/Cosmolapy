using Godot;
using System;

public partial class SignInButton : Button
{
	// Called when the node enters the scene tree for the first time.
	TextEdit loginTextEdit;
    TextEdit passwordTextEdit;
	
	public override void _Ready()
	{
		Pressed += buttonPressed;
        loginTextEdit = GetTree().Root.GetNode("SignIn").GetNode<TextEdit>("LoginTextEdit");
		passwordTextEdit = GetTree().Root.GetNode("SignIn").GetNode<TextEdit>("PasswordTextEdit");

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void buttonPressed()
	{
		if (loginTextEdit.Text == "qwe" && passwordTextEdit.Text == "asd")
		{
			GetTree().ChangeSceneToFile("res://scenes/main/main.tscn");
		}
    }

}
