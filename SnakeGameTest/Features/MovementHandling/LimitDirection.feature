Feature: LimitDirection

Limit direction to 45 degree turns

@tag1
Scenario: LimitDirection
	Given the game is running
	When the snake tries to turn
		| direction   |
		| <direction> |
	Then limit turn if it is invalid
		| direction   | invalid   |
		| <direction> | <invalid> |
Examples:
	| direction | invalid |
	| UP        | DOWN    |
	| DOWN      | UP      |
	| LEFT      | RIGHT   |
	| RIGHT     | LEFT    |