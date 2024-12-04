using Cosmolapy;
using Godot;
using System;

public partial class HoneyToWoodButton : Button
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
		if (Global.mainModel.resources.Honey >= 100)
		{
            Global.mainModel.resources.Wood += 50;
            Global.mainModel.resources.Honey -= 100;
        }
	}

}
