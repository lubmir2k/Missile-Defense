using Godot;
using System;

public class cloud : AnimatedSprite
{
    public int speed = 400;
    Vector2 velocity = new Vector2(0, 0);

    public override void _Process(float delta)
    {
        velocity = Vector2.Right.Rotated(this.Rotation) * speed * delta;
        Translate(velocity);
    }

    public override void _Ready()
    {
        speed = Convert.ToInt32(GD.RandRange(200, 300));
    }
}
