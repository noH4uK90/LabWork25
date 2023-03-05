//Task1();
//await Task2();
//await Task3();
await Task4(2, 5 ,1 ,7, 4, 9, 8, 2);

void Task1()
{
    Pow(1.5, 3);
    Pow(2, 4);
    Pow(3, 2);
}

void Pow(double a, int x)
{
    var result = a;
    for (var i = 1; i < x; i++)
        result *= a;
    Console.WriteLine($"{a} ^ {x} = {result}");
}

async Task Task2()
{
    var task1 = Task.Run(() => Pow(1.5, 3));
    var task2 = Task.Run(() => Pow(2, 4));
    var task3 = Task.Run(() => Pow(3, 2));

    await Task.WhenAll(task1, task2, task3);
}

async Task Task3()
{
    var task1 = Task.Run(() => PowWithResult(1.5, 3));
    var task2 = Task.Run(() => PowWithResult(2, 4));
    var task3 = Task.Run(() => PowWithResult(3, 2));

    await Task.WhenAll(task1, task2, task3);
}

double PowWithResult(double a, int x)
{
    var result = a;
    for (var i = 1; i < x; i++)
        result *= a;
    //Console.WriteLine(result);
    return result;
}

async Task Task4(double a, int x, double a2, int x2, double a3, int x3, double a4, int x4)
{
    try
    {
        var result = await Task.Run(() =>
        {
            var numerator = PowWithResult(a, x) + PowWithResult(a2, x2);
            var denominator = PowWithResult(a3, x3) + PowWithResult(a4, x4);
            return numerator / denominator;
        });
        Console.WriteLine($"({a} ^ {x} + {a2} ^ {x2}) / ({a3} ^ {x3} + {a4} ^ {x4}) = {result}");
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception);
    }
}