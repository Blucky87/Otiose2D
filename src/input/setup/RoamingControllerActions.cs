using System;
using Microsoft.Xna.Framework;
using Otiose2D.Input.Setup;

namespace RoamingControllerActions
{




    internal class Action2 : ControlBehavior {
        private int num = 0;

        public Action2(PlayerManager playerManager) : base(playerManager)
        {
        }

        public override void IsPressed() {
            num++;
            Console.WriteLine("Action2 is being pressed | Charge at " + num);
        }

        public override void WasReleased() {
            num = 0;
            Console.WriteLine("Action2 was released");
        }

        public override void WasPressed() {
            num = 0;
            Console.WriteLine("Action2 was pressed");
        }

    }

    internal class LeftStick : TwoAxisControlBehavior
    {

        public LeftStick(PlayerManager playerManager) : base(playerManager)
        {

        }

        public override void IsPressed(Vector2 Axis)
        {
            Console.WriteLine("LeftStick is being pressed");
        }

        public override void WasReleased(Vector2 Axis)
        {
            Console.WriteLine("LeftStick was released");
        }

        public override void WasPressed(Vector2 Axis)
        {
            Console.WriteLine("LeftStick was Pressed");
        }

    }

    internal class RightStick : TwoAxisControlBehavior
    {

        public RightStick(PlayerManager playerManager) : base(playerManager)
        {

        }

        public override void IsPressed(Vector2 Axis)
        {
            Console.WriteLine("LeftStick is being pressed");
        }

        public override void WasReleased(Vector2 Axis)
        {
            Console.WriteLine("LeftStick was released");
        }

        public override void WasPressed(Vector2 Axis)
        {
            Console.WriteLine("LeftStick was Pressed");
        }

    }

}