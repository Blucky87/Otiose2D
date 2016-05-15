namespace Otiose.Input.Setup {

    public class Action1WasReleased : Command {

        public Action1WasReleased(ControllerProfile Profile) {
            controllerProfile = Profile;

        }

        public override void Execute() {
            controllerProfile.Action1.WasReleased();
        }

    }
}