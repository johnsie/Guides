# Design Patterns

### What is this document?

This is a guide that I'm writing as I study different design patterns.  I intend discussing how each design pattern works, why it is used and showing some code implementations of each in PHP, C# and Java.  I will explain how I created each implementation. The purpose is to help anyone who reads it learn about different ways to implement the patterns and to help me understand the concepts in such a way that I can use or explain them better. I'm writing this as I go along with my learning so  will be checking updates in periodically. For this reason there may be times when it may not appear complete. Please feel free to add comments, suggests or correction as issues here on github and I will do my best to address them in a timely manner.

[Click to see my Github project for this guide](https://github.com/users/johnsie/projects/4/)

## Simple Factory Pattern 

A simple factory pattern utilises a class that has single method which decides what type of class to instantiate and return. 

### Php implementaion of a factory class
```
class AnimalFactory {
    public static function create($animalType) {
        switch ($animalType) {
            case 'dog': return new Dog();
            case 'cat': return new Cat();
            case 'giraffe': return new Giraffe();
            case 'cow': return new Cow();

            default:
                throw new Exception('Unknown animal type supplied');
        }
    }
}
```

The factory class above will create a type of animal class depending on which $animalType was requested.



### C# Implementation of this design pattern using an interface and a factory class

[Click for full C# Implementation](Design-Patterns-0001-Simple-Factory.cs)

Create a an enum object which defines the types of animals available
```
enum AnimalType
{
    Dog,
    Cat,
    Giraffe,
	Cow
}
```

Create the interface IAnimal which dictates that the Speak action be implemented for each  animal
```
interface IAnimal
{
    void Speak();
    
}
```

Create C# classes for each type of Animal, that implements IAnimal
```
class Dog : IAnimal {.... }

class Cat : IAnimal {.... }

class Giraffe : IAnimal {..... }

class Cow :  IAnimal {..... }

```

Create a the C#  version of the AnimalFactory class. This will create the appropriate class depending on what is supplies to it.
```
interface IAnimalFactory
{
    IAnimal CreateAnimal(AnimalType type);
}

```
The Factory class should implment the Interface above

```
class AnimalFactory : IAnimalFactory
{
    public IAnimal CreateAnimal(AnimalType type)
    {
        switch (type)
        {
            case AnimalType.Dog:
                return new Dog();
            case AnimalType.Cat:
                return new Cat();
            case AnimalType.Giraffe:
                return new Giraffe();
				
				  case AnimalType.Cow:
                return new Cow();
            default:
			    //No valid animal type has been defined so return a dog
                return new Dog();
        }
    }
}
```

To use the Factory:
```
static void Main(string[] args)
{
        IAnimalFactory simpleFactory = new AnimalFactory();
        // Creation of an animal using Simple Factory
		//We're going to create a cat
        IAnimal animal = simpleFactory.CreateAnimal(AnimalType.Cat);
        // Use created object
        animal.Speak();

        Console.ReadLine();
 }
```




## Factory Method Pattern 

Wikipedia defines a factory pattern as:

> a [creational pattern](https://en.wikipedia.org/wiki/Creational_pattern "Creational pattern") that uses factory methods to deal with the problem of [creating objects](https://en.wikipedia.org/wiki/Object_creation "Object creation") without having to specify the exact [class](https://en.wikipedia.org/wiki/Class_(computer_programming) "Class (computer programming)") of the object that will be created. This is done by creating objects by calling a factory method—either specified in an [interface](https://en.wikipedia.org/wiki/Interface_(object-oriented_programming) "Interface (object-oriented programming)") and implemented by child classes, or implemented in a base class and optionally [overridden](https://en.wikipedia.org/wiki/Method_overriding "Method overriding") by derived classes—rather than by calling a [constructor](https://en.wikipedia.org/wiki/Constructor_(object-oriented_programming) "Constructor (object-oriented programming)").

As suggested above there are two ways of implementing this design pattern. One way uses an abstract class and override methods, and the other uses an interface which defines the method. In this guide I'm going to attempt implementing it both ways wherever possible.

I will continue with my animal analogy, but this time I will be giving different homes to the animals we create. Eg. Zoo, Human Home, Farm 

## C# implementation of Factory Method design pattern using abstract classes 

[Click for full C# Implementation](Design-Patterns-0002-Factory-Method-with-abstract-class.cs)

I'm taking a break now, but later will the explain how I created my implementation and how it works.




For more guides like this please see https://johnmccourt.com 
 
