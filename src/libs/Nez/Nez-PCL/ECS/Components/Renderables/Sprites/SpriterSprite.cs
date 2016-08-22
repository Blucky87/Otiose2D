

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Nez.Console;
using Nez.SpriterAnimator;


namespace Nez.Sprites
{
  public class SpriterAnimator : RenderableComponent, IUpdatable
  {
    public MonoGameAnimator animator;


    public override RectangleF bounds
    {
      get
      {
        float height = animator.spriterBox.Height * animator.spriterBoxInfo.ScaleY;
        float width =  animator.spriterBox.Width * animator.spriterBoxInfo.ScaleX;
        Vector2 origin = new Vector2(animator.spriterBox.Width, animator.spriterBoxInfo.Y);
        Vector2 postion = new Vector2(animator.spriterBoxInfo.X*-1, animator.spriterBoxInfo.Y);
          float newheight = animator.spriterBoxInfo.Y;
          float newwidth = animator.spriterBoxInfo.X*-1;
        Vector2 newpos = new Vector2(newwidth,newheight);
        _bounds.calculateBounds(entity.transform.position,_localOffset,postion,entity.transform.scale,entity.transform.rotation, width, height);
        return _bounds;
      }
            /*
            get
            {
                float height = animator.spriterBox.Height * animator.spriterBoxInfo.ScaleY;
                float width = animator.spriterBox.Width * animator.spriterBoxInfo.ScaleX;
                Vector2 origin = new Vector2(width, height);
                Vector2 postion = new Vector2(animator.spriterBoxInfo.X, animator.spriterBoxInfo.Y - height);

                _bounds.calculateBounds(entity.transform.position, _localOffset + (postion * -1), origin, entity.transform.scale, entity.transform.rotation, width, height);
                return _bounds;
            }
            */
        }


    public SpriterAnimator(SpriterEntity spriterEntity, IProviderFactory< Nez.SpriterAnimator.Sprite, SoundEffect> factory)
    {
      animator = new MonoGameAnimator(spriterEntity, factory);

     
    }

    public override void render(Graphics graphics, Camera camera)
    {
      animator.Draw(graphics.batcher);
    }

    public void update()
    {
      animator.Position = entity.transform.position;
      animator.Update(Time.deltaTime*1000);
    }
  }
}