using System.CodeDom;
using System.Collections.Generic;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using Otiose2D.animation;
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

            Texture2D img = myScene.contentManager.Load<Texture2D>("DownBreathing");
            Entity entity = myScene.createEntity("first-sprite");

            Rectangle rect = new Rectangle(0,0,64,64);
            Rectangle rect2 = new Rectangle(64, 64, 64, 64);
            Rectangle rect3 = new Rectangle(128, 128, 64, 64);
            Rectangle rect4 = new Rectangle(192, 192, 64, 64);

            List<AnimationFrame> theframes = new List<AnimationFrame>();
            AnimationFrame frame1 = new AnimationFrame("frame", rect, 1);
            AnimationFrame frame2 = new AnimationFrame("frame2", rect, 1);
            AnimationFrame frame3 = new AnimationFrame("frame3", rect, 1);
            AnimationFrame frame4 = new AnimationFrame("frame4", rect, 1);
            theframes.Add(new AnimationFrame("frame", rect, 1));
            theframes.Add(new AnimationFrame("frame2", rect2, 2));
            theframes.Add(new AnimationFrame("frame3", rect3, 3));
            theframes.Add(new AnimationFrame("frame4", rect4, 4));

            AnimationClip clip = new AnimationClip("test", img, theframes );

            AnimationClipManager animManager = new AnimationClipManager(clip);
            
            entity.transform.position = new Vector2(300,300);
            var subtextures = Subtexture.subtexturesFromAtlas(img, 64, 64);
            var spriteAnimation = new SpriteAnimation(subtextures)
            {
                loop = true,
                fps = 10
            };

            Sprite<int> sprite = new Sprite<int>(0, spriteAnimation);
            sprite.renderLayer = -1;
            sprite.addAnimation(0, spriteAnimation);
            entity.addComponent(sprite);
            entity.addComponent(new PlayerInputManager());
            entity.getComponent<Sprite<int>>().play(0);

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
