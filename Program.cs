namespace PruffersCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FileName1 = "Graph.txt"; //Путь к файлу со списоком ребер графа
            string FileName2 = "PruffersCode.txt"; //Путь к файлу с кодом прюфера
            List<string> Rebra = VvodGraphsFromFile.ZapolnMasRebrGraph(FileName1); //Задание списка ребер графа для
                                                                                   //формирования кода прюфера из файла
            CodingPruffersCode.GetCodingPruffersCode().EdgeList = Rebra; // Передача классу списка ребер
                                                                         // для формирования кода прюфера
            Console.WriteLine(CodingPruffersCode.GetCodingPruffersCode().MakePrufferCode()); //Вывод сформированного кода прюфера
            DecodingPruffersCode.GetDecoder().PruffersCode = VvodGraphsFromFile.GetPruffersCodeFromFile(FileName2); // Передача кода прюфера из файла,
                                                                                                                    // классу для составления ребер графа
            Console.WriteLine(DecodingPruffersCode.GetDecoder().DecodingCode()); //Вывод ребер, сформированного по коду прюфера, графа
        }
    }
}