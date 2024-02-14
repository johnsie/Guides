# Design Patterns

### What is this document?

This is a guide that I'm writing as I study different design patterns.  I intend discussing how each design pattern works, why it is used and showing some code implementations of each in PHP, C# and Java.  I will explain how I created each implementation. The purpose is to help anyone who reads it learn about different ways to implement the patterns and to help me understand the concepts in such a way that I can use or explain them better. I'm witing this as I go along with my learning so  will be checking updates periodically. For this reason there ma be times when it may not appear complete.

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



For more guides like this please see https://johnmccourt.com 
 
