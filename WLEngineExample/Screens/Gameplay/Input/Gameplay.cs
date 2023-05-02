using WLEngine.Input;

namespace WLEngineExample.Screens.Gameplay.Input {
    public class Gameplay : WlInputCommand {
        public class GameExit : Gameplay { }

        public class PlayerMoveLeft : Gameplay { }

        public class PlayerMoveRight : Gameplay { }

        public class PlayerMoveUp : Gameplay { }

        public class PlayerMoveDown : Gameplay { }

        public class PlayerShoots : Gameplay { }

        public class TestMusic : Gameplay { }

        public class TestMusic2 : Gameplay { }
    }
}