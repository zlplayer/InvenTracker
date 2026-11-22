using FluentAssertions;
using InvenTracker.Domain.Exceptions;
using Xunit;

namespace InvenTracker.Tests.Domain.Exceptions;

public class ForbiddenExceptionTests
{
    [Fact]
    public void ForbiddenExceptionTest()
    {
        var msg = "test error message";

        var exception = new ForbiddenException(msg);
        
        exception.Message.Should().Be(msg);
        exception.Should().BeAssignableTo<DomainException>();
    }
}