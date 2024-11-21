using Cosmolapy.scenes.researches;
using Godot;
using System;

public partial class CellView : Button
{
	private Cell cellData;

	public Cell CellData
	{
		set { cellData = value; }
		get { return cellData; }
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetData(Cell _cellData, Vector2 position)
	{
		CellData = _cellData;
		Position = position;
		Text = cellData.data.name +  "\n" + "Price: " + cellData.data.priceHoney.ToString();
	}
}
