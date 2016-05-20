namespace Otiose2D.Input.Setup
{
    public abstract class ControllerProfile
    {

        protected PlayerManager _playerManager;
        public ControlBehavior Action1;
        public ControlBehavior Action2;
        public ControlBehavior RightBumper;
        public ControlBehavior LeftBumper;
        public TwoAxisControlBehavior LeftStick;
        public TwoAxisControlBehavior RightStick;

        protected ControllerProfile(PlayerManager PManager)
        {
            _playerManager = PManager;

            LeftStick = new BlankControllerActions.Stick(PManager);
            RightStick = new BlankControllerActions.Stick(PManager);

            Action1 = new BlankControllerActions.Action(PManager);
            Action2 = new BlankControllerActions.Action(PManager);
            RightBumper = new BlankControllerActions.Action(PManager);
            LeftBumper = new BlankControllerActions.Action(PManager);

        }

        public string Name { get; set; }

    }
}