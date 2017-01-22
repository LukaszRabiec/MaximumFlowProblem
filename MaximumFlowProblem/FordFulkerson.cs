namespace MaximumFlowProblem
{
    using System.Collections.Generic;
    using System.Linq;
    using Components;

    public class FordFulkerson
    {
        public Canal[,] Network { get; set; }

        private int _size;
        private int[,] _residualGraph;


        public FordFulkerson(int[,] capacityMatrix)
        {
            _size = capacityMatrix.GetLength(0);
            InitializeNetworkAndResidual(capacityMatrix);
        }

        public Canal[,] FindMaximumFlow()
        {
            while (true)
            {
                var path = FindExtensionPath();
                if (PathDoesntExist(path))
                {
                    break;
                }

                var cf = GetResidualCapacity(path);

                AdjustNetworkAndResidualGraph(path, cf);
                ReduceFlow(path);
            }

            return Network;
        }

        private void InitializeNetworkAndResidual(int[,] capacityMatrix)
        {
            Network = new Canal[_size, _size];
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

        private List<Connection> FindExtensionPath()
        {
            var connections = new List<Connection>();



            return connections;
        }

        private bool PathDoesntExist(List<Connection> path)
        {
            return path.Count == 0;
        }

        private int GetResidualCapacity(List<Connection> path)
        {
            //TODO
            return path.Select(connection => _residualGraph[connection.From, connection.To]).Min();
        }

        private void AdjustNetworkAndResidualGraph(List<Connection> path, int cf)
        {
            foreach (var connection in path)
            {
                var from = connection.From;
                var to = connection.To;

                Network[from, to].Flow += cf;
                _residualGraph[from, to] -= cf;
                _residualGraph[to, from] += cf;
            }
        }

        private void ReduceFlow(List<Connection> path)
        {
            foreach (var connection in path)
            {
                if (ExistOpposedFlow(connection))
                {
                    int from = connection.From;
                    int to = connection.To;

                    if (PrimaryFlowSmallerThanOpposed(connection))
                    {
                        from = connection.To;
                        to = connection.From;
                    }

                    Network[from, to].Flow -= Network[to, from].Flow;
                    Network[to, from].Flow = 0;

                    _residualGraph[from, to] += Network[from, to].Flow;
                    _residualGraph[to, from] -= Network[from, to].Flow;
                }
            }
        }

        private bool ExistOpposedFlow(Connection connection)
        {
            return Network[connection.To, connection.From].Flow > 0;
        }

        private bool PrimaryFlowSmallerThanOpposed(Connection connection)
        {
            return Network[connection.From, connection.To].Flow < Network[connection.To, connection.From].Flow;
        }
    }
}
