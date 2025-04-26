using Godot;
using System;
public partial class Computer : CharacterBody2D
{
    [Export]
    public CharacterBody2D Ball;
    private int _speed = 400;
    private const int _centerX = 575;
    private const float _centerY = 322f;
    private float _prevBallPosition = _centerY;
    
    public override void _PhysicsProcess(double delta)
    {
        if (Ball.Position.X >= _centerX)
        {
            if (Ball.Position.Y > _prevBallPosition)
            {
                Velocity = new Vector2(0, _speed);
            }
            else if (Ball.Position.Y < _prevBallPosition)
            {
                Velocity = new Vector2(0, -_speed);
            }
            else
            {
                Velocity = Vector2.Zero;
            }

            MoveAndSlide();
        }
        else
        {
            Velocity = Vector2.Zero;
        }

        _prevBallPosition = Ball.Position.Y;
    }
}