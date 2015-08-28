using Jitter.Dynamics;
using Jitter.Dynamics.Constraints;
using Jitter.LinearMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPShared.ECS.Utilities
{
    public class Constraint2D : Constraint
    {
        private JVector lockedAxis;
        public Constraint2D(RigidBody body)
            : base(body, null)
        {
            LockedAxis = JVector.Forward;
        }

        public JVector LockedAxis
        {
            get
            {
                return lockedAxis;
            }
            set
            {
                lockedAxis = value;
                if (lockedAxis.LengthSquared() == 0.0f)
                    throw new ArgumentException("Locked Axis can't be zero!");
                lockedAxis.Normalize();
            }
        }

        public override void Iterate()
        {
            JVector bodyLinearVelocity = this.Body1.LinearVelocity;
            float lockedAxisMagnitude = JVector.Dot(lockedAxis, bodyLinearVelocity);
            JVector correctionVelocity = lockedAxisMagnitude * lockedAxis;
            Body1.LinearVelocity = bodyLinearVelocity - correctionVelocity;
        }

        public override void PrepareForIteration(float timestep){ }
    }
}
