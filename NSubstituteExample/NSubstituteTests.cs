using FluentAssertions;
using NSubstitute;
using Project;

namespace NSubstituteProject
{
    public class NSubstituteTests
    {
        [Fact]
        public void NSubstitute_Example_1()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2).Returns(3);

            calculator.Add(1, 2).Should().Be(3);
        }

        [Fact]
        public void NSubstitute_Example_2()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Add(Arg.Any<int>(), Arg.Any<int>());

            var computer = new Computer(calculator);
            computer.CPU("Intel", 3, 6);

            calculator.Received().Add(3, 6);
        }
    }
}