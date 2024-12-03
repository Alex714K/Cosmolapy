using Cosmolapy;
using Godot;
using System;

public partial class MoveLabel : Label
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Text = Global.mainModel.Move.ToString();
	}
}
