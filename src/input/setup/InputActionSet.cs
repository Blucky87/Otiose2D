

namespace Otiose2D.Input.Setup
{
    public class InputActionSet : PlayerActionSet
    {

        public PlayerAction LSUp;
        public PlayerAction LSDown;
        public PlayerAction LSLeft;
        public PlayerAction LSRight;
        public PlayerTwoAxisAction LSMove;

        public PlayerAction RSUp;
        public PlayerAction RSDown;
        public PlayerAction RSLeft;
        public PlayerAction RSRight;
        public PlayerTwoAxisAction RSMove;

        public PlayerAction PlayerAction1;
        public PlayerAction PlayerAction2;
        public PlayerAction PlayerAction3;
        public PlayerAction PlayerAction4;

        public PlayerAction RightBumper;
        public PlayerAction LeftBumper;

        public InputActionSet()
        {

            LSUp = CreatePlayerAction("Left Stick Up");
            LSDown = CreatePlayerAction("Left Stick Down");
            LSLeft = CreatePlayerAction("Left Stick Left");
            LSRight = CreatePlayerAction("Left Stick Right");
            LSMove = CreateTwoAxisPlayerAction(LSLeft, LSRight, LSDown, LSUp);

            RSUp = CreatePlayerAction("Right Stick Up");
            RSDown = CreatePlayerAction("Right Stick Down");
            RSLeft = CreatePlayerAction("Right Stick Left");
            RSRight = CreatePlayerAction("Right Stick Right");
            RSMove = CreateTwoAxisPlayerAction(RSLeft, RSRight, RSDown, RSUp);

            PlayerAction1 = CreatePlayerAction("Player Action 1");
            PlayerAction2 = CreatePlayerAction("Player Action 2");
            PlayerAction3 = CreatePlayerAction("Player Action 3");
            PlayerAction4 = CreatePlayerAction("Player Action 4");
            RightBumper = CreatePlayerAction("Right Bumper");
            LeftBumper = CreatePlayerAction("Left Bumper");
        }


    }

}
