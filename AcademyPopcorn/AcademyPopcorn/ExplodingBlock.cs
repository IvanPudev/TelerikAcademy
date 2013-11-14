using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public new const string CollisionGroupString = "block";

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { 'S' } };
        }

        public override void Update()
        {

        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return Block.CollisionGroupString;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            IEnumerable<Shrapnel> boom = new List<Shrapnel>();
            if (this.IsDestroyed)
            {
                boom = new List<Shrapnel>()
                {
                    new Shrapnel(this.TopLeft, new MatrixCoords(-1,0)),
                    new Shrapnel(this.TopLeft, new MatrixCoords(-1,1)),
                    new Shrapnel(this.TopLeft, new MatrixCoords(0,1)),
                    new Shrapnel(this.TopLeft, new MatrixCoords(1,1)),
                    new Shrapnel(this.TopLeft, new MatrixCoords(1,0)),
                    new Shrapnel(this.TopLeft, new MatrixCoords(1,-1)),
                    new Shrapnel(this.TopLeft, new MatrixCoords(0,-1)),
                    new Shrapnel(this.TopLeft, new MatrixCoords(-1,-1)),
                };
            }
            return boom;
        }
    }
}
