using System;
using Nez;

namespace Otiose2D.Sprites
{
    public class SpriteAnimator : RenderableComponent, IUpdatable
    {
        AnimationClipManager library;
        public AnimationClip currentClip;

        public AnimationFrame currentFrame;
        private AnimationFrame previousFrame;
        private AnimationFrame nextFrame;

        public bool isPlaying = false;

        float _totalElapsedTime;
        float _elapsedDelay;
        int _completedIterations;
        bool _delayComplete;
        bool _isReversed = false;
        bool _isLoopingBackOnPingPong;
        int _completedCycles;
        int _framesPlayed;
        private bool built;

        public override float width
        {
            get { return currentFrame.sourceRect.Width; }
        }

        public override float height
        {
            get { return currentFrame.sourceRect.Height; } 
        }

        public SpriteAnimator(AnimationClipManager clips)
        {
            library = clips;
            currentClip = library.getDefault();
            currentFrame = currentClip.frames[currentClip.animationStartFrame];
        }

        public void reset()
        {
            isPlaying = true;

            currentClip.prepareForUse();
            nextFrame = null;
            previousFrame = null;
            currentFrame = currentClip.frames[currentClip.animationStartFrame];
        }

        public void stop()
        {
            isPlaying = false;
            _totalElapsedTime = 0;
            _elapsedDelay = 0;
            _isLoopingBackOnPingPong = false;
            _completedCycles = 0;
            _framesPlayed = 0;
            _delayComplete = false;
            currentFrame = currentClip.frames[currentClip.animationStartFrame];
        }

        public void pause()
        {
            isPlaying = false;
        }

        public void play()
        {
            if (currentClip == null)
            {
                currentClip = library.getDefault();
            }

            isPlaying = true;
        }

        public void play(string name)
        {
            
            play( library.GetClip(name) );
        }

        public void play(AnimationClip clip)
        {
            play( clip, 0 );
           
        }

        public void play(AnimationClip clip, float startTime)
        {
            currentClip = clip;
            
            isPlaying = true;
        }

        public override void render(Graphics graphics, Camera camera)
        {
//            graphics.batcher.draw(currentClip.image, entity.transform.position + localOffset, currentFrame.sourceRect, color, entity.transform.rotation, origin, entity.transform.scale, spriteEffects, _layerDepth);
        }

        public void update()
        {
            
            if (currentClip == null || !isPlaying || currentClip.PlayMode == PlayMode.RandomFrame || currentClip.PlayMode == PlayMode.Single)
                return;

            // handle delay
            if (!_delayComplete && _elapsedDelay < currentClip.delay)
            {
                _elapsedDelay += Time.deltaTime;
                if (_elapsedDelay >= currentClip.delay)
                    _delayComplete = true;

                return;
            }

            // count backwards if we are going in reverse
            if (_isReversed)
            {
                _totalElapsedTime -= Time.deltaTime;
            }
            else
            {
               if(built)
                    _totalElapsedTime += Time.deltaTime;
            }
            built = true;

            _totalElapsedTime = Mathf.clamp(_totalElapsedTime, 0f, currentClip.totalDuration);
            _completedIterations = Mathf.floorToInt(_totalElapsedTime / currentClip.iterationDuration);
            _completedCycles = Mathf.floorToInt(_totalElapsedTime / currentClip.totalDuration);
            _isLoopingBackOnPingPong = false;


            // handle ping pong loops. if loop is false but pingPongLoop is true we allow a single forward-then-backward iteration
            if (currentClip.PlayMode == PlayMode.PingPong)
            {
                    _isLoopingBackOnPingPong = _completedIterations % 2 != 0;
            }


            var elapsedTime = 0f;

            elapsedTime = _totalElapsedTime % currentClip.iterationDuration;

            // if we arent looping and elapsedTime is 0 we are done. Handle it appropriately
            if ((_totalElapsedTime == 0f && _isReversed) || _completedCycles > currentClip.cycles)
            {
                // the animation is done so fire our event
                //if (onAnimationCompletedEvent != null)
                //    onAnimationCompletedEvent(_currentAnimationKey);

                isPlaying = false;

                switch (currentClip.completionBehavior)
                {
//                    case AnimationCompletionBehavior.RemainOnFinalFrame:
//                        return;
//                    case AnimationCompletionBehavior.RevertToFirstFrame:
//                        currentFrame = currentClip.frames[0];
//                        //origin = _currentAnimation.frames[0].origin;
//                        return;
//                    case AnimationCompletionBehavior.HideSprite:
//                        //subtexture = null;
//                        //_currentAnimation = null;
//                        return;
                }
            }
         

            // if we reversed the animation and we reached 0 total elapsed time handle un-reversing things and loop continuation
            if (_isReversed && _totalElapsedTime <= 0)
            {
                _isReversed = false;

                if (currentClip.PlayMode == PlayMode.Loop)
                {
                    _totalElapsedTime = 0f;
                }
                else
                {
                    // the animation is done so fire our event
                    //if (onAnimationCompletedEvent != null)
                   //     onAnimationCompletedEvent(_currentAnimationKey);

                    isPlaying = false;
                    return;
                }
            }

            // time goes backwards when we are reversing a ping-pong loop
            if (_isLoopingBackOnPingPong )
                elapsedTime = currentClip.iterationDuration - elapsedTime;


            // fetch our desired frame
            var desiredFrame = Mathf.floorToInt(elapsedTime / currentClip.secondsPerFrame);
            if (desiredFrame != currentFrame.spriteId)
            {
                //Console.Write("from frame: " + currentFrame.spriteId);
                currentFrame = currentClip.frames[desiredFrame];
                //Console.Write(" to " + currentFrame.spriteId + "\n" );
                _framesPlayed++;

                if (_framesPlayed == currentClip.frames.Count)
                {
                    _completedIterations++;
                    _framesPlayed = 0;
                }

                //subtexture = _currentAnimation.frames[currentFrame].subtexture;
                //origin = _currentAnimation.frames[currentFrame].origin;
                handleFrameChanged(currentFrame.spriteId);

                // ping-pong needs special care. we don't want to double the frame time when wrapping so we man-handle the totalElapsedTime
                if (currentClip.PlayMode == PlayMode.PingPong && (currentFrame.spriteId == 0 || currentFrame.spriteId == currentClip.frames.Count - 1))
                {
                    if (_isReversed)
                        _totalElapsedTime -= currentClip.secondsPerFrame;
                    else
                        _totalElapsedTime += currentClip.secondsPerFrame;
                }
            }


        }

        private void handleFrameChanged(int num)
        {


        }
    }
}