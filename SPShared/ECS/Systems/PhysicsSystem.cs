using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Artemis.System;
using SPShared.ECS.Components;

namespace SPShared
{
    class PhysicsSystem : EntityProcessingSystem{
        public PhysicsSystem() : base(Aspect.All(typeof(Transform), typeof(Velocity))) { }

        public override void Process(Entity entity)
        {




            throw new NotImplementedException();
        }
    }
}
