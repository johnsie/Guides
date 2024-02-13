#Design Patterns

##Simple Factory Pattern 

A simple factory pattern utilises a class that has single method which decides what type of class to instantiate and return. 

'''
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
'''


For more guides like this please see https://johnmccourt.con 
 
