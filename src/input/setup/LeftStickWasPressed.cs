using Microsoft.Xna.Framework;

namespace Otiose2D.Input.Setup {
    public class LeftStickWasPressed : Command {

        private Vector2 _axis;

        public LeftStickWasPressed(ControllerProfile Profile, Vector2 Axis) {
            controllerProfile = Profile;
            _axis = Axis;
        }

        public override void Execute() {
            controllerProfile.LeftStick.WasPressed(_axis);
        }

    }
}