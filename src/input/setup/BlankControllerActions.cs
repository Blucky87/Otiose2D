using Microsoft.Xna.Framework;
using Otiose2D.Input.Setup;

namespace BlankControllerActions
{

 

    internal class Action : ControlBehavior
    {

        private int _charge;

        public Action(PlayerManager playerManager) : base(playerManager)
        {
            _charge = 0;
        }

        public override void IsPressed()
        {
            _charge++;
        }

        public override void WasReleased()
        {
            _charge = 0;
        }

        public override void WasPressed()
        {
            _charge = 1;
        }

    }


    internal class Stick : TwoAxisControlBehavior
    {

        public Stick(PlayerManager playerManager) : base(playerManager)
        {
        }

        public override void IsPressed(Vector2 Axis)
        {
        }

        public override void WasReleased(Vector2 Axis)
        {
        }

        public override void WasPressed(Vector2 Axis)
        {
        }

    }

}
