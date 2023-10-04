using System.Timers;
using System.Threading;



System.Timers.Timer timer = new(3000);     // Создан таймер на 3 секунды
timer.Elapsed += Elapsed;              // Задача которая быдет выпонятся в таймере, раз за разом
timer.Start();                 // Запуск таймера методом Start
timer.Enabled = false;     // Прекращение выполнение задач в таймере с помощью свойства Timer.Enabled

CancellationTokenSource cts = new();  // Создал источник для получения доступа к токену CancellationToken для отмены потока
 

Thread thread1 = new(Execute) //  Создал поток Thread1 и передал ему метод Execute
{
    Priority = ThreadPriority.Highest  // задал наивысший приоритет Highest, выполняется раньше всех  
};

Thread thread2 = new(Execute)  
{
    Priority = ThreadPriority.AboveNormal   // задал ему приоритет выше нормы, выполняется перед потоками с приоритетом Normal
};

Thread thread3 = new(Execute)
{
    Priority = ThreadPriority.Normal // задал приоритет Normal, который является дефолтным для потоков
};

Thread thread4 = new(Execute)
{
    Priority = ThreadPriority.BelowNormal  // задал приоритет BelowNormal, выполняется после потоков с приоритетом Normal
};


thread1.Start(cts.Token);
thread2.Start(cts.Token);  
thread3.Start(cts.Token);   // запустил потоки с помошью метода Start
thread4.Start(cts.Token);

thread2.Abort(); // прервание выполнения потока с помошью метода Abort

while (true)
{
    if (Console.ReadKey().Key == ConsoleKey.Escape)  // Вызов метода Cancel по клавише Escape
        cts.Cancel();
}

static void Execute(object? objToken)    // в методе Execute передается токен через boxing 
{                                            
    try                 // Обработатка исключений в управляемых потоках с помощью блока try-catch
    {
        Thread.Sleep(1000);        // задерка на 1 секунду, методом Sleep

        CancellationToken token = (CancellationToken)objToken!;        // unboxing токена CancellationToken

        token.ThrowIfCancellationRequested();        // с помощью метода ThrowIfCancellationRequested в ответ
                                                    // на запрос об отмене кидается исключение OperationCanceledException

        Console.WriteLine($"{Environment.CurrentManagedThreadId} - {Thread.CurrentThread.Priority}");   // получение идентификатор потака и его приоритет
    }
    catch(ThreadAbortException)
    {

    }
    catch (System.Exception ex)   
    {
        Console.WriteLine(ex.Message);
    }
}

static void Elapsed(object? sender, ElapsedEventArgs e)
{
    Console.WriteLine("Timer elapsed!");
}

var ct = cts.Token; // передал токен в переменную типа CancellationToken
Task tasks = Task.Run(async () => // Добавил async
{
    int i = 3000;                
    await Task.Delay(i, ct);    // создал ограничение по времени для выполнения потока
    Console.WriteLine(i);
    return i;
}, ct);

