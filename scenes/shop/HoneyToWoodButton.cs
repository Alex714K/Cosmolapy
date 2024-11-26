using Cosmolapy.scenes;
using Godot;
using System;

public partial class HoneyToWoodButton : Button
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

	private void buttonPressed()
	{
		if (Global.mainModel.resources.Honey >= 100)
		{
            Global.mainModel.resources.Wood += 50;
            Global.mainModel.resources.Honey -= 100;
        }
	}

}
