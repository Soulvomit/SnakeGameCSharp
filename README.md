# Assignment 4

1. Mockito Powerups:

How do you verify that a mock is called?

Mockito.verify(dependency, Mockito.times(1)).someMockMethod()

How do you verify that a mock is NOT called?

Mockito.verify(dependency, Mockito.times(0)).someMockMethod()
OR
Mockito.verify(dependency, Mockito.never()).someMockMethod()

How do you specify how many times a mockshould have been called?

int x = timesMockShouldBeCalled
Mockito.verify(dependency, Mockito.times(x)).someMockMethod()

How do you verify the a mock has been called with specific arguments?



How do you use a predicate to verify the properties of the argument given to a call to the mock? 


