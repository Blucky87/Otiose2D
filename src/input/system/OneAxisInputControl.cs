using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nez;

namespace Otiose.Input
{
    public class OneAxisInputControl : InputControlBase
    {
        internal void CommitWithSides(InputControl negativeSide, InputControl positiveSide, ulong updateTick, float deltaTime)
        {
            LowerDeadZone = Math.Max(negativeSide.LowerDeadZone, positiveSide.LowerDeadZone);
            UpperDeadZone = Math.Min(negativeSide.UpperDeadZone, positiveSide.UpperDeadZone);
            Raw = negativeSide.Raw || positiveSide.Raw;
            var value = Utility.ValueFromSides(negativeSide.RawValue, positiveSide.RawValue);
            CommitWithValue(value, updateTick, deltaTime);
        }


        //		internal void CommitWithSides( InputControl negativeSide, InputControl positiveSide, ulong updateTick, float deltaTime, bool invertSides )
        //		{
        //			if (invertSides)
        //			{
        //				CommitWithSides( positiveSide, negativeSide, updateTick, deltaTime );
        //			}
        //			else
        //			{
        //				CommitWithSides( negativeSide, positiveSide, updateTick, deltaTime );
        //			}
        //		}
    }
}