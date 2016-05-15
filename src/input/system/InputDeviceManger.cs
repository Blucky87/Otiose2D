using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otiose.Input
{
    public abstract class InputDeviceManager
    {
        protected List<InputDevice> devices = new List<InputDevice>();

        public abstract void Update(ulong updateTick, float deltaTime);


        public virtual void Destroy()
        {
        }
    }
}
