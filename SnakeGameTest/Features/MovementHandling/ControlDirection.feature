Feature: ControlDirection
The player can control the direction of the snake.

Scenario: ControlDirection
	Given the game is running
	When a new direction is detected
			| direction   |
			| <direction> |
	Then update the direction of snake to the new direction
			| direction   |
			| <direction> |
Examples: 
	| direction |
	| UP        |
	| DOWN      |
	| LEFT      |
	| RIGHT     |