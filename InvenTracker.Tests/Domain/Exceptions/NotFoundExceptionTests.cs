using FluentAssertions;
using InvenTracker.Domain.Exceptions;
using Xunit;

namespace InvenTracker.Tests.Domain.Exceptions;

public class NotFoundExceptionTests
{
    [Fact]
    public void NotFoundException_DziedziczenieTest()
    {
        var msg = "test error message";

        var exception = new NotFoundException(msg);
        
        exception.Message.Should().Be(msg);
        exception.Should().BeAssignableTo<DomainException>(); // to samo co po lewej Assert.IsAssignableFrom<DomainException>(exception);
    }
}