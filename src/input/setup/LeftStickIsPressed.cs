using Microsoft.Xna.Framework;

namespace Otiose.Input.Setup {
    public class LeftStickIsPressed : Command {

        private Vector2 _axis;

        public LeftStickIsPressed(ControllerProfile Profile, Vector2 Axis) {
            controllerProfile = Profile;
            _axis = Axis;
        }

        public override void Execute() {
            controllerProfile.LeftStick.IsPressed(_axis);
        }

    }
}