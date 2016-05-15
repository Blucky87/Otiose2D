using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otiose.Input
{
    interface IInputControl
    {
        bool HasChanged { get; }
        bool IsPressed { get; }
        bool WasPressed { get; }
        bool WasReleased { get; }
        void ClearInputState();
    }
}
