namespace Otiose.Input.Setup {
    public class RightBumperWasReleased : Command {

        public RightBumperWasReleased(ControllerProfile Profile) {
            controllerProfile = Profile;

        }

        public override void Execute() {
            controllerProfile.RightBumper.WasReleased();
        }

    }
}