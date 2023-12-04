
namespace IND_KDM.Graphs.Base
{
    public class Edge
    {
        private Node _node1;
        private Node _node2;
        private bool _hasWeight = false;
        private int _weight = 1;

        public Node Node1 => _node1;
        public Node Node2 => _node2;
        public bool HasWeight => _hasWeight;
        public int Weight {
            get => _weight;
            set
            {
                _hasWeight = true;
                _weight = value;
            }
        }

        public Edge(Node node1, Node node2)
        {
            _node1 = node1;
            _node2 = node2;
        }

        public Edge(Node node1, Node node2, int weight) : this(node1, node2)
        {
            Weight = weight;
        }

        public void RemoveWeight()
        {
            _hasWeight = false;
            _weight = 0;
        }
    }
}
