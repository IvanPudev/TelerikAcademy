using System;
using System.Linq;

namespace AcademyPopcorn
{
    class Shrapnel : MovingObject
    {
        public Shrapnel(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] {{'*'}}, speed)
        {
            this.Speed = speed;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

    }
}
