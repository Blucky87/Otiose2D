using Microsoft.Xna.Framework;

namespace Otiose.Input.Setup {

    public class LeftStickWasReleased : Command {
        private Vector2 _axis;


        public LeftStickWasReleased(ControllerProfile Profile, Vector2 Axis) {
            controllerProfile = Profile;
            _axis = Axis;
        }

        public override void Execute() {
            controllerProfile.LeftStick.WasReleased(_axis);
        }

    }
}