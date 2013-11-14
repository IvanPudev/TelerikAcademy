using System;
using System.Linq;

namespace TaskFriendsOfPesho
{
    class Connection
    {
        public Node ToNode { get; set; }

        public long Distance { get; set; }

        public Connection(Node toNode, long distance)
        {
            this.ToNode = toNode;
            this.Distance = distance;
        }
    }
}
