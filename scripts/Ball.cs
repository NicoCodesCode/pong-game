using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	[Export]
	public Area2D PlayerScoreArea;
	[Export]
	public Area2D ComputerScoreArea;
	[Export]
	public Timer Timer;
	private Vector2 _speed = Vector2.Zero;
	private Vector2 _direction = new Vector2(1, 1);

	public override void _Ready()
	{
		PlayerScoreArea.BodyEntered += OnBodyEntered;
		ComputerScoreArea.BodyEntered += OnBodyEntered;
		Timer.Timeout += OnTimeout;
	}

    public override void _PhysicsProcess(double delta)
    {
		KinematicCollision2D collision = MoveAndCollide(_direction * _speed * (float)delta);

		if (collision != null)
		{
			_speed = _speed.Bounce(collision.GetNormal());
		}
    }

	private void OnBodyEntered(Node2D body)
	{
		Position = new Vector2(575, 322);
		_speed = Vector2.Zero;
		Timer.Start();
	}

	private void OnTimeout()
	{
		_direction = RandomDirection();
		_speed = new Vector2(600, 600);
	}

	private Vector2 RandomDirection()
	{
		Random rnd = new Random();

		int[] directions = [1, -1];
        var newDirection = new Vector2
        (
            directions[rnd.Next(directions.Length)],
            directions[rnd.Next(directions.Length)]
		);

        return newDirection.Normalized();
	}
}
