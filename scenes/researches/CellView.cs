using Cosmolapy.scenes;
using Cosmolapy.scenes.researches;
using Godot;
using System;

public partial class CellView : Button
{
	private Cell cellData;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += buttonPressed;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (cellData != null)
		{
            Text = cellData.data.name + "\n" + "Price: " + cellData.data.priceHoney.ToString() + "\n" + "Status: ";
            if (cellData.data.isDone)
			{
                Text += "true";
            }
			else
			{
				Text += "false";
			}
		}
	}

    public void buttonPressed()
    {
        if (Global.mainModel.resources.Honey >= cellData.data.priceHoney)
		{
			cellData.data.isDone = true;
		}
    }

    public void SetData(Cell _cellData, Vector2 position)
	{
        cellData = _cellData;
		Position = position;
		Text = cellData.data.name +  "\n" + "Price: " + cellData.data.priceHoney.ToString() + "\n" + "Status: ";
	}
}
