using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        public uint LifeTime { get; set; }

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed, uint lifeTime)
            : base(topLeft, speed)
        {
            this.LifeTime = lifeTime;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            return new GameObject[] { new TrailObject(topLeft, new char[,] { { '.' } }, 5) };
        }
    }
}
