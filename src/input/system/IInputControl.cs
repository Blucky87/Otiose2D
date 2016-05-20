using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otiose2D.Input
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
