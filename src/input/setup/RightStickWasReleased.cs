using Microsoft.Xna.Framework;

namespace Otiose2D.Input.Setup {
    public class RightStickWasReleased : Command {
        //test
        private Vector2 _axis;

        public RightStickWasReleased(ControllerProfile Profile, Vector2 Axis) {
            controllerProfile = Profile;
            _axis = Axis;
        }

        public override void Execute() {
            controllerProfile.RightStick.WasReleased(_axis);
        }

    }
}