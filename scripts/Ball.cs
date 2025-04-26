using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	private Vector2 _velocity = Vector2.Zero;

	[Export]
	public Area2D PlayerScoreArea;

	[Export]
	public Area2D ComputerScoreArea;

	[Export]
	public Timer Timer;

	public override void _Ready()
	{
		PlayerScoreArea.BodyEntered += OnBodyEntered;
		ComputerScoreArea.BodyEntered += OnBodyEntered;
		Timer.Timeout += OnTimeout;
	}

    public override void _PhysicsProcess(double delta)
    {
		KinematicCollision2D collision = MoveAndCollide(_velocity * (float)delta);

		if (collision != null)
		{
			_velocity = _velocity.Bounce(collision.GetNormal());
		}
    }

	private void OnBodyEntered(Node2D body)
	{
		Position = new Vector2(575, 322);
		_velocity = Vector2.Zero;
		Timer.Start();
	}

	private void OnTimeout()
	{
		_velocity = new Vector2(500, 500);
	}
}
