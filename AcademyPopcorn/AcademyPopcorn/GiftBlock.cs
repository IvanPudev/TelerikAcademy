using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        public new const string CollisionGroupString = "block";

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { 'G' } };
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
            IEnumerable<GiftDrop> gift = new List<GiftDrop>();
            if (this.IsDestroyed)
            {
                gift = new List<GiftDrop>()
                {
                    new GiftDrop(this.TopLeft, new MatrixCoords(1, 0)),
                };
            }
            return gift;
        }
    }
}
