Fox fennec = new Fennec() { Shape = "Small" };
Fox arctic = new Arctic() { Shape = "Big" };

BuyFox(fennec);
BuyFox(arctic);

static void BuyFox(Fox fox)
{
    if (fox == null) throw new ArgumentException();

    Console.WriteLine(fox.Shape);
    Console.WriteLine(fox.Color);
    Console.WriteLine(fox.WhereLives);
}
// Абстракция - возможность создать какую нибудь идею в виде абстрактных классов которые
 //содержат в себе методы которых могут унаследовать дочерние классы.
public abstract class Fox
{
    public abstract string Shape { get; set; }
    public abstract string Color { get; }
    public abstract string WhereLives { get; }
}
// Наследование - возможность создания новых абстракций на основе уже существующих абстракций.
// Полиморфизм - возможность реализации свойств или методов наследованных от абстракций.
public sealed class Fennec : Fox
{
    public override string Shape { get; set; }
    public override string Color => "Yellow";
    public override string WhereLives => "Dust";
}


// Инкапсуляция - возможность объединение классов и методов и их скрытие от внешного воздействия .
public sealed class Arctic : Fox
{
    private string? _shape;
    public override string Shape
    {
        get => _shape ?? string.Empty;
        set => _shape = value;
    }
    public override string Color => "White";
    public override string WhereLives => "Arctica";
}


Console.WriteLine();



// Exeptions

    void HWExceptions()
    {
        int[] array = { 1, 2, 3, 4, 5 };

        for (int i = 0; i < array.Length; i++)
            Console.WriteLine(array[i]);
 
        try 
        {
 
            Console.WriteLine(array[7]);
        }
        catch (HWException ex) 
        {
            Console.WriteLine("Exception: {0}", ex.Message);
        }
    } 
public class HWException : System.Exception
{
    public HWException() { }
    public HWException(string message) : base(message) { }
    public HWException(string message, System.Exception inner) : base(message, inner) { }
    protected HWException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}




