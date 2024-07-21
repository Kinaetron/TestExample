namespace Project;

public class Computer
{
    private readonly ICalculator _calculator;

    public Computer(ICalculator calculator) {
        _calculator = calculator;
    }

    public double CPU(string name, int speed, int  cores)
    {
        _ = _calculator.Add(speed, cores);
        return 4.55;
    }
}
