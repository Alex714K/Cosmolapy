using Godot;
using System;

public partial class BackButton : Button
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
        GetTree().ChangeSceneToFile("res://scenes/main/main.tscn");
    }

}
