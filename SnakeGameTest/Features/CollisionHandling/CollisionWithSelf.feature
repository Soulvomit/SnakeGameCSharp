Feature: CollisionWithSelf

The snake head collides with the snakes own body.

Scenario: CollisionWithSelf
	Given the game is running
	When the snake collides with its own body
	Then the game should end