using Godot;
using System;

public partial class ComputerScoreArea : Area2D
{
	[Export] 
	public Label PlayerScoreLabel;

	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		var currentScore = int.Parse(PlayerScoreLabel.Text);
		currentScore += 1;
		PlayerScoreLabel.Text = currentScore.ToString();
	}
}
