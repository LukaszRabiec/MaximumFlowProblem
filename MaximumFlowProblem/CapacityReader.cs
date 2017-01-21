namespace MaximumFlowProblem
{
    using System.IO;
    using Newtonsoft.Json;

    public static class CapacityReader
    {
        public static int[,] ReadCapacityGraph(string jsonfilePath)
        {
            using (var streamReader = new StreamReader(jsonfilePath))
            {
                return JsonConvert.DeserializeObject<int[,]>(streamReader.ReadToEnd());
            }
        }
    }
}
