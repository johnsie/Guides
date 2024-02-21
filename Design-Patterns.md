# Design Patterns

### What is this document?

This is a guide that I'm writing as I study different design patterns.  I intend discussing how each design pattern works, why it is used and showing some code implementations of each in PHP, C# and Java.  I will explain how I created each implementation. The purpose is to help anyone who reads it learn about different ways to implement the patterns and to help me understand the concepts in such a way that I can use or explain them better. I'm writing this as I go along with my learning so  will be checking updates in periodically. For this reason there may be times when it may not appear complete. Please feel free to add comments, suggestions or corrections as issues here on github and I will do my best to address them in a timely manner.

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



### C# Implementation of Simple Factory design pattern using an interface and a factory class

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

For this design pattern it's probably imporant that you know what concrete and abstract classes are

### Concrete Class
Wikipedia:
 A class that can be instantiated and may have concrete methods. 

Microsoft Learn describes this as:
A class that allows creating an instance or an object using the new keyword. A concrete method is a method that can be called directly

 ### Abtract Class
 Wikipedia:? 
 (object-oriented programming) A class that cannot be instantiated and may have abstract method.

Microsoft Learn:
The abstract keyword enables you to create classes and class members that are incomplete and must be implemented in a derived class.

So put basically, a abstract class can be a class that defines which methods need to be used by any of its subclassess.

Below is code that where an abstract class is definited and  a concrete class implements it.

```
public abstract class Animal      //abstract type  
    {  
        public abstract void Talk();      //abstract method  
        public abstract void Move();   //abstract method  
    }  
  
    public class Dog : Animal  //Concrete type  
    {  
        public override void Talk()  //Concrete method  
        {  
            Console.WriteLine("This blog post is awesome! :)");  
        }  
  
        public override void Move()  
        {  
            Console.WriteLine("I'm walking on 2 feet.");  
        }  
    }  

```

### C# implementation of Factory Method design pattern using abstract classes 

[Click for full C# Implementation](Design-Patterns-0002-Factory-Method-with-abstract-class.cs)


Create the abract class that every Concrete (type of "Animal" class) class will need to implement
```

 
    
    /// <summary>
    /// The 'Product' abstract class
    /// </summary>
    abstract class Animal
    {
    }

```
Create each of the "Concrete" classes. The factory methods will be responsible for instantiating these
``` 
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class Dog : Animal
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class Cat : Animal
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class Giraffe : Animal
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class Cow : Animal
    {
    }

```
Create an abstract class that 'concrete creator' factory classes will implement to actually create the concrete animal classes
Each concrete creator will need to have a method that creates instances of the concrete classes. 
```
    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    abstract class AnimalHome
    {
        private List<Animal> _animals = new List<Animal>();
        // Constructor calls abstract Factory method
        public AnimalHome()
        {
            this.CreateAnimals();
        }
        public List<Animal> Animals
        {
            get { return _animals; }
        }
        // Factory Method
        public abstract void CreateAnimals();
    }


```
The ConcreteCreator classes need to implement the methods which create animals. We've got three here, one for Zoo, one for House and the other for farm. They are expected to create the type of Animal that would be in each type of home.
```

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class Zoo : AnimalHome
    {
        // Factory Method implementation
        public override void CreateAnimals()
        {
            Animals.Add(new Giraffe());

        }
    }
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class House : AnimalHome
    {
        // Factory Method implementation
        public override void CreateAnimals()
        {
            Animals.Add(new Cat());
            Animals.Add(new Dog());
            Animals.Add(new Dog());
            Animals.Add(new Dog());

        }

    }
	
	/// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
        class Farm : AnimalHome
        {
            // Factory Method implementation
            public override void CreateAnimals()
            {
                Animals.Add(new Cow());


            }


        }
```

Add the Main App class that utilise the Factory Method to create the animal homes and animals

```

 /// <summary>
    /// MainApp startup class for Real-World 
    /// Factory Method Design Pattern.
    /// </summary>
class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Note: constructors call Factory Method
            AnimalHome[] homes = new AnimalHome[3];
            homes[0] = new Zoo();
            homes[1] = new House();
            homes[2] = new Farm();
      
            // Display document pages
            foreach (AnimalHome home in homes)
            {
                Console.WriteLine("\n-------" + home.GetType().Name + "------");
                foreach (Animal animal in home.Animals)
                {
                    Console.WriteLine(" " + animal.GetType().Name);
                }
            }
            // Wait for user
            Console.ReadKey();
        }
    }

```

So there we have it.   The main void will instantiate three animal homes which will then go on to instantiate a number of (concrete) animals which are specific to that type of home. The foreach method proves this by listing each of the animals created by each home.



## Abstract Factory Design Pattern

Wikipedia defines the Abstract Factory design pattern as "one which that provides a way to create families of related objects without imposing their concrete classes, by encapsulating a group of individual factories that have a common theme without specifying their concrete classes."

Some other developers that I've spoken to call it a "factory of factories" which provides an interface for creatin families of related or dependent objects without specifying their concrete classes.


For more guides like this please see https://johnmccourt.com 
 
