namespace WSPay.Net.Test.Enums
{
    using FluentAssertions;
    using Xunit;
    
    public class ServicesTest
    {
        [Fact]
        public void Configured()
        {
            Services.Completion.Should().Be("Completion");
            Services.Refund.Should().Be("Refund");
            Services.Void.Should().Be("Void");
            Services.StatusCheck.Should().Be("StatusCheck");
            Services.ProcessPayment.Should().Be("ProcessPayment");
        }
    }
}