using System.Collections.Generic;
using System.Threading;

// 1
Thread thread1 = new(Execute1);
Thread thread2 = new(Execute2);

thread1.Start();
thread2.Start();

void Execute1()
{
    for (int i = 1 ; i <= 100; i++) Console.WriteLine(i);
}

void Execute2()
{
    for (int i = 101 ; i <= 200; i++) Console.WriteLine(i);
}

// 2

Thread thread3 = new(Execute3);
Thread thread4 = new(Execute4);

thread3.Start();
thread4.Start();

void Execute3()
{
    for(int i = 0; i <= 100; i++)
    {
        if(i % 2 == 0) Console.WriteLine(i);
    }
}

void Execute4()
{
    for(int i = 1; i <= 99; i++)
    {
        if(i % 2 != 0) Console.WriteLine(i);
    }
}

// 3


Thread thread5 = new(Execute5);
Thread thread6 = new(Execute6);
Thread thread7 = new(Execute7);

thread5.Start();
thread6.Start();
thread7.Start();

void Execute5()
{
    for(int i = 1; i <= 33; i++) Console.WriteLine(i);
}

void Execute6()
{
    for(int i = 34; i <= 66; i++) Console.WriteLine(i);
}

void Execute7()
{
    for(int i = 67 ; i <= 100; i++) Console.WriteLine(i);
}

// 4


Thread thread8 = new(Execute8);
Thread thread9 = new(Execute9);

thread8.Start();
thread9.Start();

void Execute8()
{
    for(char i = 'A' ; i <= 'M' ; i++) Console.WriteLine(i);   
}

void Execute9()
{
    for(char i = 'N' ; i <= 'Z' ; i++) Console.WriteLine(i);   
}

// 5 

Thread thread10 = new(Execute10);
Thread thread11 = new(Execute11);

thread10.Start();
thread11.Start();

void Execute10()
{
    for(int i = 1; i <= 100; i++)
    {
        if(i % 3 == 0) Console.WriteLine(i);
    }
}

void Execute11()
{
    for(int i = 1; i <= 100; i++)
    {
        if(i % 5 == 0) Console.WriteLine(i);
    }
}

// 6

Thread thread12 = new(Execute12);
Thread thread13 = new(Execute13);

thread12.Start();
thread13.Start();


void Execute12()
{ 
    for(int i = 1; i <= 100; i++) 
    {
        bool b = true;
        for(int j = 2; j < i; j++)
        {
            if(i % j == 0 & i % 1 == 0)
            {
                b = false;
            }
        }
        if(b) Console.WriteLine(i);   
    }
}

void Execute13()
{
    for(int i = 1; i <= 100; i++) 
    {
        bool b = false;
        for(int j = 2; j < i; j++)
        {
            if(i % j == 0 & i % 1 == 0)
            {
                b = true;
            }
        }
        if(b) Console.WriteLine(i);   
    }
}

 // 7

Thread thread14 = new(() => Console.WriteLine(Enumerable.Range(1, 100).Sum()));
Thread thread15 = new(Execute15);

thread14.Start();
thread15.Start();

void Execute15()
{
    IEnumerable<int> ints = Enumerable.Range(1, 100);
    var factorial = ints.Aggregate((f, s) => f * s);
    Console.WriteLine(factorial);
}

// 8 

Thread thread16 = new(Execute16);
Thread thread17 = new(Execute17);

thread16.Start();
thread17.Start();


void Execute16()
{ 
    for (int i = 1; i <= 100; i ++)
    {
        if (i % 3 == 0 && i % 5 == 0) Console.WriteLine(i); 
    }
}

void Execute17()
{
    for (int i = 1; i <= 100; i ++)
    {
        if (i % 3 != 0 && i % 5 != 0) Console.WriteLine(i); 
    }
}

// 9

Thread thread18 = new(Execute18);
Thread thread19 = new(Execute19);

thread18.Start();
thread19.Start();


void Execute18()
{ 
    for (int i = 1; i <= 50; i ++) Console.WriteLine(i);
}

void Execute19()
{
    for (int i = 100; i >= 51; i --) Console.WriteLine(i);
}

// 10

Thread thread20 = new(Execute20);
Thread thread21 = new(Execute21);

thread20.Start();
thread21.Start();


void Execute20()
{ 
    for (int i = 1; i <= 100; i ++) Console.WriteLine(i); 
}

void Execute21()
{
    for(int i = 1; i <= 100; i ++) Console.WriteLine(i*i);
}