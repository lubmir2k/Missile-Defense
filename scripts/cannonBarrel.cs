using Godot;
using System;

public class cannonBarrel : Sprite
{
    bulletBrain bulletBrain;
    scenes scenes = new scenes();
    player player;

    public override void _Ready()
    {
        bulletBrain = (bulletBrain)GetNode("/root/game/bullets/bulletBrain");
        player = (player)GetNode("/root/game/player");
    }

    public override void _Input(InputEvent inputEvent)
    {
        if(inputEvent.IsActionPressed("click") && (player.canShoot == true))
        {
            shootAtMouse();
        }
    }

    public void shootAtMouse()
    {
        bulletBrain.SpawnBullet(GlobalPosition, GetGlobalMousePosition(), "player");
        player.canShoot = false;

        var bulletStopper = (Area2D)scenes.sceneBulletStopper.Instance();
        GetNode("/root/game/bullets").AddChild(bulletStopper);
        bulletStopper.GlobalPosition = GetGlobalMousePosition();
    }

    public override void _Process(float delta)
    {
        LookAt(GetGlobalMousePosition());
    }
}
