

using Microsoft.Xna.Framework.Audio;
using Nez.SpriterAnimator;


namespace Nez.Sprites
{
  public class SpriterAnimator : RenderableComponent, IUpdatable
  {
    public MonoGameAnimator animator;

    public override float width
    {
      get
      {
        return animator.spriterBox.Width * animator.spriterBoxInfo.ScaleX;
      }
    }


    public override float height
    {
      get
      {
        return animator.spriterBox.Height * animator.spriterBoxInfo.ScaleY;
      }
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