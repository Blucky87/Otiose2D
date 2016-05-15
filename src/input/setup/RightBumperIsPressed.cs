namespace Otiose.Input.Setup {

    public class RightBumperIsPressed : Command {

        public RightBumperIsPressed(ControllerProfile Profile) {
            controllerProfile = Profile;

        }

        public override void Execute() {
            controllerProfile.RightBumper.IsPressed();
        }

    }
}