using Godot;
using System;
using Cosmolapy;

public partial class ProgressLabel : Label
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Text = "Progress: " + Global.mainModel.rocket.Progress.ToString() + "/" + Global.mainModel.rocket.NeedProgress.ToString();
	}
}
