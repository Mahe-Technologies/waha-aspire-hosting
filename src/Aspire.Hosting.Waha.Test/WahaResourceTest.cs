namespace Aspire.Hosting.Waha.Test
{
    public class WahaResourceTest
    {
        [Theory]
        [InlineData("TestResource1")]
        [InlineData("TestResource2")]
        public void Constructor_ShouldInitializeName(string resourceName)
        {
            // Act
            var resource = new WahaResource(resourceName);

            // Assert
            Assert.Equal(resourceName, resource.Name);
        }

        [Fact]
        public void PrimaryEndpoint_ShouldReturnEndpointReference()
        {
            // Arrange
            var resource = new WahaResource("TestResource");

            // Act
            var primaryEndpoint = resource.PrimaryEndpoint;

            // Assert
            Assert.NotNull(primaryEndpoint);
            Assert.Equal(resource, primaryEndpoint.Resource);
        }
    }
}