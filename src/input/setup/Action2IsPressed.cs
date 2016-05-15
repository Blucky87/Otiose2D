namespace Otiose.Input.Setup {
    public class Action2IsPressed : Command {

        public Action2IsPressed(ControllerProfile Profile) {
            controllerProfile = Profile;
        }

        public override void Execute() {
            controllerProfile.Action2.IsPressed();
        }

    }

}