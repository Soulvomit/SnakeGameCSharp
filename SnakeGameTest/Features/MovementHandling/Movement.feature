Feature: Movement
The game moves the snake head one position each update cycle.

Scenario: SnakeMovement
	Given the game is running 
	When an update cycle has happened
	Then snake head should move one position in the current direction
			| direction   |
			| <direction> |
Examples: 
	| direction |
	| UP        |
	| DOWN      |
	| LEFT      |
	| RIGHT     |