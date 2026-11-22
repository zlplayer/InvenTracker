using FluentAssertions;
using InvenTracker.Domain.Exceptions;
using Xunit;

namespace InvenTracker.Tests.Domain.Exceptions;

public class UnauthorizedExceptionTests
{
    [Fact]
    public void UnauthorizedExceptionTest()
    {
        var msg = "test error message";

        var exception = new UnauthorizedException(msg);

        exception.Message.Should().Be(msg);
        exception.Should().BeAssignableTo<DomainException>();
    }
}