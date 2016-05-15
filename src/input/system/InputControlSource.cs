using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otiose.Input
{
    public interface InputControlSource
    {
        float GetValue(InputDevice inputDevice);
        bool GetState(InputDevice inputDevice);
    }
}