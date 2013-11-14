using System;
using System.Linq;

namespace AcademyPopcorn
{
    public class IndestructibleBlock : Block
    {
        public const char Symbol = '|';
        public new const string CollisionGroupString = "IndestructibleBlock";

        public IndestructibleBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = IndestructibleBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            //base.RespondToCollision(collisionData);
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }
    }
}
