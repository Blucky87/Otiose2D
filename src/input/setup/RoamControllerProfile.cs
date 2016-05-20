using Otiose2D.Input.Setup;

public class RoamControllerProfile : ControllerProfile
{

    public RoamControllerProfile(PlayerManager PManager) : base(PManager)
    {
        Name = "Roaming Profile";

        LeftStick = new RoamingControllerActions.LeftStick(_playerManager);
        RightStick = new RoamingControllerActions.RightStick(_playerManager);
        Action2 = new RoamingControllerActions.Action2(_playerManager);


    }

}