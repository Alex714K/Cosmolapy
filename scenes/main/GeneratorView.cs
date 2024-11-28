using Godot;
using System;
using Cosmolapy;
using Cosmolapy.Buildings.Generators;

public partial class GeneratorView : Node2D
{
	Generator data;

	Button upgradeButton;
	Label nameLabel;
	Label changeHoneyLabel;
	Label changeWoodLabel;

	public override void _Ready()
	{
		nameLabel = GetNode<Label>("NameLabel");
		changeHoneyLabel = GetNode<Label>("ChangeHoneyLabel");
		changeWoodLabel = GetNode<Label>("ChangeWoodLabel");
		upgradeButton = GetNode<Button>("UpgradeButton");
		upgradeButton.Pressed += buttonPressed;


    }

	internal void SetData(Generator _data, Vector2 position)
	{
		data = _data;
		Position = position;
	}

	private void buttonPressed()
	{
		data.NextLevel();
	}

    public override void _Process(double delta)
	{
        nameLabel.Text = data.name;
        changeHoneyLabel.Text = ((int)data.changeHoney).ToString();
        changeWoodLabel.Text = ((int)data.changeWood).ToString();
        //GD.Print(Position.ToString() + " " + Visible);
    }
}
