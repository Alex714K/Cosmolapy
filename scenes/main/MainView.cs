using Cosmolapy;
using Cosmolapy.scenes.main;
using Godot;
using System;

public partial class MainView : Node2D
{
	Label honeyLabel;
	Label woodLabel;
	Label moveLabel;

	public override void _Ready()
	{
        honeyLabel = GetTree().Root.GetNode("Main/Camera/MainGui").GetNode<Label>("Resources/Honey");
        woodLabel = GetTree().Root.GetNode("Main/Camera/MainGui").GetNode<Label>("Resources/Wood");
        moveLabel = GetTree().Root.GetNode("Main/Camera/MainGui").GetNode<Label>("MoveLabel");
    }

	public override void _Process(double delta)
	{
		honeyLabel.Text = "Honey: " + Global.mainModel.resources.Honey.ToString();
        woodLabel.Text = "Wood: " + Global.mainModel.resources.Wood.ToString();
		moveLabel.Text = Global.mainModel.Move.ToString();

        var childrens = GetChildren();
	}

}
