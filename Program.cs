namespace PruffersCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FileName = "Graph.txt";
            List<string> Rebra = VvodGraphsFromFile.ZapolnMasRebrGraph(FileName);
        }
    }
}