using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Otiose.Input.Setup
{
    public abstract class TwoAxisControlBehavior
    {

        protected PlayerManager _PlayerManager;

        protected TwoAxisControlBehavior(PlayerManager play)
        {
            _PlayerManager = play;
        }

        public abstract void IsPressed(Vector2 Axis);
        public abstract void WasReleased(Vector2 Axis);
        public abstract void WasPressed(Vector2 Axis);

    }
}
