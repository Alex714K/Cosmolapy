using Cosmolapy;
using Godot;
using System;

public partial class WoodLabel : Label
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
        Text = Global.mainModel.resources.Wood.ToString();
    }
}
