using Godot;
using System;

public class GrassEffect : Node2D
{
    public AnimatedSprite animatedSprite = null;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animatedSprite = (AnimatedSprite)GetNode("AnimatedSprite");
        animatedSprite.Frame = 0;
        animatedSprite.Play("Animate");
    }

    public void onAnimatedSpriteFinished() {
        QueueFree();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
