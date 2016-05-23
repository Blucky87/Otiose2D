




using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nez.UI;

namespace Otiose2D.animation
{
    public class AnimationClip
    {
        public string name = "Default";
        public List<AnimationFrame> frames;
        public Texture2D image;
        public WrapMode wrapMode = WrapMode.Loop;
        public float fps = 10f;
        public int startFrame = 0;

        public AnimationClip(string text, Texture2D texture, List<AnimationFrame> animationFrames )
        {
            name = text;
            image = texture;
            frames = animationFrames;
        }
    }

    public enum WrapMode
    {
        /// <summary>
        /// Loop indefinitely
        /// </summary>
        Loop,

        /// <summary>
        /// Start from beginning, and loop a section defined by <see cref="tk2dSpriteAnimationClip.loopStart"/>
        /// </summary>
        LoopSection,

        /// <summary>
        /// Plays the clip once and stops at the last frame
        /// </summary>
        Once,

        /// <summary>
        /// Plays the clip once forward, and then once in reverse, repeating indefinitely
        /// </summary>
        PingPong,

        /// <summary>
        /// Simply choses a random frame and stops
        /// </summary>
        RandomFrame,

        /// <summary>
        /// Starts at a random frame and loops indefinitely from there. Useful for multiple animated sprites to start at a different phase.
        /// </summary>
        RandomLoop,

        /// <summary>
        /// Switches to the selected sprite and stops.
        /// </summary>
        Single
    };
}