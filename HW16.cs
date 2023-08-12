
// Первый принцип - SRP, он же Single Responsibility Principle
// Этот принцип глосит что у каждого объекта должна быть одна задача, то есть не должно быть слишком моного нагрузок на один объект.
class Jump
{
    void ShortJump()
    {
        int speed = 5;
        int strenth = 10;
        int distance = speed * strenth;
    }

    void LongJump()
    {
        int speed = 10;
        int strenth = 20;
        int distance = speed * strenth;
    }
}

class Run
{
    void RunFast()
    {
        int strenth = 10;
        int distance = 100;
        int speed = distance / strenth;
    }

    void RunSlow()
    {
        int strenth = 5;
        int distance = 100;
        int speed = distance / strenth;

    }
}

class Walk
{
    void WalkSlow()
    {
        int strenth = 1;
        int distance = 100;
        int speed = distance / strenth;
        
    }

    void WalkFast()
    {
        int strenth = 3;
        int distance = 100;
        int speed = distance / strenth;
    }
}




// Второй принципе SOLID - Open/Closed Principle (OCP).
// Принцип открытости/закрытости, гласит объекты приложения, должны быть открыты для
// использования в друших объектах но их составляющие должны быть закрыты от воздействий.

public abstract class Move
{
    private readonly int _speed = 10;
    
    public Move(int speed, int _speed)
    {
        speed = _speed;
    }

    public abstract void MoveSpeed(int speed);
    
}

public class MoveFoward : Move
{
    public MoveFoward(int speed, int _speed) : base(speed, _speed)
    {
    }

    public override void MoveSpeed(int speed)
    {
        int distance = speed * 10;
    }
}
public class MoveBack : Move
{
    public MoveBack(int speed, int _speed) : base(speed, _speed)
    {
    }

    public override void MoveSpeed(int speed)
    {
        int distance = speed * 5;
    }
}


// Третий принцип SOLID - Liskov Substitution Principle.

// Принцип замещения Лискова (LSP), гласит, что объекты дочернего класса должны иметь возможность заменять объекты родительского класса,
// но при условии того что дочерние классы должны иметь такую же кодовую базу.

public abstract class Home
{
    public abstract string Design { get; set; }
    public abstract string Color { get; }
    public abstract string City { get; }
}

public sealed class House : Home
{
    public override string Design { get; set; }
    public override string Color => "Yellow";
    public override string City => "Khujand";
}


public sealed class Appartments : Home
{
    public override string Design
    { 
        get => throw new NotImplementedException(); 
        set => throw new NotImplementedException(); 
    }
    public override string Color => "White";
    public override string City => "Dushanbe";
}


//Interface Segregation Principle (ISP), гласит, что интерфейсы не должны иметь в себе много методов,  
//необходимо разделять их на более маленькие интерфейсы и что бы знали только о методах, которые необходимы им в работе


public interface IBuyPresent
{
    int Price {get; set;}
    void BuyIPhone(int Price)
    {
        int price = 10000;
        Price = price;
    }
    
}

public interface IWhereSend : IBuyPresent
{
    string Addres {get; set;}
}

public interface ISendWay : IBuyPresent
{
    string Delivery {get; set;}
}

// Пятый принцип SOLID - Dependency Inversion Principle
// этот принцип требует что бы ceoyjcnb не зависели друг от друга, а зависели от абстракций.

interface IConnnet
{
    string ConnectionID();
}


class MyConnection : IConnnet
{
    public string ConnectionID() => "12334";
}

class TryConnect
{
    private readonly IConnnet TryToConnect;
    public TryConnect(IConnnet tryToConnect)
    {
        TryToConnect = tryToConnect;
    }
}