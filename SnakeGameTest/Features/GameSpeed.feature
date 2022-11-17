Feature: GameSpeed

The speed of the game will increase or decrease based on the current points of the player.

Scenario: GameSpeedIncrease
	Given points are added to the player total
	And point threshold is reached
	When the game updates game speed	
	Then the game will increase in speed

Scenario: GameSpeedDecrease
	Given points are subtracted from the player total
	And point threshold is reached
	When the game updates game speed
	Then the game will decrease in speed