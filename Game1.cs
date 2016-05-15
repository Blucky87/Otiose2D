using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Otiose
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
	public class Game1 : Core
    {
        protected override void Initialize()
        {
            base.Initialize();

            //Window.ClientSizeChanged += Core.onClientSizeChanged;
            //Window.AllowUserResizing = true;

            // load up your initial scene here
            scene = Scene.createWithDefaultRenderer(Color.MonoGameOrange);
        }
    }
}
