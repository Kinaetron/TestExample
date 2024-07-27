using FluentAssertions;
using Moq;
using Project;

namespace MoqProject
{
    public class MoqTests
    {
        [Fact]
        public void Moq_Example_1()
        {
            var moqCalculator = new Mock<ICalculator>();
            moqCalculator.Setup(calc => calc.Add(1, 2)).Returns(3);

            var calculator = moqCalculator.Object;
            calculator.Add(1, 2).Should().Be(3);
        }

        [Fact]
        public void Moq_Example_2()
        {
            var moqCalculator = new Mock<ICalculator>();
            moqCalculator.Setup(calc => calc.Add(It.IsAny<int>(), It.IsAny<int>()));

            var computer = new Computer(moqCalculator.Object);
            computer.CPU("Intel", 3, 6);

            moqCalculator.Verify(calc => calc.Add(3, 6));
        }

        [Fact]
        public void Moq_Example_3()
        {
            var counter = 0;

            var moqCalculator = new Mock<ICalculator>();
            moqCalculator.Setup(calc => calc.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Callback(() => counter++);

            var computer = new Computer(moqCalculator.Object);
            computer.CPU("Intel", 3, 6);

            counter.Should().Be(1);
        }
    }
}