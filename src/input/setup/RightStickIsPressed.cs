using Microsoft.Xna.Framework;

namespace Otiose2D.Input.Setup {

    public class RightStickIsPressed : Command {

        private Vector2 _axis;

        public RightStickIsPressed(ControllerProfile Profile, Vector2 Axis) {
            controllerProfile = Profile;
            _axis = Axis;
        }

        public override void Execute() {
            controllerProfile.RightStick.IsPressed(_axis);
        }

    }
}