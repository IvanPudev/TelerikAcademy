using System;
using System.Linq;

namespace AcademyPopcorn
{
    class UnstoppableBall : Ball
    {
        public new const string CollisionGroupString = "unstoppableBall";

        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" 
                || otherCollisionGroupString == "IndestructibleBlock" 
                || otherCollisionGroupString == "block"
                || otherCollisionGroupString == "UnpassableBlock";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.Contains("UnpassableBlock") 
                ||collisionData.hitObjectsCollisionGroupStrings.Contains("IndestructibleBlock") 
                ||collisionData.hitObjectsCollisionGroupStrings.Contains("racket"))
            {
                base.RespondToCollision(collisionData);
            }
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

    }
}
