using Cosmolapy.scenes.main;
using Godot;
using System;

public partial class MainView : Node2D
{
	Label honeyLabel;
	Label woodLabel;
	MainViewModel viewModel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        honeyLabel = GetTree().Root.GetNode("Main/MainGui").GetNode<Label>("Resources/Honey");
        woodLabel = GetTree().Root.GetNode("Main/MainGui").GetNode<Label>("Resources/Wood");
		viewModel = new MainViewModel(SetHoneyLabel, SetWoodLabel);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	void SetHoneyLabel(int newValue)
	{
		honeyLabel.Text = "Honey: " + newValue.ToString();
	}
    void SetWoodLabel(int newValue)
    {
        woodLabel.Text = "Wood: " + newValue.ToString();
    }

}
