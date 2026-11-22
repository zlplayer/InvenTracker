using FluentAssertions;
using InvenTracker.Domain.Exceptions;
using Xunit;

namespace InvenTracker.Tests.Domain.Exceptions;

public class DomainExceptionTests
{
    [Fact]
    public void DomainException_ShouldHaveCorrectMessage()
    {
        // Arrange
        var msg = "test error message";
        
        // Act
        var exception = new DomainException(msg);

        // Assert
        // FluentAssertions                                                                                                                                                                                                                                                                                              
        exception.Message.Should().Be(msg);                                                                                                                                                                                                                                                                     
                                                                                                                                                                                                                                                                                                                   
        // xUnit Assert                                                                                                                                                                                                                                                                                                  
        //Assert.Equal(msg, exception.Message);

    }
}