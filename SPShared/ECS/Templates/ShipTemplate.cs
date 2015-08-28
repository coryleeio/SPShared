using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using SPShared.ECS.Components;
using Jitter.Collision.Shapes;
using SPShared.ECS.Utilities;

namespace SPShared.ECS.Templates
{
    [Artemis.Attributes.ArtemisEntityTemplate("Ship")]
    public class ShipTemplate : Artemis.Interface.IEntityTemplate
    {
        public static Shape shipShape = new SphereShape(10f);
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            PhysicsBody body = entity.AddComponentFromPool<SPShared.ECS.Components.PhysicsBody>();
            body.Body.Shape = shipShape;
            PhysicsSystem physicsSystem = entityWorld.SystemManager.GetSystem<PhysicsSystem>();
            physicsSystem.AddBody(body);
            physicsSystem.AddConstraint(new Constraint2D(body.Body));
            return entity;
        }
    }
}
