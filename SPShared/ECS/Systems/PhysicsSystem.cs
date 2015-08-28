using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Artemis.System;
using SPShared.ECS.Components;
using Jitter;
using Jitter.Collision;
using Jitter.Collision.Shapes;
using Jitter.Dynamics;
using Artemis.Manager;
using SPShared.ECS.Utilities;
using Jitter.Dynamics.Constraints;

namespace SPShared
{
    [Artemis.Attributes.ArtemisEntitySystem(ExecutionType = ExecutionType.Synchronous, GameLoopType = GameLoopType.Update, Layer = 1)]
    public class PhysicsSystem : IntervalEntitySystem{
        // target: 20 step/s
        public static readonly float TICKS_PER_SECOND = 0.5f;
        public CollisionSystem collisionSystem;
        public World world;

        public PhysicsSystem() : base(TimeSpan.FromSeconds(TICKS_PER_SECOND), Aspect.All(typeof(ECS.Components.PhysicsBody))) {
            collisionSystem = new CollisionSystemSAP();
            world = new World(collisionSystem);
        }

        internal void AddConstraint(Constraint constraint)
        {
            world.AddConstraint(constraint);
        }

        protected override void ProcessEntities(IDictionary<int, Entity> entities)
        {
            world.Step(TICKS_PER_SECOND, true);
        }

        public void AddBody(ECS.Components.PhysicsBody body)
        {
            world.AddBody(body.Body);
        }
    }
}
