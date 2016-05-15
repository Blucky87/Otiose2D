



namespace Otiose.Input.Setup {

    public class Action2WasPressed : Command {

        public Action2WasPressed(ControllerProfile Profile) {
            controllerProfile = Profile;
        }

        public override void Execute() {
            controllerProfile.Action2.WasPressed();
        }

    }
}

