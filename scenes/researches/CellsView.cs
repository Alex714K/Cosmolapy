using Cosmolapy.scenes.researches;
using Godot;
using System;
using System.Collections.Generic;

public partial class CellsView : Node
{
    private CellView sampleCell;
    private List<CellView> viewCells;
    private CellsViewModel viewModel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        viewCells = new List<CellView>();
        sampleCell = GetTree().Root.GetNode("Researches").GetNode<CellView>("Gui/Cells/BaseCell");
        viewModel = new CellsViewModel(FillCells);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    private void AddCell()
    {

    }

    private void FillCells(List<Cell> modelCells)
    {
        viewCells.Add((CellView)sampleCell.Duplicate());
        viewCells[viewCells.Count - 1].SetData(modelCells[viewCells.Count - 1], new Vector2(100, 100));

        AddChild(viewCells[viewCells.Count - 1]);
    }
}
