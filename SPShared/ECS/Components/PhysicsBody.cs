using Artemis;
using Jitter.Collision.Shapes;
using Jitter.Dynamics;
using Jitter.LinearMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPShared.ECS.Components
{
    [Artemis.Attributes.ArtemisComponentPool(InitialSize = 20, IsResizable = true, ResizeSize = 20, IsSupportMultiThread = false)]
    public class PhysicsBody : ComponentPoolable
    {
        public Jitter.Dynamics.RigidBody Body { get; }

        public PhysicsBody() : this(new SphereShape(1f)) { }
        public PhysicsBody(Shape shape)
        {
            this.Body = new Jitter.Dynamics.RigidBody(shape);
        }

        public JVector Position
        {
            get { return this.Body.Position; }
            set { this.Body.Position = value; }
        }

        public JMatrix Orientation
        {
            get { return this.Body.Orientation; }
            set { this.Body.Orientation = value; }
        }
    }
}
