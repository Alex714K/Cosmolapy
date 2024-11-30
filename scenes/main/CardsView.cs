using Cosmolapy;
using Cosmolapy.Cards;
using Godot;
using System;
using System.Collections.Generic;

public partial class CardsView : Control
{
	//ListOfCards cardModels;
	List<CardView> cardViewes;
	CardView sampleCardView;

	public override void _Ready()
	{
        //cardModels = new ListOfCards();
        cardViewes = new List<CardView>();
        sampleCardView = GetNode<CardView>("SampleCard");
		sampleCardView.SetData(Global.mainModel.cardModels.cards[0]);
        FillCards();
    }

	public void FillCards()
	{
        for (int i = 0; i < Global.mainModel.cardModels.cards.Count; i++)
        {
			cardViewes.Add((CardView)sampleCardView.Duplicate());
			cardViewes[i].SetData(Global.mainModel.cardModels.cards[i]);
			cardViewes[i].Position = new Vector2(i * 130, 530);
			AddChild(cardViewes[i]);
		}
    }

	public void Update()
	{
        Global.mainModel.cardModels.Update();
		for (int i = 0; i < cardViewes.Count; i++)
		{
			GetChild(i + 1).QueueFree();
		}
		cardViewes.Clear();
		FillCards();
	}

	public override void _Process(double delta)
	{
	}
}
