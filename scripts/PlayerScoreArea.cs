using Godot;
using System;

public partial class PlayerScoreArea : Area2D
{
	[Export] 
	public Label ComputerScoreLabel;

	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		var currentScore = int.Parse(ComputerScoreLabel.Text);
		currentScore += 1;
		ComputerScoreLabel.Text = currentScore.ToString();
	}
}
