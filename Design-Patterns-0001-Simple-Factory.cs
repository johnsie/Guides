
IAnimalFactory simpleFactory = new AnimalFactory();
// Creation of an animal using Simple Factory
//We're going to create a cat
IAnimal animal = simpleFactory.CreateAnimal(AnimalType.Cat);
// Use created object
animal.Speak();

Console.ReadLine();

enum AnimalType
{
    Dog,
    Cat,
    Giraffe,
    Cow
}

interface IAnimal
{
    void Speak();

}

class Dog : IAnimal {
    public void Speak() {
        Console.WriteLine("Woof");
    }
}

class Cat : IAnimal {
    public void Speak()
    {
        Console.WriteLine("Meow");
    }
}

class Giraffe : IAnimal {
    public void Speak()
    {
        Console.WriteLine("Tu tu tu tu ");
    }
}

class Cow : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Mooooo");
    }
}


interface IAnimalFactory
{
    IAnimal CreateAnimal(AnimalType type);
}

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
                
                return new Dog();
        }
    }
}

