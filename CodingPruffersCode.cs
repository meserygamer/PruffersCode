using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PruffersCode
{
    /// <summary>
    /// Класс кодирования графа, кодом прюфера
    /// </summary>
    public class CodingPruffersCode
    {
        /// <summary>
        /// Ссылка на объект класса в памяти
        /// </summary>
        private static CodingPruffersCode Singleton;
        /// <summary>
        /// Список ребер графа
        /// </summary>
        private List<string>? edgeList = null;
        /// <summary>
        /// Список листьев графа
        /// </summary>
        private List<int> leafOfTreeList;
        /// <summary>
        /// Свойство для задания списка ребер графа
        /// </summary>
        public List<string> EdgeList
        { 
            set => edgeList = value;
        }
        /// <summary>
        /// Приватный конструктор объекта
        /// </summary>
        private CodingPruffersCode()
        {}
        /// <summary>
        /// Метод для получения объекта класса
        /// </summary>
        /// <returns>Ссылка на объект класса в памяти</returns>
        public static CodingPruffersCode GetCodingPruffersCode()
        {
            if(Singleton is null)
            {
                Singleton = new CodingPruffersCode();
                return Singleton;
            }
            else return Singleton;
        }
        /// <summary>
        /// Функция для составления списка листов дерева
        /// </summary>
        private void FindAllLeaf()
        {
            leafOfTreeList = new List<int>();
            List<int> Duplicates = new List<int>();
            foreach(string i in edgeList)
            {
                foreach(int t in i.Split(" - ").Select(i => int.Parse(i)))
                {
                    leafOfTreeList.Add(t);
                }
            }
            foreach(var i in leafOfTreeList.Distinct())
            {
                if(leafOfTreeList.Count(j => j == i) > 1) Duplicates.Add(i);
            }
            foreach(var i in Duplicates)
            {
                leafOfTreeList.RemoveAll(k => k == i);
            }
        }
        /// <summary>
        /// Функция формирования кода прюфера
        /// </summary>
        /// <returns>Код прюфера</returns>
        public string MakePrufferCode()
        {
            string PruffersCode = "";
            while(edgeList.Count > 1)
            {
                FindAllLeaf();
                int Minleaf = leafOfTreeList.Min();
                for(int i = 0; i < edgeList.Count; i++)
                {
                    if(new Regex($@"^{Minleaf} - \d+").IsMatch(edgeList[i]))
                    {
                        PruffersCode = PruffersCode + edgeList[i].Split(" - ")[1] + ",";
                        edgeList.RemoveAt(i);
                        break;
                    }
                    if (new Regex($@"^\d+ - {Minleaf}").IsMatch(edgeList[i]))
                    {
                        PruffersCode = PruffersCode + edgeList[i].Split(" - ")[0] + ",";
                        edgeList.RemoveAt(i);
                        break;
                    }
                }
            }
            return PruffersCode[..^1];
        }
    }
}
