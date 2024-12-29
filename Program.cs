using System;
using System.Collections.Generic;

//Задание 1

//public struct Vector
//{
//    public double x;
//    public double y;
//    public double z;

//    public Vector(double x, double y, double z)
//    {
//        this.x = x;
//        this.y = y;
//        this.z = z;
//    }

//    public static Vector operator +(Vector a, Vector b)
//    {
//        return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
//    }
//    public static double operator *(Vector a, Vector b)
//    {
//        return a.x * b.x + a.y * b.y + a.z * b.z;
//    }

//    public static Vector operator *(Vector a, double scalar)
//    {
//        return new Vector(a.x * scalar, a.y * scalar, a.z * scalar);
//    }
//    public static Vector operator *( double scalar, Vector a)
//    {
//        return (a * scalar);
//    }

//    public double Length()
//    {
//        return Math.Sqrt(x * x + y * y + z * z);
//    }
//    public static bool operator >(Vector a, Vector b)
//    {
//        return a.Length() > b.Length();
//    }
//    public static bool operator <(Vector a, Vector b)
//    {
//        return a.Length() < b.Length();
//    }
//    public static bool operator ==(Vector a, Vector b)
//    {
//        return a.Length() == b.Length();
//    }

//    public static bool operator !=(Vector a, Vector b)
//    {
//        return a.Length() != b.Length();
//    }

//    public override bool Equals(object obj)
//    {
//        if (obj is Vector)
//        {
//            var other = (Vector)obj;
//            return this.Length() == other.Length();
//        }
//        return false;
//    }

//    public override int GetHashCode()
//    {
//        return Length().GetHashCode();
//    }

//    public override string ToString()
//    {
//        return $"Vector({x}, {y}, {z})";
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Vector v1 = new Vector(1, 2, 3);
//        Vector v2 = new Vector(4, 5, 6);

//        Vector sum = v1 + v2;
//        Console.WriteLine(sum);

//        double dotProduct = v1 * v2;
//        Console.WriteLine(dotProduct);

//        Vector scaled = v1 * 2;
//        Console.WriteLine(scaled);

//        bool isGreater = v1 > v2;
//        Console.WriteLine(isGreater);
//    }
//}


//Задание 2

public class Car : IEquatable<Car>
{
    public string Name { 
        get { return name; } 
        set { 
           if(value.Length < 2) { throw new ArgumentException("Длина должна быть другой"); }
            name = value; 

        }
    }
    public string Engine { get; set; }
    public int MaxSpeed { get; set; }
    private string name; 

    public Car(string name, string engine, int maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car other)
    {
        if (other == null) return false;
        return Name == other.Name && Engine == other.Engine && MaxSpeed == other.MaxSpeed;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
        hash = hash * 23 + (Engine != null ? Engine.GetHashCode() : 0);
        hash = hash * 23 + MaxSpeed.GetHashCode();
        return hash;
    }
}

public class CarsCatalog
{
    private List<Car> cars;

    public CarsCatalog()
    {
        cars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < cars.Count)
            {
                return $"{cars[index].Name}, Двигатель: {cars[index].Engine}";
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона.");
            }
        }
    }

    public int Count => cars.Count;
}

class Program
{
    static void Main()
    {
        CarsCatalog catalog = new CarsCatalog();

        catalog.AddCar(new Car("Toyota Camry", "V6", 240));
        catalog.AddCar(new Car("Honda Accord", "I4", 220));
        catalog.AddCar(new Car("F", "V8", 260));

        Console.WriteLine("Информация о машинах в каталоге:");
        for (int i = 0; i < catalog.Count; i++)
        {
            Console.WriteLine(catalog[i]);
        }
        Car honda = new Car("Honda Accord", "I4", 220);
        Console.WriteLine($"Honda машина через ToString: {honda}");
    }
}

//Задание 3

//public class Currency
//{
//    public decimal Value { get; set; }

//    public Currency(decimal value)
//    {
//        Value = value;
//    }
//}

//public class CurrencyUSD : Currency
//{
//    private const decimal ExchangeRateToEUR = 0.89m;
//    private const decimal ExchangeRateToRUB = 92m;

//    public CurrencyUSD(decimal value) : base(value) { }

//    public static explicit operator CurrencyEUR(CurrencyUSD usd)
//    {
//        return new CurrencyEUR(usd.Value * ExchangeRateToEUR);
//    }

//    public static explicit operator CurrencyRUB(CurrencyUSD usd)
//    {
//        return new CurrencyRUB(usd.Value * ExchangeRateToRUB);
//    }
//}

//public class CurrencyEUR : Currency
//{
//    private const decimal ExchangeRateToUSD = 1.11m; 
//    private const decimal ExchangeRateToRUB = 103m;

//    public CurrencyEUR(decimal value) : base(value) { }

//    public static explicit operator CurrencyUSD(CurrencyEUR eur)
//    {
//        return new CurrencyUSD(eur.Value * ExchangeRateToUSD);
//    }

//    public static explicit operator CurrencyRUB(CurrencyEUR eur)
//    {
//        return new CurrencyRUB(eur.Value * ExchangeRateToRUB);
//    }
//}

//public class CurrencyRUB : Currency
//{
//    private const decimal ExchangeRateToUSD = 0.0108m; 
//    private const decimal ExchangeRateToEUR = 0.009m; 

//    public CurrencyRUB(decimal value) : base(value) { }

//    public static explicit operator CurrencyUSD(CurrencyRUB rub)
//    {
//        return new CurrencyUSD(rub.Value * ExchangeRateToUSD);
//    }

//    public static explicit operator CurrencyEUR(CurrencyRUB rub)
//    {
//        return new CurrencyEUR(rub.Value * ExchangeRateToEUR);
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Console.Write("Введите сумму в USD: ");
//        decimal usdValue = decimal.Parse(Console.ReadLine());
//        CurrencyUSD usd = new CurrencyUSD(usdValue);

//        CurrencyEUR eur = (CurrencyEUR)usd;
//        Console.WriteLine($"Сумма в EUR: {eur.Value}");

//        CurrencyRUB rub = (CurrencyRUB)usd;
//        Console.WriteLine($"Сумма в RUB: {rub.Value}");

//        Console.Write("Введите сумму в EUR: ");
//        decimal eurValue = decimal.Parse(Console.ReadLine());
//        CurrencyEUR eurInput = new CurrencyEUR(eurValue);

//        CurrencyUSD usdFromEur = (CurrencyUSD)eurInput;
//        Console.WriteLine($"Сумма в USD: {usdFromEur.Value}");

//        rub = (CurrencyRUB)eurInput;
//        Console.WriteLine($"Сумма в RUB: {rub.Value}");

//        Console.Write("Введите сумму в RUB: ");
//        decimal rubValue = decimal.Parse(Console.ReadLine());
//        CurrencyRUB rubInput = new CurrencyRUB(rubValue);

//        usd = (CurrencyUSD)rubInput;
//        Console.WriteLine($"Сумма в USD: {usd.Value}");

//        eur = (CurrencyEUR)rubInput;
//        Console.WriteLine($"Сумма в EUR: {eur.Value}");
//    }
//}

