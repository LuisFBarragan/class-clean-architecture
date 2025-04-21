// Programación estructurada
//variables
using System.Reflection.Metadata.Ecma335;

int number = 15;
string name = "Héctor";
bool thereIsBeer = true;

Console.WriteLine(number);

var num = 15;
var name2 = "Juan";

// arrays
var numbers = new int[5]
{
    1,2,3,4,5
};

Console.WriteLine(numbers[0]);
Console.WriteLine(numbers[4]);

// sentencias condicionales: if y switch

var age = 12;
if(age > 60)
{
    Console.WriteLine("Es de la tercera edad");
}
else if(age > 18)
{
    Console.WriteLine("Es mayor de edad");
}
else
{
    Console.WriteLine("Es menor de edad");
}

switch (age)
{
    case < 18:
        Console.WriteLine("Es menor de edad");
        break;
    case < 60:
        Console.WriteLine("Es mayor de edad");
        break;
    default:
        Console.WriteLine("Es de la tercera edad");
        break;

}

// sentencia de iteración: while, do y for
var names = new string[3]
{
    "Héctor", "Juan", "Pedro"
};

int i = 0;
do
{
    Console.WriteLine(names[i]);
    // i = i + 1;
    i++;
} while (i<names.Length);

i = 0;
while (i<names.Length)
{
    Console.WriteLine(names[i]);
    i++;
}

for (int j = 0; j<names.Length; j++)
{
    Console.WriteLine(names[j]);
}


// funciones
int res1 = 30 * 30;
int res2 = 20 + 20;
int res3 = Area(30);

Console.WriteLine(res1);
Console.WriteLine(res2);
Console.WriteLine(res3);
Show("Arquitectura Limpia");
Bye();

int Area(int d)
{
    int res = d * d;
    return res;
}

void Show(string message)
{
    Console.WriteLine(message);
}

void Bye()
{
    Show("Adios");
}



// ejemplo programación estructurada

int op = 0;
int limit = 10;
var beers = new string[limit];
int iBeers = 0;

do
{
    Console.Clear();
    ShowMenu();
    op = int.Parse(Console.ReadLine());

    switch (op)
    {
        case 1:
            if (iBeers< limit) {
                Console.Clear();
                Console.WriteLine("Escribe un nombre de cerveza: ");
                var beer = Console.ReadLine();
                beers[iBeers] = beer;
                iBeers++;
            }
            else
            {
                Console.WriteLine("Ya no caben cervezas");
            }
            break;
        case 2:
            ShowBeers(beers, iBeers);
            break;
        case 3:
            Console.WriteLine("Adios");
            break;
        default:
            Console.WriteLine("Opción no valida");
            break;
    }
} while (op !=3);


void ShowMenu(){
    Console.WriteLine("1. Agregar nombre");
    Console.WriteLine("2. Mostrar nombres");
    Console.WriteLine("3. Salir");
}

void ShowBeers(string[] beers, int iBeers)
{
    Console.Clear();
    Console.WriteLine("-----Cervezas-----");
    for (int i= 0; i <= iBeers; i++)
    {
        Console.WriteLine(beers[i]);
    }
    Console.WriteLine("Presiona una tecla para continuar");
    Console.ReadLine();
}

