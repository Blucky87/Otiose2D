namespace Otiose.Input.Setup {

    public class RightBumperWasPressed : Command {

        public RightBumperWasPressed(ControllerProfile Profile) {
            controllerProfile = Profile;

        }

        public override void Execute() {
            controllerProfile.RightBumper.WasPressed();
        }

    }
}