namespace Otiose2D.Input.Setup
{
    public abstract class ControlBehavior
    {

        protected PlayerManager _PlayerManager;

        protected ControlBehavior(PlayerManager play)
        {
            _PlayerManager = play;
        }


        public abstract void IsPressed();
        public abstract void WasReleased();
        public abstract void WasPressed();
    }

}