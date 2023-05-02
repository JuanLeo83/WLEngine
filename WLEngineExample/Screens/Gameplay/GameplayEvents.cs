using WLEngine.Event;

namespace WLEngineExample.Screens.Gameplay {
    public class GameplayEvents : WlGameEvent {
        public class PlaySoundEvent : GameplayEvents { }
        public class PlayMusicEvent : GameplayEvents { }
    }
}