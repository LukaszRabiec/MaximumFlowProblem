namespace MaximumFlowProblem.Tests
{
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    public class FordFulkersonTests
    {
        private ITestOutputHelper _output;

        public FordFulkersonTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SameFlowOfSourceAndOutflowForMatrix1()
        {
            var capacityMatrix = CapacityReader.ReadCapacityGraph("Data/CapacityMatrix1.json");
            var mfp = new FordFulkerson(capacityMatrix);

            var maxFlow = mfp.FindMaximumFlow();
            _output.WriteLine(mfp.ToString());

            maxFlow.ShouldBeEquivalentTo(23);
        }

        [Fact]
        public void SameFlowOfSourceAndOutflowForMatrix2()
        {
            var capacityMatrix = CapacityReader.ReadCapacityGraph("Data/CapacityMatrix2.json");
            var mfp = new FordFulkerson(capacityMatrix);

            var maxFlow = mfp.FindMaximumFlow();
            _output.WriteLine(mfp.ToString());

            maxFlow.ShouldBeEquivalentTo(20);
        }
    }
}
