using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Textures;

using Otiose2D.Input.Setup;


namespace Otiose2D
{
    public class Game1 : Core
    {
        public Game1() : base() {
            
        }

        private enum temp {
            one,
            two
        };

        Scene otherScene;
        protected override void Initialize()
        {
            InputManager.Setup();

            Window.ClientSizeChanged += Core.onClientSizeChanged;

            //Window.AllowUserResizing = true;

            otherScene = Scene.createWithDefaultRenderer(Color.CornflowerBlue);
            // create our Scene with the DefaultRenderer and a clear color of CornflowerBlue
            var myScene = Scene.createWithDefaultRenderer(Color.CornflowerBlue);

            Texture2D img = myScene.contentManager.Load<Texture2D>("Up_Idle_Breathe");
            AnimationClip clip = new AnimationClip("idle", img, new List<AnimationFrame>()
            {
                new AnimationFrame( new Rectangle( 0, 0, 64, 64 ), 0 ),
                new AnimationFrame( new Rectangle( 64, 0, 64, 64 ), 0 ),
                new AnimationFrame( new Rectangle( 128, 0, 64, 64 ), 0 ),
                new AnimationFrame( new Rectangle( 192, 0, 64, 64 ), 0 ),
            });
            Texture2D img2 = myScene.contentManager.Load<Texture2D>("DownLeft_Idle_Breathe");

            AnimationClip clip2 = new AnimationClip("idle", img2, new List<AnimationFrame>()
            {
                new AnimationFrame( new Rectangle( 0, 0, 64, 64 ), 0 ),
                new AnimationFrame( new Rectangle( 64, 0, 64, 64 ), 0 ),
                new AnimationFrame( new Rectangle( 128, 0, 64, 64 ), 0 ),
                new AnimationFrame( new Rectangle( 192, 0, 64, 64 ), 0 ),
            });


            
            Entity entity = myScene.createEntity("first-sprite");
            AnimationClipManager animManager = new AnimationClipManager(clip);
            SpriteAnimator animator = new SpriteAnimator(animManager);
            //animator.currentClip = clip;
            //animator.currentFrame = animator.currentClip.frames[0];
            
            
            
            entity.transform.position = new Vector2( 300, 300 );

            entity.addComponent(animator);

            entity.getComponent<SpriteAnimator>().play();

            entity.addComponent(new PlayerInputManager());
            

            // set the scene so Nez can take over
            Core.scene = myScene;

            base.Initialize();
        }


        protected override void Update(GameTime gametime) {
            InputManager.Update();
           
            if(Nez.Input.isKeyDown(Keys.Escape))
            {
                
            }

/*            if(Input.isKeyDown(Keys.A)) {
                var img2 = otherScene.contentManager.Load<Texture2D>("DownBreathing");
                var entity2 = otherScene.createEntity("first-sprite");


                entity2.transform.position = new Vector2(100, 100);
                var subtextures2 = Subtexture.subtexturesFromAtlas(img2, 64, 64);
                var spriteAnimation2 = new SpriteAnimation(subtextures2)
                {
                    loop = true,
                    fps = 10
                };

                Sprite<int> sprite2 = new Sprite<int>(0, spriteAnimation2);
                sprite2.renderLayer = -1;
                sprite2.addAnimation(0, spriteAnimation2);
                entity2.addComponent(sprite2);
                entity2.getComponent<Sprite<int>>().play(0);
                Core.scene = otherScene;
            }
*/
            base.Update(gametime);
        }

    }
}
