using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Otiose2D.Sprites
{
    public class AnimationClip
    {
        public string name = "Default Animation Name";
        public List<AnimationFrame> frames;
        public List<Texture2D> images;

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
            prepareForUse();
        }

        public AnimationClip()
        {
            
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

        Loop,

        PingPong,

        RandomLoop,

        Once,

        RandomFrame,

        Single
    };
}