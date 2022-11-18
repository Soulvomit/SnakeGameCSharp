Feature: Grow

The snake should grow bigger when it eats an apple.

Scenario: SnakeGrow
	Given there is an apple on the game field
	When the snake eats an apple
		| offset_position   |
		| <offset_position> |
	Then the snake should grow one size larger
Examples: 
	| offset_position |
	| UP              |
	| DOWN            |
	| LEFT            |
	| RIGHT           |

Scenario: SnakeGrowPosition
	Given there is an apple on the game field
	When the snake eats an apple
		| offset_position   |
		| <offset_position> |
	Then the snake should grow at apple offset position
		| offset_position   |
		| <offset_position> |
Examples: 
	| offset_position |
	| UP              |
	| DOWN            |
	| LEFT            |
	| RIGHT           |