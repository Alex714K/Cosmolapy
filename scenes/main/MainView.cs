using Cosmolapy;
using Cosmolapy.Buildings.Generators;
using Cosmolapy.scenes.main;
using Godot;
using System;
using System.Collections.Generic;

public partial class MainView : Node2D
{
    GeneratorView sampleGenerator;

    List<GeneratorView> generators;

    bool alreadyShowPopup;

    Popup winPopup;

    public override void _Ready()
    {
        sampleGenerator = GetNode("Camera/MainGui").GetNode<GeneratorView>("Buildings/SampleGenerator");

        winPopup = GetNode("Camera/MainGui").GetNode<Popup>("WinPopupMenu");
        alreadyShowPopup = false;

        generators = new List<GeneratorView>();

        sampleGenerator.SetData(Global.mainModel.generators[Generators.sawmill], new Vector2(-500, 150));

        AddGenerator(Global.mainModel.generators[Generators.sawmill], new Vector2(100, 150));
        AddGenerator(Global.mainModel.generators[Generators.mednica], new Vector2(300, 150));
        AddGenerator(Global.mainModel.generators[Generators.laboratory], new Vector2(500, 150));
        AddGenerator(Global.mainModel.generators[Generators.mine], new Vector2(700, 150));
    }

    private void AddGenerator(Generator data, Vector2 position)
    {
        generators.Add((GeneratorView)sampleGenerator.Duplicate());
        generators[generators.Count - 1].SetData(data, position);
        AddChild(generators[generators.Count - 1]);
    }

    public override void _Process(double delta)
    {

        if (Global.mainModel.rocket.Progress >= Global.mainModel.rocket.NeedProgress && !alreadyShowPopup)
        {
            winPopup.Popup();
            alreadyShowPopup = true;
        }
    }

}
