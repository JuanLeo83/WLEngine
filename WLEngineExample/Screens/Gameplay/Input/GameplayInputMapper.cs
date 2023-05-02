using System.Collections.Generic;
using WLEngine.Input;
using WLEngine.Input.WlGamePad;
using WLEngine.Input.WlKeyboard;
using WLEngine.Input.WlMouse;

namespace WLEngineExample.Screens.Gameplay.Input {
    public class GameplayInputMapper : WlInputMapper {
        private GameplayAction _quitGameAction = new GameplayAction.QuitGame();
        private GameplayAction _explosionAction = new GameplayAction.Explosion();

        public GameplayInputMapper() {
            keyboardMap.Add(_quitGameAction, WlKey.KeyboardEscape);
            keyboardMap.Add(_explosionAction, WlKey.KeyboardSpace);
        }

        public override IEnumerable<WlInputCommand> getKeyboardState(WlKeyboardManager manager) {
            var commands = new List<Gameplay>();

            if (manager.isKeyPressed(keyboardMap[_quitGameAction])) {
                commands.Add(new Gameplay.GameExit());
            }

            if (manager.isKeyJustPressed(keyboardMap[_explosionAction])) {
                commands.Add(new Gameplay.PlayerShoots());
            }

            return commands;
        }

        public override IEnumerable<WlInputCommand> getMouseState(WlMouseManager manager) {
            var commands = new List<Gameplay>();

            // if (manager.isLeftButtonJustPressed()) {
            // commands.Add(new Gameplay.PlayerShoots());
            // }

            return commands;
        }

        public override IEnumerable<WlInputCommand> getGamePadState(WlGamePadManager manager) {
            var commands = new List<Gameplay>();

            if (manager.isPadJustPressed(WlKey.GPadA)) {
                commands.Add(new Gameplay.PlayerShoots());
            }

            return commands;
        }

        public void updateExplosion(WlKey key) {
            updateAction(_explosionAction, key);
        }

        public void updateQuitGame(WlKey key) {
            updateAction(_quitGameAction, key);
        }
    }
}