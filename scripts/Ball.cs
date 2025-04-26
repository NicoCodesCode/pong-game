using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	private Vector2 _velocity = new Vector2(500, 500);

	[Export]
	public Area2D PlayerScoreArea;

	[Export]
	public Area2D ComputerScoreArea;

	public override void _Ready()
	{
		PlayerScoreArea.BodyEntered += OnBodyEntered;
		ComputerScoreArea.BodyEntered += OnBodyEntered;
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
	}
}
