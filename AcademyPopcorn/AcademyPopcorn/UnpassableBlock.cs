using System;
using System.Linq;

namespace AcademyPopcorn
{
    class UnpassableBlock : Block
    {
        public new const string CollisionGroupString = "UnpassableBlock";

        public UnpassableBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { 'Z' } };
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "UnstoppableBall";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = false;
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
    }
}
