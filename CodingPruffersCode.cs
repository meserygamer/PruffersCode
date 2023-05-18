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
            string PruffersCode = ""; //Код прюфера
            while(edgeList.Count > 1) //Пока количество ребер больше 1 повторяем
                                      //цикл формирования кода прюфера
            {
                FindAllLeaf(); //Находим все листы дерева
                int Minleaf = leafOfTreeList.Min(); //Находим минимальный лист дерева
                for(int i = 0; i < edgeList.Count; i++) //Цикл для удаления ребра с выбранным листом из списка ребер
                                                        //и добавление отца минимального листа в код прюфера
                {
                    if(new Regex($@"^{Minleaf} - \d+").IsMatch(edgeList[i])) //Для нахождения ребра с листом, если лист на первом месте
                    {
                        PruffersCode = PruffersCode + edgeList[i].Split(" - ")[1] + ","; //Добавление отца минимального листа в код прюфера
                        edgeList.RemoveAt(i); //Удаление ребра из списка
                        break;
                    }
                    if (new Regex($@"^\d+ - {Minleaf}").IsMatch(edgeList[i])) //Для нахождения ребра с листом, если лист на втором месте
                    {
                        PruffersCode = PruffersCode + edgeList[i].Split(" - ")[0] + ","; //Добавление отца минимального листа в код прюфера
                        edgeList.RemoveAt(i); //Удаление ребра из списка
                        break;
                    }
                }
            }
            return PruffersCode[..^1]; //Возвращаем весь код прюфера, кроме последнего элемента, так как там всегда запятая
        }
    }
}
