namespace Otiose.Input.Setup {
    public class LeftBumperIsPressed : Command {

        public LeftBumperIsPressed(ControllerProfile Profile) {
            controllerProfile = Profile;

        }

        public override void Execute() {
            controllerProfile.LeftBumper.IsPressed();
        }

    }
}