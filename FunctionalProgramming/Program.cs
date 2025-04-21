using System.Threading.Channels;

Console.WriteLine(Tomorrow());
Console.WriteLine(TomorrowPure(new DateTime(2024,05,01,00,00,00)));

var beer = new Beer()
{
    Name = "Heineken"
};

//Console.WriteLine(ToUpper(beer).Name);
Console.WriteLine(ToUpperPure(beer).Name);
Console.WriteLine(beer.Name);

var t = TomorrowPure;
Console.WriteLine(t(new DateTime(2024,05,01,00,00,00)));

Action<string> show = Console.WriteLine;
show("Hola");
Action<string> hi = name => Console.WriteLine($"Hola {name}");
hi("Héctor");
Action<int, int> add = (a, b) => show((a + b).ToString());

Func<int, int, int> mul = (a, b) => a * b;
show(mul(3, 4).ToString());

Func<int, int, string> mulString = (a, b) =>
{
    var res = a * b;
    return res.ToString();
};
show(mulString(5, 10));

List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
Predicate<int> condition1 = x => x % 2 == 0;
Predicate<int> condition2 = x => x > 5;

var numbers2 = Filter(numbers, condition1);
var numbers3 = Filter(numbers, condition2);

foreach (var number in numbers3)
{
    Console.WriteLine(number);
}

//Función orden superior
List<int> Filter(List<int> list, Predicate<int> condition)
{
    var resultsList = new List<int>();
    foreach (var element in list)
    {
        if (condition(element))
        {
            resultsList.Add(element);
        }
    }
    return resultsList;
}


// Función no pura
DateTime Tomorrow(){
    return DateTime.Now.AddDays(1);
}

Beer ToUpper(Beer beer)
{
    beer.Name = beer.Name.ToUpper();
    return beer;
}

//Función pura
DateTime TomorrowPure(DateTime date)
{
    return date.AddDays(1);
}

Beer ToUpperPure(Beer beer)
{
    var beer2 = new Beer()
    {
        Name = beer.Name.ToUpper(),
    };

    return beer2;
}



public class Beer
{
    public string Name { get;set; }
}