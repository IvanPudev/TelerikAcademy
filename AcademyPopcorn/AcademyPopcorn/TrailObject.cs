using System;
using System.Linq;

namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        public uint LifeTime { get; set; }

        public TrailObject(MatrixCoords topLeft, char[,] body, uint lifeTime)
            : base(topLeft, body)
        {
            this.LifeTime = lifeTime;
        }

        public override void Update()
        {
            if (this.LifeTime == 0)
            {
                this.IsDestroyed = true; 
            }
            this.LifeTime--;
        }
    }
}
