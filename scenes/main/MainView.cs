using Cosmolapy.scenes;
using Cosmolapy.scenes.main;
using Godot;
using System;

public partial class MainView : Node2D
{
	Label honeyLabel;
	Label woodLabel;
	//ainViewModel viewModel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        honeyLabel = GetTree().Root.GetNode("Main/Camera/MainGui").GetNode<Label>("Resources/Honey");
        woodLabel = GetTree().Root.GetNode("Main/Camera/MainGui").GetNode<Label>("Resources/Wood");
		// viewModel = new MainViewModel();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		honeyLabel.Text = "Honey: " + Global.mainModel.resources.Honey.ToString();
        woodLabel.Text = "Wood: " + Global.mainModel.resources.Wood.ToString();

        var childrens = GetChildren();
	}

}
