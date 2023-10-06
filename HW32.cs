using System.Threading;
using System.Threading.Tasks;


// 1

await Task.Run(() => Moving());   // Вызвал асинхронный метод в фоновом потоке с помошью Task.Run 
                                  // и await для ожидания результата

static async Task Moving()  // Создал async метод Runing
{
    Console.WriteLine("Moving");  // Действие которое будет происходить в методе
    await Task.Delay(1000);       // Асинхронное ожидание Task.Delay на 1 сек и ожидание результата с помошью к.с. await
    Console.WriteLine("Stoped");  // индикатор того что действие выполнелось
}


// 2

await Runing();   // Вызвал асинхронный методы с помошью await для ожидания результата
await Flying();                   
await Swiming();

static async Task Runing()  // Создал async метод Runing
{
    Console.WriteLine("Runing");  // Действие которое будет происходить в методе
    await Task.Delay(1000);       // Асинхронное ожидание Task.Delay на 1 сек и ожидание результата с помошью к.с. await
    Console.WriteLine("Stoped");  // индикатор того что действие выполнелось
}

static async Task Flying()      // Создал async метод Flying
{
    Console.WriteLine("Flying");  // Действие которое будет происходить в методе
    await Task.Delay(2000);       // Асинхронное ожидание Task.Delay на 2 сек и ожидание результата с помошью к.с. await
    Console.WriteLine("Stoped");  // индикатор того что действие выполнелось
}

static async Task Swiming()      // Создал async метод Swiming
{
    Console.WriteLine("Swiming");  // Действие которое будет происходить в методе
    await Task.Delay(3000);       // Асинхронное ожидание Task.Delay на 3 сек и ожидание результата с помошью к.с. await
    Console.WriteLine("Stoped");  // индикатор того что действие выполнелось
}


// 3

static async Task ExecuteAll() // Создал async метод Execute
{
    var task1 = Runing();
    var task2 = Flying();  // определяем и вызываем методы
    var task3 = Swiming();

    await Task.WhenAll(task1, task2, task3);  // ожидаем выполнения всех методов
}


// 4 - 5

await Cancelation();

static async Task Cancelation()  // Создал асинхронный метод Main
{
    CancellationTokenSource cts = new();  // создал экземпляр CancellationTokenSource

    Console.WriteLine("Application started.");

    try                       
    {
        cts.CancelAfter(5000);   // метод CancelAfter для отмены работы после определенного времени

        await ExecuteAll();       // ожидание результата Execute
    }
    catch (OperationCanceledException)        // обработка исключений которые могут возникнуть             
    {
        Console.WriteLine("\nTasks cancelled: timed out.\n");
    }
    finally
    {
        cts.Dispose(); // Освобождает все ресурсы с помошью метода Dispose
    }

    Console.WriteLine("Application ending.");
}

// 6 

var task1 = Runing();
var task2 = Flying();  // определяем и вызываем методы
var task3 = Swiming();

await Task.WhenAny(task1, task2, task3); // Использование Task.WhenAny для ожидания выполнения первой из нескольких асинхронных операций

// 7 - 8

Study study = await StudyAsync();  // вызвал асинхронные методы Task<T> и ожидание результата с await
Watch watch = await WatchAsync();
Eat eat = await EatAsync();


static async Task<Study> StudyAsync()  // Использовал класс Task<T> для создания асинхронного метода
{
    await Console.Out.WriteLineAsync("Sudying started...");  // Действие которое будет происходить в методе
    await Task.Delay(1000);                 // Асинхронное ожидание Task.Delay на 1 сек и ожидание результата с помошью к.с. await
    Console.WriteLine("Studying ended..."); // индикатор того что действие выполнелось
    return new();                           // возвращает тип класса
}

static async Task<Watch> WatchAsync()        // Использовал класс Task<T> для создания асинхронного метода
{
    Console.WriteLine("Watching movie started...");  // Действие которое будет происходить в методе
    await Task.Delay(1000);                  // Асинхронное ожидание Task.Delay на 1 сек и ожидание результата с помошью к.с. await
    Console.WriteLine("Watching movie ended...");  // индикатор того что действие выполнелось
    return new();                                   // возвращает тип класса
}

static async Task<Eat> EatAsync()        // Использовал класс Task<T> для создания асинхронного метода
{
    Console.WriteLine("Eating juice started...");  // Действие которое будет происходить в методе
    await Task.Delay(100);                // Асинхронное ожидание Task.Delay на 1 сек и ожидание результата с помошью к.с. await
    Console.WriteLine("Eating juice ended...");    // индикатор того что действие выполнелось
    return new();                                  // возвращает тип класса
}


// 9
  

static ValueTask<byte> GetAsync()   // Создал асинхронный метод ValueTask 
{                                    // который будет возвращать значение примитивного типа без выделения памяти на куче
    return new ValueTask<byte>(0);
}




class Study { }   
class Watch { }       // Созданные классы для задания 7
class Eat { }
