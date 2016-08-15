﻿// Copyright (c) 2015 The original author or authors
//
// This software may be modified and distributed under the terms
// of the zlib license.  See the LICENSE file for details.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SpriterDotNet.MonoGame
{
    /// <summary>
    /// MonoGame Animator implementation. It has separate Draw and Update steps. 
    /// During the Update step all spatial infos are calculated (translated from Spriter values) and the Draw step only draws the calculated values.
    /// </summary>
	public class MonoGameAnimator : Animator<Sprite, SoundEffect>
    {
        /// <summary>
        /// Scale factor of the animator. Negative values flip the image.
        /// </summary>
        public virtual Vector2 Scale { get; set; }

        /// <summary>
        /// Rotation in radians.
        /// </summary>
        public virtual float Rotation { get; set; }

        /// <summary>
        /// Position in pixels.
        /// </summary>
        public virtual Vector2 Position { get; set; }

        /// <summary>
        /// The drawing depth. Should be in the [0,1] interval.
        /// </summary>
        public virtual float Depth { get; set; }

        /// <summary>
        /// The depth distance between different sprites of the same animation.
        /// </summary>
        public virtual float DeltaDepth { get; set; }

        protected Stack<DrawInfo> DrawInfoPool { get; set; }
        protected List<DrawInfo> DrawInfos { get; set; }
        protected Matrix Transform { get; set; }

        private static readonly float DefaultDepth = 0.5f;
        private static readonly float DefaultDeltaDepth = -0.000001f;

		public MonoGameAnimator(SpriterEntity entity, IProviderFactory<Sprite, SoundEffect> providerFactory = null) : base(entity, providerFactory)
        {
            DrawInfoPool = new Stack<DrawInfo>();
            DrawInfos = new List<DrawInfo>();

            Scale = Vector2.One;
            DeltaDepth = DefaultDeltaDepth;
            Depth = DefaultDepth;
        }

        /// <summary>
        /// Draws the animation with the given SpriteBatch.
        /// </summary>
        public virtual void Draw(SpriteBatch batch)
        {
            for (int i = 0; i < DrawInfos.Count; ++i)
            {
                DrawInfo di = DrawInfos[i];
				Sprite sprite = di.Sprite;
				batch.Draw(sprite.Texture, di.Position, sprite.SourceRectangle, di.Color, di.Rotation, di.Origin, di.Scale, di.Effects, di.Depth);
                DrawInfoPool.Push(di);
            }
        }

        public override void Update(float deltaTime)
        {
            DrawInfos.Clear();

            Transform = MathHelper.GetMatrix(Scale, Rotation, Position);

            base.Update(deltaTime);
        }

		protected override void ApplySpriteTransform(Sprite sprite, SpriterObject info)
        {
            Vector2 origin;
			if(sprite.Rotation != 0) origin = new Vector2(info.PivotY * sprite.Height, info.PivotX * sprite.Width);
            else origin = new Vector2(info.PivotX * sprite.Width, (1 - info.PivotY) * sprite.Height);
            Vector2 position = new Vector2(info.X, -info.Y);
            Vector2 scale = new Vector2(info.ScaleX, info.ScaleY);
            float rotation = -info.Angle * MathHelper.DegToRad;
            Color color = Color.White * info.Alpha;
            SpriteEffects effects = SpriteEffects.None;

            if ((scale.X * Scale.X) < 0)
            {
                effects |= SpriteEffects.FlipHorizontally;
                origin = new Vector2(sprite.Width - origin.X, origin.Y);
            }

            if ((scale.Y * Scale.Y) < 0)
            {
                effects |= SpriteEffects.FlipVertically;
                origin = new Vector2(origin.X, sprite.Height - origin.Y);
            }

            if (Scale.X < 0)
            {
                position = new Vector2(-position.X, position.Y);
                rotation = -rotation;
            }

            if (Scale.Y < 0)
            {
                position = new Vector2(position.X, -position.Y);
                rotation = -rotation;
            }

            Matrix globalTransform = MathHelper.GetMatrix(scale, rotation, position) * Transform;
            globalTransform.DecomposeMatrix(out scale, out rotation, out position);

            float depth = Depth + DeltaDepth * DrawInfos.Count;
            depth = (depth < 0) ? 0 : (depth > 1) ? 1 : depth;

            DrawInfo di = DrawInfoPool.Count > 0 ? DrawInfoPool.Pop() : new DrawInfo();

			di.Sprite = sprite;
            di.Position = position;
			di.Origin = origin + sprite.OriginDelta;
            di.Scale = scale;
			di.Rotation = rotation + sprite.Rotation;
            di.Color = color;
            di.Effects = effects;
            di.Depth = depth;

            DrawInfos.Add(di);
        }

        protected override void PlaySound(SoundEffect sound, SpriterSound info)
        {
            sound.Play(info.Volume, 0.0f, info.Panning);
        }

        /// <summary>
        /// Class for holding the draw info for a sprite.
        /// </summary>
        protected class DrawInfo
        {
            public Sprite Sprite { get; set; }
            public Vector2 Position { get; set; }
            public Vector2 Origin { get; set; }
            public Vector2 Scale { get; set; }
            public float Rotation { get; set; }
            public Color Color { get; set; }
            public SpriteEffects Effects { get; set; }
            public float Depth { get; set; }
        }
    }
}
