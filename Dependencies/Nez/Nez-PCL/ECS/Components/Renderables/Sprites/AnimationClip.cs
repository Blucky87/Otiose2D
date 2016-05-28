

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace Nez.Sprites
{
    public class AnimationClip
    {
        public string name = "Default";
        public List<AnimationFrame> frames = new List<AnimationFrame>()
        {
                new AnimationFrame( new Rectangle( 0, 0, 64, 64 ), 0 ),
                new AnimationFrame( new Rectangle( 64, 0, 64, 64 ), 0 ),
                new AnimationFrame( new Rectangle( 128, 0, 64, 64 ), 0 ),
                new AnimationFrame( new Rectangle( 192, 0, 64, 64 ), 0 ),
        };

        public Texture2D image;// = Core.scene.contentManager.Load<Texture2D>("Up_Idle_Breathe");
        public PlayMode PlayMode = PlayMode.Loop;
        private float _fps = 10f;
        public int animationStartFrame = 0;
        public int cycleStartFrame = 0;
        public float delay = 0f;
        public float totalDuration = 0f;
        private bool _hasBeenPreparedForUse = false;
        public float iterationDuration { get; private set; }
        public float secondsPerFrame = 1.0f;
        public int cycles = int.MaxValue;
        public AnimationCompletionBehavior completionBehavior = AnimationCompletionBehavior.RevertToFirstFrame; 

        public AnimationClip(string text, Texture2D texture, List<AnimationFrame> animationFrames )
        {
            name = text;
            image = texture;
            frames = animationFrames;
            prepareForUse();
        }

        public AnimationClip()
        {
            //image = Core.scene.contentManager.Load<Texture2D>("Up_Idle_Breathe");
            prepareForUse();
        }

        public float fps
        {
            get { return _fps; }
            set { _fps = value; prepareForUse(); }
        }


        public void prepareForUse()
        {
            if (_hasBeenPreparedForUse)
                return;

            secondsPerFrame = 1f / fps;
            iterationDuration = secondsPerFrame * (float)frames.Count;

            if (cycles == int.MaxValue || PlayMode == PlayMode.RandomFrame || PlayMode == PlayMode.Single)
                totalDuration = float.PositiveInfinity;
            else if (PlayMode == PlayMode.Loop)
                totalDuration = iterationDuration * cycles;
            else if (PlayMode == PlayMode.PingPong)
                totalDuration = iterationDuration * 2f * cycles;
            else
                totalDuration = float.PositiveInfinity;


            if (PlayMode == PlayMode.RandomFrame)
            {
                int randFrame = Nez.Random.range(0, frames.Count);

                animationStartFrame = randFrame;
            }

            if (PlayMode == PlayMode.Once)
            {
                animationStartFrame = 0;
                cycles = 1;
            }

            _hasBeenPreparedForUse = true;
        }

    }
/*
    public enum AnimationCompletionBehavior
    {
        RemainOnFinalFrame,
        RevertToFirstFrame,
        HideSprite
    }
    */
    public enum PlayMode
    {
        /// <summary>
        /// Loop indefinitely
        /// </summary>
        Loop,

        /// <summary>
        /// Plays the clip once forward, and then once in reverse, repeating indefinitely
        /// </summary>
        PingPong,

        /// <summary>
        /// Starts at a random frame and loops indefinitely from there. Useful for multiple animated sprites to start at a different phase.
        /// </summary>
        RandomLoop,

        //<summary>
        // Plays clip once through 
        //</summary>
        Once,

        /// <summary>
        /// Simply choses a random frame and stops
        /// </summary>
        RandomFrame,

        /// <summary>
        /// Switches to the selected sprite and stops.
        /// </summary>
        Single
    };
}