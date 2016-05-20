using System;

namespace Otiose2D.Input
{
    public class UnknownUnityInputDevice : UnityInputDevice
    {
        internal float[] AnalogSnapshot { get; private set; }


        internal UnknownUnityInputDevice(InputDeviceProfile profile, int joystickId)
            : base(profile, joystickId)
        {
            AnalogSnapshot = new float[MaxAnalogs];
        }


        internal void TakeSnapshot()
        {
            for (var i = 0; i < MaxAnalogs; i++)
            {
                var analog = InputControlType.Analog0 + i;
                var analogValue = Utility.ApplySnapping(GetControl(analog).RawValue, 0.5f);
                AnalogSnapshot[i] = analogValue;
            }
        }


        internal UnknownDeviceControl GetFirstPressedAnalog()
        {
            for (var i = 0; i < MaxAnalogs; i++)
            {
                var control = InputControlType.Analog0 + i;

                var analogValue = Utility.ApplySnapping(GetControl(control).RawValue, 0.5f);
                var analogDelta = analogValue - AnalogSnapshot[i];

                Console.Write(analogValue);
                Console.Write(AnalogSnapshot[i]);
                Console.Write(analogDelta);

                if (analogDelta > +1.9f)
                {
                    return new UnknownDeviceControl(control, InputRangeType.MinusOneToOne);
                }

                if (analogDelta < -0.9f)
                {
                    return new UnknownDeviceControl(control, InputRangeType.ZeroToMinusOne);
                }

                if (analogDelta > +0.9f)
                {
                    return new UnknownDeviceControl(control, InputRangeType.ZeroToOne);
                }
            }

            return UnknownDeviceControl.None;
        }


        internal UnknownDeviceControl GetFirstPressedButton()
        {
            for (var i = 0; i < MaxButtons; i++)
            {
                var control = InputControlType.Button0 + i;

                if (GetControl(control).IsPressed)
                {
                    return new UnknownDeviceControl(control, InputRangeType.ZeroToOne);
                }
            }

            return UnknownDeviceControl.None;
        }
    }
}