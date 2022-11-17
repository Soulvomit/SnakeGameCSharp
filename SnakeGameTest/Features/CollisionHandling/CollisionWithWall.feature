Feature: CollisionWithWall

Handle what happens when the snake head collides with wall.

Scenario: CollisionWithWallNoTeleport
	Given the game is running with teleportation disallowed
	When the snake collides with the wall
		| wall   |
		| <wall> |
	Then the game should be terminated
Examples: 
	| wall   |
	| RIGHT  |
	| LEFT   |
	| TOP    |
	| BUTTOM |

Scenario: CollisionWithWallTeleport
	Given the game is running with teleportation allowed
	When the snake collides with the wall
		| wall   |
		| <wall> |
	Then the snake should be teleported to the other side of the game field
Examples: 
	| wall   |
	| RIGHT  |
	| LEFT   |
	| TOP    |
	| BUTTOM |