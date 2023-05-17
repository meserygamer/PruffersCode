using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruffersCode
{
    public static class VvodGraphsFromFile
    {
        /// <summary>
        /// Метод для заполнения списка ребрами из txt файла
        /// </summary>
        /// <param name="FileName">Путь до файла</param>
        /// <returns>Список ребер</returns>
        public static List<string> ZapolnMasRebrGraph(string FileName)
        {
            List<string> Mas = new List<string>(File.ReadAllLines(FileName));
            Mas = new List<string>(ConcatStrInList(Mas).Split(",").Select(a => a.Trim()));
            return Mas;
        }
        /// <summary>
        /// Метод для объединения элементов списка
        /// </summary>
        /// <param name="list">Список для объединения элементов</param>
        /// <returns>Строка результат объединения</returns>
        private static string ConcatStrInList(List<string> list)
        {
            string ResConcat = "";
            foreach(var str in list) ResConcat = ResConcat + str;
            return ResConcat;
        }
    }
}
