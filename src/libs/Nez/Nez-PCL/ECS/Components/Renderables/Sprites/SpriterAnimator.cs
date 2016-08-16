

using Microsoft.Xna.Framework.Audio;
using Nez.SpriterAnimator;


namespace Nez.Sprites
{
  public class SpriterAnimator : RenderableComponent, IUpdatable
  {
    public Nez.SpriterAnimator.SpriterAnimator animator;

    public override float width { get { return animator.spriterBox.Width * animator.spriterBoxInfo.ScaleX; } }

    public override RectangleF bounds
    {
      get
      {
        if (true)
        {
          _bounds.calculateBounds(entity.transform.position, _localOffset, _origin, entity.transform.scale, entity.transform.rotation, width * animator.spriterBoxInfo.ScaleX, height * animator.spriterBoxInfo.ScaleY);
          _areBoundsDirty = false;
        }

        return _bounds;
      }
    }


    public override float height
    {
      get
      {


        return animator.spriterBox.Height ;
      }
    }


    public SpriterAnimator(SpriterEntity spriterEntity, IProviderFactory< Nez.SpriterAnimator.Sprite, SoundEffect> factory)
    {
      animator = new Nez.SpriterAnimator.SpriterAnimator(spriterEntity, factory);
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