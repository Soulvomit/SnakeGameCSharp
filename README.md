# Assignment 4

1. Mockito Powerups:

How do you verify that a mock is called?

Mockito.verify(dependency, Mockito.times(1)).someMockMethod();

How do you verify that a mock is NOT called?

Mockito.verify(dependency, Mockito.times(0)).someMockMethod();
OR
Mockito.verify(dependency, Mockito.never()).someMockMethod();

How do you specify how many times a mockshould have been called?

int x = timesMockShouldBeCalled;
Mockito.verify(dependency, Mockito.times(x)).someMockMethod();

How do you verify the a mock has been called with specific arguments?

if one arg:
Mockito.verify(dependency).someMockMethod(expectedArg);

if multiple args:
Mockito.verify(dependency).someMockMethod(ArgumentMatchers.eq("VALUE_1"), ArgumentMatchers.argThat((x)->false));

How do you use a predicate to verify the properties of the argument given to a call to the mock? 

Mockito.when(dependency).someMockMethod("some id", PredicatesProvider.isUserValid()).thenReturn("something");

2. Snake Game:

KEYS:

W - Turn UP

A - Turn LEFT

S - Turn DOWN

D - Turn RIGHT

SPACE - Pause Game

TAB - Debug Mode

RULES:

Eat apples to accumulate points. If snake is to slow to eat an apple, the player will be deducted in points. Initially set to 10 seconds.

Game Modes: Teleport - teleports when bounds are reached, WallCollision - game ends when bounds are reached.
