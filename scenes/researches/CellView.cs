using Cosmolapy;
using Cosmolapy.scenes.researches;
using Godot;
using System;

public partial class CellView : Button
{
	private Cell cellData;
	private Action setDone;

	public override void _Ready()
	{
		Pressed += buttonPressed;
    }

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
        if (Global.mainModel.resources.Honey >= cellData.data.priceHoney && !cellData.data.isDone && cellData.parentDone)
		{
			cellData.setDone();
			Global.mainModel.resources.Honey -= cellData.data.priceHoney;
		}
    }

    public void SetData(Cell _cellData, Vector2 position)
	{
        cellData = _cellData;
		Position = position;
		Text = cellData.data.name +  "\n" + "Price: " + cellData.data.priceHoney.ToString() + "\n" + "Status: ";
	}
}
