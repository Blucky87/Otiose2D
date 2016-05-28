using Microsoft.Xna.Framework;

namespace Nez.Sprites
{
    public class AnimationFrame
    {
        public Rectangle sourceRect;
        public int spriteId;


        public AnimationFrame(Rectangle rect, int id)
        {
            sourceRect = rect;
            spriteId = id;
        }
    }
}