using Cosmolapy.scenes.main;
using Godot;
using System;

public partial class MainView : Node2D
{
	Label honeyLabel;
	MainViewModel viewModel;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        GD.Print("lol");
        honeyLabel = GetTree().Root.GetNode("Main/MainGui").GetNode<Label>("Honey");
        GD.Print("lalka");
		viewModel = new MainViewModel(SetHoneyLabel);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	void SetHoneyLabel(int newValue)
	{
		honeyLabel.Text = "Honey: " + newValue.ToString();
	}

}
