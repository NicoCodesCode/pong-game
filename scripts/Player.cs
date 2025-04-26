using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private float _speed = 400f;

    public override void _PhysicsProcess(double delta)
    {
        float direction = Input.GetAxis("MoveUp", "MoveDown");
        Velocity = new Vector2(0, direction * _speed);
		MoveAndSlide();
    }
}
