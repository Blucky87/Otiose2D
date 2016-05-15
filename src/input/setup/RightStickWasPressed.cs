using Microsoft.Xna.Framework;

namespace Otiose.Input.Setup {


    public class RightStickWasPressed : Command {

        private Vector2 _axis;

        public RightStickWasPressed(ControllerProfile Profile, PlayerTwoAxisAction Axis) {
            controllerProfile = Profile;
            _axis = Axis;
        }

        public override void Execute() {
            controllerProfile.RightStick.WasPressed(_axis);
        }

    }
}