# Design Patterns

### What is this document?

This is a guide that I'm writing as I study different design patterns.  I intend discussing how each design pattern works, why it is used and showing some code implementations of each in PHP, C# and Java.  I will explain how I created each implementation. The purpose is to help anyone who reads it learn about different ways to implement the patterns and to help me understand the concepts in such a way that I can use or explain them better. I'm writing this as I go along with my learning so  will be checking updates in periodically. For this reason there may be times when it may not appear complete. Please feel free to add comments, suggestions or corrections as issues here on github and I will do my best to address them in a timely manner.

[Click to see my Github project for this guide](https://github.com/users/johnsie/projects/4/)

### Patterns being covered

The following definitions are heavily summarised. Please use them only to help remember what separates the different patterns. More detailed definitions, explanations and implementations will be discussed later.

1. **Simple Factory Pattern** - Utilises a class that has a single method for deciding which type of class to instantiate 

2. **Factory Method Pattern** - Provides an interface/abstract class for creating objects. A factory implements/entends that.  Allows subclasses (factories) to decide which concrete class to instantiate

3. **Abstract Factory Method** - Factory of factories. Contains abstact & concrete factories  as well as abstract & concrete products




 Object Pool
Avoid expensive acquisition and release of resources by recycling objects that are no longer in use


 Prototype
A fully initialized instance to be copied or cloned


Singleton
A class of which only a single instance can exist





 Structural design patterns
These design patterns are all about Class and Object composition. Structural class-creation patterns use inheritance to compose interfaces. Structural object-patterns define ways to compose objects to obtain new functionality.


 Adapter
Match interfaces of different classes


 Bridge
Separates an object’s interface from its implementation


Composite
A tree structure of simple and composite objects


Decorator
Add responsibilities to objects dynamically


 Facade
A single class that represents an entire subsystem


 Flyweight
A fine-grained instance used for efficient sharing

Private Class Data
Restricts accessor/mutator access

Proxy
An object representing another object



Behavioral design patterns
These design patterns are all about Class's objects communication. Behavioral patterns are those patterns that are most specifically concerned with communication between objects.


Chain of responsibility
A way of passing a request between a chain of objects

 Command
Encapsulate a command request as an object

 Interpreter
A way to include language elements in a program

Iterator
Sequentially access the elements of a collection

Mediator
Defines simplified communication between classes

Memento
Capture and restore an object's internal state

Null Object
Designed to act as a default value of an object

 Observer
A way of notifying change to a number of classes

State
Alter an object's behavior when its state changes

Strategy
Encapsulates an algorithm inside a class

Template method
Defer the exact steps of an algorithm to a subclass

 Visitor
Defines a new operation to a class without change













## Solid Design Principles

It's probably a good idea to learn these before jumping into design patterns. These are the principles promoted by Robert C. Martin and form the acronym SOLID.


**Single Responsibility** - Any particular  class should just have a single reason to change. A class should only have one type of job to do

An example is that if one class could be used to manage entries in a list (add/remove). Then a second class would be created to be repsonsible for giving that list persistence. This would prevent one class having to have too many responsibilities.


**Open-Closed Principle** - Parts of a system should be open for extension, but closed for modifcation

This prevents  situations in which a change to one of your classes also requires you to adapt all depending clases. 

It's claimed that Robert C. Martin  initially proposed to use inheritance to achieve this goal.  Later on he and others redefined it to the "Polymorphic Open/Closed Principle" and decided to use interfaces to achieve it.  Interfaces are closed for modification, but you can provide new implmentations in order to extend functionality of software. Implementations of an interface are independent of each other and don't need to share code.

An interface could have a method buildBurger(). And then two different classes can implement it. One of those classes could build a chicken buger and the other one could build a beef burger. Both classes would work differently, but they still need to implement a method called buidBurger(). I would be possible to add new burger types without ever having to change the interface. 


**Liskov Substitution Principle** - You should be able to substitute a base type with a sub type or vice-versa. Subtypes must be substitutable for their base type.

An example of this could be having an Rectangle class and then a Square class that implements rectangle.  You have to set the two dimensions of a rectangle, but not with a square.  If the Square class forces all sides of the shape to be the same size then it might not work properly for a rectangle with different length and width.


 in C# the type can be interface, class, or abstract class


**Interface Segregation Principle** - Clients should not be forced to depend on methods they do not use.

In Quoting Robert C Martin [Stackify](https://stackify.com/interface-segregation-principle/) explained this slightly differently - “Clients should not be forced to depend upon interfaces that they do not use.”

A good example of this would be if there was an interface for multi-function printers. If it had print, scan and fax methods then anything that implelemts it would need to have those methods. This wouldn't make sense for a printer that only has print capababilities. 

Instead it would be better to have an interface for Printer, Scanner Fax. Then the sub class would be able implement whichever interfaces are required eg:

pubic class Printer : IPrinter
{
//Only needs print methods    
}

public class Photocopier : IPrinter, IScanner
{
//implements methods for printer and scanner
}


**Dependency Inversion Principle**  

Robert C. Martin

1. High-level modules should not depend on low-level modules. Both should depend on abstractions.
2. Abstractions should not depend on details. Details should depend on abstractions.







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

For this design pattern it's probably imporant that you know what concrete and abstract classes are and how they differ from interfaces

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


### Interface vs Abstract Classes

Abstract classes can have methods with implementation whereas interface provides absolute abstraction and can't have any method implementations. Note that from Java 8 onwards, we can create default and static methods in interface that contains the method implementations. [Digital Ocean](https://www.digitalocean.com/community/tutorials/difference-between-abstract-class-and-interface-in-java) 

This is why subclasses that implement abstact classes in C# usually use the override keyword in their methods. They aren't implementing a pre-defined method, they are actually overriding an exisiting one. An abstract class is 'extended' by a subclass whereas an interface is 'implemented'






Below is code where an abstract class is definied and  a concrete class implements its methods using overrides. Note the



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

Some other developers that I've spoken to call it a "factory of factories" which provides an interface for creating families of related or dependent objects without specifying their concrete classes.


Bytehide claim that that an abtract factory had four main components:

```
- Abstract Product: Declares an interface for a type of product object.

- Concrete Product: Defines a specific product object to be created by the corresponding Concrete Factory.
 Abstract Factory

- The abstract factory declares an interface for operations that create abstract objects.

- Concrete Factory: Implements the operations to create concrete products.
```
[Bytehide Design Patterns Guide](https://www.bytehide.com/blog/abstact-factory-pattern-csharp)

There could be multiple Concrete  Products and multiple Concrete factories. Each of which implment or extend their respective interface or abstract classes.


### C# implementation of Abstract Factory design pattern

[Click here to view the full C# implementation](Design-Patterns-0003.Abstract-Factory.example.cs)

Define the abstract objects that the concrete classes will extend

We're selling burger and a side. The factories will decide which types of burger to and side to build

```
    /// <summary>
    /// An abstract object.
    /// </summary>
    abstract class Burger { }

    /// <summary>
    /// An abstract object.
    /// </summary>
    abstract class Side { }

```
Concrete classes for the burders. These are the different types of burger and side (see above) which are available
```
    /// <summary>
    /// A ConcreteProduct
    /// </summary>
    class BigMeatBuger : Burger { }



    /// <summary>
    /// A concrete object
    /// </summary>
    class VeganPlantBurger : Burger { }

    /// <summary>
    /// A concrete object
    /// </summary>
    class Carrot : Side { }

    /// <summary>
    /// A concrete factory which creates concrete objects by implementing the abstract factory's methods.
    /// </summary>
    /// 


    /// <summary>
    /// A ConcreteProduct
    /// </summary>
    class Hotwing : Side { }
```
All meals created will need to have a burger and a side. So create the abstract class for that

```
    /// <summary>
    /// The AbstractFactory class, which defines methods for creating abstract objects.
    /// </summary>
    abstract class ComboFactory
    {
        public abstract Burger CreateBurger();
        public abstract Side CreateSide();
    }
```
We need the factories  which create concrete objects. These will  create food items to put into the meal
```
    /// <summary>
    /// A ConcreteFactory which creates concrete objects by implementing the abstract factory's methods.
    /// </summary>
    class CarnivoreFoodFactory : ComboFactory
    {
        public override Burger CreateBurger()
        {
            return new BigMeatBuger();
        }

        public override Side CreateSide()
        {
            return new Hotwing();
        }
    }



    class VeganFoodFactory : ComboFactory
    {
        public override Burger CreateBurger()
        {
            return new VeganPlantBurger();
        }

        public override Side CreateSide()
        {
            return new Carrot();
        }
    }

```
Below we have code that utlises factoies to create meals depending on the customer's preference

```
class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you eat animal products? (Y)es or (N)o?");
            char input = Console.ReadKey().KeyChar;
            ComboFactory factory;
            switch (input)
            {
                case 'y':
                    factory = new CarnivoreFoodFactory();
                    break;

                case 'n':
                    factory = new VeganFoodFactory();
                    break;

                default:
                    throw new NotImplementedException();

            }

            //This user has selected their preference and the appropriate factory has been chosen
            //Now use that factory to build the meals

            var burger = factory.CreateBurger();
            var side = factory.CreateSide();

            Console.WriteLine("\nBurger: " + burger.GetType().Name);
            Console.WriteLine("Side: " + side.GetType().Name);

            Console.ReadKey();
        }
```




For more guides like this please see https://johnmccourt.com 
 
