namespace Otiose2D.Input.Setup {
    public class LeftBumperWasPressed : Command {

        public LeftBumperWasPressed(ControllerProfile Profile) {
            controllerProfile = Profile;

        }

        public override void Execute() {
            controllerProfile.LeftBumper.WasPressed();
        }

    }
}