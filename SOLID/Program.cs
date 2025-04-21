// SRP
/*
var beer = new Beer();
beer.Add("Corona");
beer.Add("Delirium");
beer.SaveReport("cervezas.txt");*/

// var beerData= new BeerData();
using static System.Runtime.InteropServices.JavaScript.JSType;

var beerData = new BeerData();
beerData.Add("Corona");
beerData.Add("Delirium");
beerData.Add("Erdinger");

var reportGeneratorBeer = new ReportGeneratorBeer(beerData);
var reportGeneratorHTMLBeer = new ReportGeneratorHTMLBeer(beerData);
var report = new Report();
// report.Save(reportGeneratorBeer, "cervezas.txt");
report.Save(reportGeneratorHTMLBeer, "cervezas.html");

Rectangle rectangle = new Square();
rectangle.setWidth(10);
rectangle.setHeight(20);
Console.WriteLine(rectangle.getArea());

Show(reportGeneratorBeer);

void Show(IReportShow report)
{
    report.Show();
}

public class Rectangle
{
    private int _width;
    private int _height;

    public virtual void setWidth(int width)
    {
        _width = width;
    }

    public virtual void setHeight(int height)
    {
        _height = height;
    }

    public int getArea()
    {
        return _width * _height;
    }
}

public class Square : Rectangle
{
    public override void setWidth(int width)
    {
        base.setWidth(width);
        base.setHeight(width);
    }

    public override void setHeight(int height)
    {
        base.setWidth(height);
        base.setHeight(height);
    }
}

public interface IReportGenerator
{
    public string Generate();
}

public interface IReportShow
{
    public void Show();
}

public interface IRepository<T>
{
    public void Add(T item);
    public List<T> Get();
}


public class BeerData : IRepository<string>
{
    protected List<string> _beers;
    public BeerData()
    {
        _beers = new List<string>();
    }
    public void Add(string beer)
       => _beers.Add(beer);
    public List<string> Get()
        => _beers;
}


public class LimitedBeerData
{
    private IRepository<string> _beerData;
    private int _limit;
    private int _count = 0;

    public LimitedBeerData(int limit, IRepository<string> beerData)
    {
        _limit = limit;
        _beerData = beerData;
    }

    public void Add(string beer)
    {
        if (_count >= _limit)
        {
            throw new InvalidOperationException("Límite de cervezas alcanzado");
        }
        _beerData.Add(beer);
        _count++;
    }

    public List<string> Get()
    {
        return _beerData.Get();
    }
}

public class ReportGeneratorBeer : IReportGenerator, IReportShow
{
    private IRepository<string> _beerData;
    public ReportGeneratorBeer(IRepository<string> beerData)
    {
        _beerData = beerData;
    }
    public string Generate()
    {
        string data = "";
        foreach (var beer in _beerData.Get())
        {
            data += "Cerveza: " + beer + Environment.NewLine;
        }
        return data;
    }

    public void Show()
    {
        foreach (var beer in _beerData.Get())
        {
            Console.WriteLine("Cerveza: " + beer);
        }
    }
}

public class ReportGeneratorHTMLBeer : IReportGenerator
{
    private IRepository<string> _beerData;
    public ReportGeneratorHTMLBeer(IRepository<string> beerData)
    {
        _beerData = beerData;
    }
    public string Generate()
    {
        string data = "<div>";
        foreach (var beer in _beerData.Get())
        {
            data += "<b>" + beer + "<b></br>";
        }
        data += "</div>";

        return data;
    }

}

public class Report
{
    public void Save(IReportGenerator reportGenerator, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            string data = reportGenerator.Generate();
            writer.WriteLine(data);
        }
    }
}

// NO ES SOLID DE AQUÍ PARA ABAJO
//-----------------------------------------------------------
public class Beer
{
    private List<string> _beers;
    public Beer()
    {
        _beers = new List<string>();
    }

    public void Add(string beer)
        => _beers.Add(beer);

    public List<string> Get()
        => _beers;

    public List<string> GetReport()
    {
        var data = new List<string>();
        foreach (var beer in _beers)
        {
            data.Add("Cerveza: "+beer);
        }
        return data;
    }

    public void SaveReport(string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            foreach (var beer in GetReport())
            {
                writer.WriteLine(beer);
            }
        }
    }
}