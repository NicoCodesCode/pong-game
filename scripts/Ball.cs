using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	private Vector2 _velocity = new Vector2(400, 400);

  public override void _PhysicsProcess(double delta)
  {
		KinematicCollision2D collision = MoveAndCollide(_velocity * (float)delta);

		if (collision != null)
		{
			_velocity = _velocity.Bounce(collision.GetNormal());
		}
  }
}
