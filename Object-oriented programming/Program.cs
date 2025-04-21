using Object_oriented_programming.Business;

Beer erdingerBeer = new Beer("Erdinger", 3, -1, 500);
var delirium = new ExpiringBeer("Delirium", 4, 8, new DateTime(2024, 12, 1), 330);

Drink drink = new Wine(500);
Show(drink);
drink = new Beer("Corona", 2, 4, 330);
Show(drink);

ISalable[] concepts = [
    erdingerBeer,
    delirium,
    new Service(100,10)
];
Console.WriteLine(GetTotal(concepts));
SendSome(erdingerBeer);

var elements = new Collection<int>(3);
elements.Add(100);
elements.Add(150);
elements.Add(200);
elements.Add(500);

var names = new Collection<string>(2);
names.Add("Héctor");
names.Add("Ana");
names.Add("Juan");
foreach (var element in names.Get())
{
    Console.WriteLine(element);
}

var beers = new Collection<Beer>(2);
beers.Add(erdingerBeer);
beers.Add(delirium);
foreach (var element in beers.Get())
{
    Console.WriteLine(element.GetInfo());
}

foreach (var element in elements.Get())
{
    Console.WriteLine(element);
}

Console.WriteLine($"Objetos creados {Beer.QuantityObjects}");
Console.WriteLine(Operations.Add(1,3));
Console.WriteLine(Operations.Mul(10,20));


void Show(Drink drink) =>
    Console.WriteLine(drink.GetCategory());

decimal GetTotal(ISalable[] concepts){
    decimal total = 0;
    foreach (var concept in concepts)
    {
        total += concept.GetPrice();
    }
    return total;
}

void SendSome(ISend some)
{
    Console.WriteLine("hago algo");
    some.Send();
    Console.WriteLine("Hago algo más");
}
