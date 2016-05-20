namespace Otiose2D.Input.Setup {

    public class LeftBumperWasReleased : Command {

        public LeftBumperWasReleased(ControllerProfile Profile) {
            controllerProfile = Profile;

        }

        public override void Execute() {
            controllerProfile.LeftBumper.WasReleased();
        }

    }
}