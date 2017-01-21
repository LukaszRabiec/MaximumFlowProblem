namespace MaximumFlowProblem.Tests
{
    using FluentAssertions;
    using Xunit;

    public class NetworkReaderTests
    {
        [Fact]
        public void ReadingMatrixFromJson()
        {
            var correctMatrix = new[,] { { 0, 1 }, { 2, 3 } };

            var readedMatrix = CapacityReader.ReadCapacityGraph("Data/ReaderTest.json");

            readedMatrix.ShouldBeEquivalentTo(correctMatrix);
        }
    }
}
