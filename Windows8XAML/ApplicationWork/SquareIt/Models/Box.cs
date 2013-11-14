using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareIt.Models
{
    public class Box
    {
        public bool Top { get; set; }

        public bool Bottom { get; set; }

        public bool Left { get; set; }

        public bool Right { get; set; }

        public bool IsFilled { get; set; }
    }
}