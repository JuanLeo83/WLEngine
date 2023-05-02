using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace WLEngine.Sound {
    public class WlSoundFxManager : WlSoundManager<SoundEffect, SoundEffect> {
        public WlSoundFxManager(ContentManager contentManager) : base(contentManager, "SoundFx") { }

        protected override void resolveEvent(SoundEffect? sound, object? argument = null) {
            sound?.Play();
        }

        protected override SoundEffect map(SoundEffect resource) => resource;

        public override void dispose() {
            foreach (var sound in bank) {
                sound.Value?.Dispose();
            }
        }
    }
}