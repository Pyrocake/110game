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
        float distance = (targetPosition - GlobalPosition).Length();
        float desiredSpeed = speed * distance / 100;
        velocity = direction * desiredSpeed;

        //velocity = direction * speed;
        

        if (distance > 50)
        {
            Position += velocity * delta;
        }


        // Update the target position every few seconds
        if (Mathf.Round((float)GD.RandRange(0, 100)) < 10)
        {
            targetPosition = GlobalPosition + Vector2.Right.Rotated(GD.Randf() * Mathf.Pi * 2) * (GD.Randf()*100);
            speed += (GD.Randf()-0.5f) * 2f;

        }
    }
}
