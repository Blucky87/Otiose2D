

using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Otiose2D.animation
{
    public class AnimationClip
    {
        public string name = "Default";
        public List<AnimationFrame> frames;
        public Texture2D image;
        public PlayMode PlayMode = PlayMode.Loop;
        public float fps = 10f;
        public int startFrame = 0;
        public float delay = 0f;
        public float totalDuration = 0f;
        private bool _hasBeenPreparedForUse = false;
        public float secondsPerFrame = 1.0f;
        public float iterationDuration = 0;
        public AnimationCompletionBehavior completionBehavior = AnimationCompletionBehavior.RevertToFirstFrame; 

        public AnimationClip(string text, Texture2D texture, List<AnimationFrame> animationFrames )
        {
            name = text;
            image = texture;
            frames = animationFrames;
            prepareForUse();
        }

        public void prepareForUse()
        {
            if (_hasBeenPreparedForUse)
                return;

            secondsPerFrame = 1f / fps;
            iterationDuration = secondsPerFrame * (float)frames.Count;

            if (PlayMode == PlayMode.Loop)
                totalDuration = float.PositiveInfinity;
            else if (PlayMode == PlayMode.PingPong)
                totalDuration = iterationDuration * 2f;
            else
                totalDuration = iterationDuration;

            _hasBeenPreparedForUse = true;
        }

    }

    public enum AnimationCompletionBehavior
    {
        RemainOnFinalFrame,
        RevertToFirstFrame,
        HideSprite
    }

    public enum PlayMode
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