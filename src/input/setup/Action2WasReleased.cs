

namespace Otiose.Input.Setup {
    public class Action2WasReleased : Command {

        public Action2WasReleased(ControllerProfile Profile) {
            controllerProfile = Profile;
        }

        public override void Execute() {
            controllerProfile.Action2.WasReleased();
        }

    }
}