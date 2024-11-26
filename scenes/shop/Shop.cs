using Cosmolapy.scenes;
using Godot;
using System;

public partial class Shop : Control
{
    Label honeyLabel;
    Label woodLabel;
    public override void _Ready()
	{
        honeyLabel = GetNode<Label>("HoneyLabel");
        woodLabel = GetNode<Label>("WoodLabel");
    }

	public override void _Process(double delta)
	{
        honeyLabel.Text = Global.mainModel.resources.Honey.ToString();
        woodLabel.Text = Global.mainModel.resources.Wood.ToString();
    }
}
