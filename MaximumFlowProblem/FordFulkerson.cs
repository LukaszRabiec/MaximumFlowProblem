namespace MaximumFlowProblem
{
    public class FordFulkerson
    {
        public Edge[,] Network { get; set; }

        private int _size;
        private int[,] _residualGraph;


        public FordFulkerson(int[,] capacityMatrix)
        {
            _size = capacityMatrix.GetLength(0);
            InitializeNetworkAndResidual(capacityMatrix);
        }

        public Edge[,] FindMaximumFlow()
        {


            return Network;
        }

        private void InitializeNetworkAndResidual(int[,] capacityMatrix)
        {
            Network = new Edge[_size, _size];
            _residualGraph = new int[_size, _size];

            for (int vertice = 0; vertice < _size; vertice++)
            {
                for (int neighbour = 0; neighbour < _size; neighbour++)
                {
                    Network[vertice, neighbour].Capacity = capacityMatrix[vertice, neighbour];
                    _residualGraph[vertice, neighbour] = capacityMatrix[vertice, neighbour];
                }
            }
        }
    }
}
