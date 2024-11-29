using Cosmolapy;
using Cosmolapy.Buildings.Generators;
using Godot;
using System;
using System.Xml;

public partial class GeneratorScene : Control
{
	Generator data;
    Label nameLabel;
    Label changeHoneyLabel;
    Label changeWoodLabel;
    Label changeIronLabel;
    Label changeBiofuelLabel;
    Label levelLabel;
    Label progressLevelLabel;

    public override void _Ready()
	{
        nameLabel = GetNode<Label>("NameLabel");
        changeHoneyLabel = GetNode<Label>("ChangeHoneyLabel");
        changeWoodLabel = GetNode<Label>("ChangeWoodLabel");
        changeIronLabel = GetNode<Label>("ChangeIronLabel");
        changeBiofuelLabel = GetNode<Label>("ChangeBiofuelLabel");
        progressLevelLabel = GetNode<Label>("ProgressLevelLabel");
        levelLabel = GetNode<Label>("LevelLabel");
        data = Global.mainModel.viewGenerator;
    }

	public override void _Process(double delta)
    {
        nameLabel.Text = data.name;
        changeHoneyLabel.Text = "Change honey: " + ((int)data.changeHoney).ToString();
        changeWoodLabel.Text = "Change wood: " + ((int)data.changeWood).ToString();
        changeIronLabel.Text = "Change iron: " + ((int)data.changeIron).ToString();
        changeBiofuelLabel.Text = "Change biofuel: " + ((int)data.changeBiofuel).ToString();
        progressLevelLabel.Text = "Progress level: " + data.ProgressOfLevel.ToString() + "/" + data.NeedProgressOfLevel.ToString();
        levelLabel.Text = "Level: " + ((int)data.Level).ToString();
    }
}
