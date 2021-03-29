using Godot;
using System;

public class scenes : Node
{
    public PackedScene sceneBullet = (PackedScene)GD.Load("res://prefabs/bullet.tscn");
    public PackedScene sceneExplosion = (PackedScene)GD.Load("res://prefabs/explosion.tscn");
    public PackedScene sceneBulletStopper = (PackedScene)GD.Load("res://prefabs/bulletStopper.tscn");
}
