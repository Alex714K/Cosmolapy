using Cosmolapy;
using Cosmolapy.scenes.researches;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class CellsView : Node
{
    private CellView sampleCell;
    private List<CellView> viewCells;
    private CellsViewModel viewModel;

    Label honeyLabel;

    List<List<int>> maxWidths = new List<List<int>>();

    public override void _Ready()
	{
        viewCells = new List<CellView>();
        sampleCell = GetTree().Root.GetNode("Researches").GetNode<CellView>("Gui/Cells/BaseCell");
        viewModel = new CellsViewModel(FillCells);

        honeyLabel = GetTree().Root.GetNode("Researches").GetNode<Label>("HoneyLabel");

    }
	public override void _Process(double delta)
	{
        honeyLabel.Text = "Honey: " + Global.mainModel.resources.Honey.ToString();
    }
    private void AddCell(Cell cell, Vector2 position)
    {
        viewCells.Add((CellView)sampleCell.Duplicate());
        viewCells[viewCells.Count - 1].SetData(cell, position);

        AddChild(viewCells[viewCells.Count - 1]);
    }

    private void FillCells(Dictionary<string, Cell> modelCells)
    {
        AddCell(modelCells["Rocket"], new Vector2(120, 100));
        AddCell(modelCells["Rocket"].children[0], new Vector2(120 - 60, 200));
        AddCell(modelCells["Rocket"].children[0].children[0], new Vector2(120 - 60, 300));
        AddCell(modelCells["Rocket"].children[1], new Vector2(120 + 60, 200));
        AddCell(modelCells["Rocket"].children[1].children[0], new Vector2(120 + 60, 300));
    }
}
