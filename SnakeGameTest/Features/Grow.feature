Feature: Grow

The snake should grow bigger when it eats an apple.

Scenario: SnakeGrow
	Given there is an apple on the game field
	When the snake eats an apple
	Then the snake should grow one size larger

Scenario: SnakeGrowPosition
	Given there is an apple on the game field
	When the snake eats an apple
	Then the snake should grow at apple offest position 