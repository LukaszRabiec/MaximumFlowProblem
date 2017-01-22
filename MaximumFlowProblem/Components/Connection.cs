namespace MaximumFlowProblem.Components
{
    public class Connection
    {
        public int From { get; set; }
        public int To { get; set; }

        public Connection(int from, int to)
        {
            From = from;
            To = to;
        }
    }
}
