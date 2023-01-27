using Godot;

public class Bat : Node2D
{
    [Export]
    public float speed = 100;

    private Vector2 velocity;
    private Vector2 targetPosition;

    public override void _Ready()
    {
        targetPosition = GlobalPosition;
    }

    public override void _Process(float delta)
    {
        // Move towards the target position
        var direction = (targetPosition - GlobalPosition).Normalized();
        velocity = direction * speed;
        Position += velocity * delta;

        // Update the target position every few seconds
        if (Mathf.Round((float)GD.RandRange(0, 100)) < 5)
        {
            targetPosition = new Vector2((float)GD.RandRange(0, 800), (float)GD.RandRange(0, 600));
        }
    }
}
