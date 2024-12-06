using Cosmolapy;
using Godot;
using System;

public partial class BiofuelLabel : Label
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Text = Global.mainModel.resources.BioFuel.ToString();
	}
}