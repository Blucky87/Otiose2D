using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Otiose2D.Sprites
{
    public class AnimationClipManager
    {
        private Dictionary<string, AnimationClip> Clips;
        private string defaultClip = "Default";
        

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

        public AnimationClip getDefault()
        {
            string clipName;

            if (!String.IsNullOrEmpty(defaultClip) && Clips.ContainsKey(defaultClip))
            {
                clipName = defaultClip;
            }
            else
            {
                clipName = Clips.Keys.ElementAtOrDefault(0);
            }
            
            return Clips[ clipName ];
        }



    }
}