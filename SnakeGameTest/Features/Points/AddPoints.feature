Feature: AddPoints

The player will be awarded points when an apple is eaten, based on game speed and current snake length.

Scenario: AddPoints
	Given the snake eats an apple
	When the player is awarded points
	Then the player will be awarded points

Scenario: PointAmountAdded
	Given the snake eats an apple
	When the player is awarded points
	Then the point amount should be speed times length
