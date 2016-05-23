using Microsoft.Xna.Framework;

namespace Otiose2D.animation
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