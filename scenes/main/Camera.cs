using Godot;
using System;

public partial class Camera : Camera2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("right") && Position.X < 343)
        {
            Position += new Vector2(4, 0);
        }
        if (Input.IsActionPressed("left") && Position.X > 1)
        {
            Position += new Vector2(-4, 0);
        }


    }
}