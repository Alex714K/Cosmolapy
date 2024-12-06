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

    List<List<int>> maxWidths = new List<List<int>>();

    public override void _Ready()
	{
        viewCells = new List<CellView>();
        sampleCell = GetTree().Root.GetNode("Researches").GetNode<CellView>("Gui/Cells/BaseCell");
        viewModel = new CellsViewModel(FillCells);

    }
	public override void _Process(double delta)
	{
    }
    private void AddCell(Cell cell, Vector2 position)
    {
        viewCells.Add((CellView)sampleCell.Duplicate());
        viewCells[viewCells.Count - 1].SetData(cell, position);

        AddChild(viewCells[viewCells.Count - 1]);
    }

    private void FillCells(Dictionary<Reseraches, Cell> modelCells)
    {
        AddCell(modelCells[Reseraches.Cards], new Vector2(120, 100));
        AddCell(modelCells[Reseraches.Cards].children[0], new Vector2(120, 200));
        AddCell(modelCells[Reseraches.Cards].children[0].children[0], new Vector2(120, 300));

        AddCell(modelCells[Reseraches.Cheap], new Vector2(300, 100));
        AddCell(modelCells[Reseraches.Cheap].children[0], new Vector2(300, 200));
    }
}
