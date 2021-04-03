using Godot;
using System;

public class bulletBrain : Node
{
    scenes scenes = new scenes();
    Timer enemySpawner;

    // Difficulty system vars
    public float maxSpawnInterval = 4;
    public float minSpawnInterval = 0.5f;
    public float spawnIntervalDecrease = 0.2f;
    public float spawnInterval = 0;

    public override void _Ready()
    {
        enemySpawner= (Timer)GetNode("enemySpawner");
        spawnInterval = maxSpawnInterval;
    }

    public void increaseDifficulty()
    {
        var newSpawnInterval = spawnInterval - spawnIntervalDecrease;
        newSpawnInterval = Math.Max(newSpawnInterval, minSpawnInterval);
        enemySpawner.WaitTime = newSpawnInterval;
        enemySpawner.Start();
    }

    public void _on_enemySpawner_timeout()
    {
        spawnEnemy();
    }

    public void spawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(Convert.ToSingle(GD.RandRange(0, 1000)), -30);
        Vector2 targetPosition = new Vector2(Convert.ToSingle(GD.RandRange(0, 1000)), 550);
        SpawnBullet(spawnPosition, targetPosition, "enemy");
    }

    public void SpawnBullet(Vector2 spawnPosition, Vector2 targetPosition, string animationName)
    {
        // Instantiate bullet at position and look at target
        var bullet = (bullet)scenes.sceneBullet.Instance();
        GetNode("/root/game/bullets").AddChild(bullet);
        bullet.GlobalPosition = spawnPosition;
        bullet.LookAt(targetPosition);

        // Set animation
        var bulletSprite = (AnimatedSprite)bullet.GetNode("AnimatedSprite");
        bulletSprite.Play(animationName);
    }

    public void spawnExplosion(Vector2 spawnPosition, string animationName)
    {
        // Instantiate explosion at position
        var explosion = (Area2D)scenes.sceneExplosion.Instance();
        GetNode("/root/game/bullets").AddChild(explosion);
        explosion.GlobalPosition = spawnPosition;

        // Set animation
        var explosionSprite = (AnimatedSprite)explosion.GetNode("AnimatedSprite");
        explosionSprite.Play(animationName);
    }

}