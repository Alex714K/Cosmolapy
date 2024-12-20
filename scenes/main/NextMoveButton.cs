using Cosmolapy;
using Godot;
using System;

public partial class NextMoveButton : Button
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
		Global.mainModel.NextMove();

		CardsView cardsView = GetTree().Root.GetNode<CardsView>("Main/Camera/MainGui/Cards");
		cardsView.Update();

	}
}
