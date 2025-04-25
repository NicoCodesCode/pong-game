using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private int _speed = 400;
	
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Vector2 position = Position;
		int direction = 0;

		if (Input.IsActionPressed("MoveUp"))
		{
			direction = -1;
		}

		if (Input.IsActionPressed("MoveDown"))
		{
			direction = 1;
		}

		position.Y += _speed * (float)delta * direction;
		Position = position;
	}
}
