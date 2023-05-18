using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruffersCode
{
    /// <summary>
    /// Класс декодировки кода прюфера
    /// </summary>
    public class DecodingPruffersCode
    {
        /// <summary>
        /// Ссылка на экземпяр класса
        /// </summary>
        private static DecodingPruffersCode? singleton;
        /// <summary>
        /// Список вершин дерева
        /// </summary>
        private List<int> ListNodeOfTree;
        /// <summary>
        /// Код прюфера, который необходимо декодировать
        /// </summary>
        public List<int> PruffersCode { get; set; }
        /// <summary>
        /// Приватный конструктор класса
        /// </summary>
        private DecodingPruffersCode(){ }
        /// <summary>
        /// Функция для получения экземпляра класса
        /// </summary>
        /// <returns>экземпляр класса</returns>
        public static DecodingPruffersCode GetDecoder()
        {
            if(singleton is null)
            {
                singleton = new DecodingPruffersCode();
                return singleton;
            }
            else return singleton;
        }
        /// <summary>
        /// Функция для поиска вершин не задействованных в коде прюфера
        /// </summary>
        /// <returns>Список вершин не задействованных в коде прюфера</returns>
        private List<int> FindAllNodeNotInPruffersCode()
        {
            List<int> nodes = new List<int>();
            foreach(int node in ListNodeOfTree)
            {
                if(PruffersCode.All(a => a != node))
                {
                    nodes.Add(node);
                }
            }
            return nodes;
        }
        /// <summary>
        /// Функция декодировки кода прюфера
        /// </summary>
        /// <returns>Список рёбер графа</returns>
        public string DecodingCode()
        {
            ListNodeOfTree = Enumerable.Range(1, PruffersCode.Count+2).ToList(); //Формирует список вершин графа
            string ListOfEdges = ""; //Список ребер графа
            List<int> NodeNotInPruffersCode; //Список вершин не задействованных в коде прюфера
            while(PruffersCode.Count != 0) //Будем составлять ребра пока не закончится код прюфера
            {
                NodeNotInPruffersCode = FindAllNodeNotInPruffersCode(); //Составление списка вершин не находящихся в коде прюфера
                ListOfEdges = ListOfEdges + PruffersCode[0] + " - " + NodeNotInPruffersCode.Min() + ","; //Формируем ребро из первого элемента кода прюфера
                                                                                                         //и минимальной вершины вне кода прюфера
                PruffersCode.RemoveAt(0); //Удаляем первый элемент из кода прюфера, так как уже использовали
                ListNodeOfTree.Remove(NodeNotInPruffersCode.Min()); //Удаляем использованную, минимальную вершину
            }
            ListOfEdges = ListOfEdges + ListNodeOfTree[0] + " - " + ListNodeOfTree[1]; //Остаётся 2 вершины в списке, формируем из них ребро
            return ListOfEdges; //Возвращаем список ребер
        }
    }
}
