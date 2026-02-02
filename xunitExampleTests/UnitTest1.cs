namespace xunitExampleTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var math = new MyMath();
            int a = 5; 
            int b = 10;
            int expected = 15;
            // Act
            int result = math.Add(a, b);
            // Assert
            Assert.Equal(expected, result);
        }
    }
}