namespace Otiose2D.Input.Setup {
    public class Action1IsPressed : Command {

        public Action1IsPressed(ControllerProfile Profile) {
            controllerProfile = Profile;

        }

        public override void Execute() {
            controllerProfile.Action1.IsPressed();
        }

    }
}