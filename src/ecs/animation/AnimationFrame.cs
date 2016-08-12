using Microsoft.Xna.Framework;

namespace Otiose2D.Sprites
{
    public class AnimationFrame
    {
        public string sourceImage;
        public Rectangle sourceRect;
        public int spriteId;


        public AnimationFrame(string source, Rectangle rect, int id)
        {
            sourceImage = source;
            sourceRect = rect;
            spriteId = id;
        }
    }
}