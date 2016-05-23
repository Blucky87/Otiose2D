using System.Collections.Generic;

namespace Otiose2D.animation
{
    public class AnimationClipManager
    {
        private Dictionary<string, AnimationClip> Clips;
        private bool isBaked = false;

        public AnimationClipManager(AnimationClip clip)
        {
            Clips = new Dictionary<string, AnimationClip>();
            addClip(clip);
        }

        public void addClip(AnimationClip newClip)
        {
            Clips.Add(newClip.name, newClip);
        }

        public AnimationClip GetClip(string name)
        {
            return Clips[name];
        }

        private void bake()
        {

        }


    }
}