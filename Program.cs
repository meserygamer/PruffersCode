namespace PruffersCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FileName1 = "Graph.txt";
            string FileName2 = "PruffersCode.txt";
            List<string> Rebra = VvodGraphsFromFile.ZapolnMasRebrGraph(FileName1);
            CodingPruffersCode.GetCodingPruffersCode().EdgeList = Rebra;
            Console.WriteLine(CodingPruffersCode.GetCodingPruffersCode().MakePrufferCode());
            DecodingPruffersCode.GetDecoder().PruffersCode = VvodGraphsFromFile.GetPruffersCodeFromFile(FileName2);
            Console.WriteLine(DecodingPruffersCode.GetDecoder().DecodingCode());
        }
    }
}