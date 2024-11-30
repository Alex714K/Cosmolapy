using Cosmolapy.Cards;
using Godot;
using System;

public partial class CardView : Control
{
	Label nameLabel;
	Label honeyPriceLabel;
	Label woodPriceLabel;
	Label ironPriceLabel;
	Label biofuelPriceLabel;
	Button useButton;

	Card data;

	public override void _Ready()
	{
		nameLabel = GetNode<Label>("NameLabel");
        honeyPriceLabel = GetNode<Label>("HoneyPriceLabel");
        woodPriceLabel = GetNode<Label>("WoodPriceLabel");
        ironPriceLabel = GetNode<Label>("IronPriceLabel");
        biofuelPriceLabel = GetNode<Label>("BiofuelPriceLabel");
        useButton = GetNode<Button>("UseButton");
		useButton.Pressed += useButtonPressed;
    }

	internal void SetData(Card _data)
	{
		data = _data;
	}

	public override void _Process(double delta)
	{
		nameLabel.Text = data.Name;
		honeyPriceLabel.Text = "Honey: " + data.HoneyPrice.ToString();
		woodPriceLabel.Text = "Wood: " + data.WoodPrice.ToString();
		ironPriceLabel.Text = "Iron: " + data.IronPrice.ToString();
		biofuelPriceLabel.Text = "Biofuel: " + data.BiofuelPrice.ToString();
	}

	public void useButtonPressed()
	{
		data.Use();
	}

}
