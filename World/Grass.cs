using Godot;
using System;

public class Grass : Node2D
{

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
      if (Input.IsActionJustPressed("attack")) {
            PackedScene GrassEffect = (PackedScene)ResourceLoader.Load("res://Effects/GrassEffect.tscn");
	        Node2D grassEffect = (Node2D)GrassEffect.Instance();
	        Node world = GetTree().CurrentScene;
	        world.AddChild(grassEffect);
	        grassEffect.GlobalPosition = GlobalPosition;
            QueueFree();
      }
    }
}
