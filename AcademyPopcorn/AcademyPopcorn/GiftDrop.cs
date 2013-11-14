using System;
using System.Linq;

namespace AcademyPopcorn
{
    class GiftDrop : MovingObject
    {
         public MatrixCoords Speed { get; protected set; }

        public GiftDrop(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] {{'G'}}, speed )
        {
            this.Speed = speed;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "Racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = false;
        }
    }
}
