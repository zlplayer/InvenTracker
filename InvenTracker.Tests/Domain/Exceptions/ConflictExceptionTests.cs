using FluentAssertions;
using InvenTracker.Domain.Exceptions;
using Xunit;

namespace InvenTracker.Tests.Domain.Exceptions;

public class ConflictExceptionTests
{
    [Fact]
    public void ConflictExceptionTest()
    {
        var msg = "test error message";

        var exception = new ConflictException(msg);

        exception.Message.Should().Be(msg);
        exception.Should().BeAssignableTo<DomainException>();
    }
}