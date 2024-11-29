using Cosmolapy;
using Cosmolapy.Buildings.Generators;
using Cosmolapy.scenes.main;
using Godot;
using System;
using System.Collections.Generic;

public partial class MainView : Node2D
{
	// Resources
	Label honeyLabel;
	Label woodLabel;
	Label ironLabel;
	Label biofuelLabel;

	Label moveLabel;

	GeneratorView sampleGenerator;

	List<GeneratorView> generators;

	public override void _Ready()
	{
        honeyLabel = GetTree().Root.GetNode("Main/Camera/MainGui").GetNode<Label>("Resources/HoneyLabel");
        woodLabel = GetTree().Root.GetNode("Main/Camera/MainGui").GetNode<Label>("Resources/WoodLabel");
        ironLabel = GetTree().Root.GetNode("Main/Camera/MainGui").GetNode<Label>("Resources/IronLabel");
        biofuelLabel = GetTree().Root.GetNode("Main/Camera/MainGui").GetNode<Label>("Resources/BiofuelLabel");

        moveLabel = GetTree().Root.GetNode("Main/Camera/MainGui").GetNode<Label>("MoveLabel");
        sampleGenerator = GetTree().Root.GetNode("Main/Camera/MainGui").GetNode<GeneratorView>("Buildings/SampleGenerator");

		generators = new List<GeneratorView>();

		sampleGenerator.SetData(Global.mainModel.sawmill, new Vector2(-500, 150));

		AddGenerator(Global.mainModel.sawmill, new Vector2(100, 150));
		AddGenerator(Global.mainModel.mednica, new Vector2(300, 150));
    }

	private void AddGenerator(Generator data, Vector2 position)
	{
        generators.Add((GeneratorView)sampleGenerator.Duplicate());
        generators[generators.Count - 1].SetData(data, position);
		AddChild(generators[generators.Count - 1]);
    }

	public override void _Process(double delta)
	{
		honeyLabel.Text = "Honey: " + Global.mainModel.resources.Honey.ToString();
		woodLabel.Text = "Wood: " + Global.mainModel.resources.Wood.ToString();
		ironLabel.Text = "Iron: " + Global.mainModel.resources.Iron.ToString();
        biofuelLabel.Text = "Biofuel: " + Global.mainModel.resources.BioFuel.ToString();

		moveLabel.Text = Global.mainModel.Move.ToString();
	}

}
