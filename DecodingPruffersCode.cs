using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruffersCode
{
    public class DecodingPruffersCode
    {
        private static DecodingPruffersCode? singleton;
        private List<int> ListNodeOfTree;
        public List<int> PruffersCode { get; set; }
        private DecodingPruffersCode(){ }
        public static DecodingPruffersCode GetDecoder()
        {
            if(singleton is null)
            {
                singleton = new DecodingPruffersCode();
                return singleton;
            }
            else return singleton;
        }
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
        public string DecodingCode()
        {
            ListNodeOfTree = Enumerable.Range(1, PruffersCode.Count+2).ToList();
            string ListOfEdges = "";
            List<int> NodeNotInPruffersCode;
            while(PruffersCode.Count != 0)
            {
                NodeNotInPruffersCode = FindAllNodeNotInPruffersCode();
                ListOfEdges = ListOfEdges + PruffersCode[0] + " - " + NodeNotInPruffersCode.Min() + ",";
                PruffersCode.RemoveAt(0);
                ListNodeOfTree.Remove(NodeNotInPruffersCode.Min());
            }
            ListOfEdges = ListOfEdges + ListNodeOfTree[0] + " - " + ListNodeOfTree[1];
            return ListOfEdges;
        }
    }
}
