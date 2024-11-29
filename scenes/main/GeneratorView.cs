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
		upgradeButton = GetNode<Button>("EnterButton");
		upgradeButton.Pressed += buttonPressed;
    }

	internal void SetData(Generator _data, Vector2 position)
	{
		data = _data;
		Position = position;
	}

	private void buttonPressed()
	{
        GetTree().ChangeSceneToFile("res://scenes/generatorView/generator_scene.tscn");
		Global.mainModel.viewGenerator = data;
    }

    public override void _Process(double delta)
	{
		nameLabel.Text = data.name;
	}
}
