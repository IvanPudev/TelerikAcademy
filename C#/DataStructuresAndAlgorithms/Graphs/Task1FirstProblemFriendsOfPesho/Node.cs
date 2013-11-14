using System;

namespace Task1FirstProblemFriendsOfPesho
{
    class Node : IComparable
    {
        public int ID { get; set; }

        public long DijkstraDistance { get; set; }

        public bool IsHospital { get; set; }

        public Node(int id)
        {
            this.ID = id;
            this.IsHospital = false;
        }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }
}