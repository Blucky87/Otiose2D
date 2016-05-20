
namespace Otiose2D.Input.Setup {

    public class Action1WasPressed : Command {


        public Action1WasPressed(ControllerProfile Profile) {
            controllerProfile = Profile;

        }

        public override void Execute() {
            controllerProfile.Action1.WasPressed();
        }

    }

}