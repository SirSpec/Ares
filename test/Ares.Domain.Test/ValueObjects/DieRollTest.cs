using Ares.Domain.Exceptions;
using Ares.Domain.ValueObjects;
using Xunit;

namespace Ares.Domain.Test.ValueObjects;

public class DieRollTest
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 1)]
    [InlineData(1, 0)]
    [InlineData(2, 1)]
    public void DieRoll_InvalidValue_ThrowsDomainException(int value, uint type)
    {
        var action = () => new DieRoll(value, type);

        Assert.Throws<DomainException>(action);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 2)]
    public void ValueAndType_ValidData_ValidValueAndType(int value, uint type)
    {
        var sut = new DieRoll(value, type);

        Assert.Equal((int)value, sut.Value);
        Assert.Equal((int)type, sut.Type);
    }

    [Fact]
    public void Deconstruct_DieRoll_ValueAndType()
    {
        (int Value, int Type) expected = (2, 5);

        (int value, int type) = new DieRoll(2, 5);

        Assert.Equal(expected.Value, value);
        Assert.Equal(expected.Type, type);
    }

    [Fact]
    public void ImplicitOperatorInt_DieRoll_IntValue()
    {
        int expectedValue = 2;
        var sut = new DieRoll((expectedValue), 5);

        int value = sut;

        Assert.Equal(expectedValue, value);
    }
}
