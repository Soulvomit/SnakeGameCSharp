Feature: GenerateApple

The game must generate 1 apple when there is no apple present on the game field. 

Scenario: GenerateInitialApple
	Given a new game has started
	When the game initializes
	Then generate one apple within the bounds of the game field

Scenario: GenerateNewApple
	Given the snake eats the apple
	When the game updates apple position
	Then generate one apple within the bounds of the game field