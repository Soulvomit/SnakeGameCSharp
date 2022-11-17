Feature: SubtractPoints

The player will be subtracted points if it takes to long to eat an apple.

Scenario: SubtractPoints
	Given the player has points
	When the player is to slow to eat an apple
	Then subtract points from the player
