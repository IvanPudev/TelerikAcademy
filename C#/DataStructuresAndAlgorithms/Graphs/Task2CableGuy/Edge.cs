using System;

namespace Task2CableGuy
{
    public class Edge : IComparable<Edge>
    {

        public Edge(int startHouse, int endHouse, int distance)
        {
            this.StartNode = startHouse;
            this.EndNode = endHouse;
            this.Weight = distance;
        }

        public int StartNode { get; set; }

        public int EndNode { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Edge otherConnection)
        {
            int distanceDifference = this.Weight.CompareTo(otherConnection.Weight);

            if (distanceDifference == 0)
            {
                return this.StartNode.CompareTo(otherConnection.StartNode);
            }

            return distanceDifference;
        }

        public override string ToString()
        {
            string output = string.Format("From house {0} to house {1} -> distance = {2}", this.StartNode, this.EndNode, this.Weight);

            return output;
        }
    }
}