using Microsoft.Xna.Framework.Input;
using WLEngine.Input.WlGamePad;
using WLEngine.Input.WlKeyboard;
using WLEngine.Input.WlMouse;

namespace WLEngine.Input {
    public class WlInputMapper {
        protected readonly Dictionary<WlAction, WlKey> keyboardMap = new();
        protected readonly Dictionary<WlAction, WlKey> mouseMap = new();
        protected readonly Dictionary<WlAction, WlKey> gamePadMap = new();

        public virtual IEnumerable<WlInputCommand> getKeyboardState(WlKeyboardManager manager) {
            return new List<WlInputCommand>();
        }

        public virtual IEnumerable<WlInputCommand> getMouseState(WlMouseManager manager) {
            return new List<WlInputCommand>();
        }

        public virtual IEnumerable<WlInputCommand> getGamePadState(WlGamePadManager manager) {
            return new List<WlInputCommand>();
        }

        protected void updateAction(WlAction action, WlKey key) {
            if (isKeyboardKey(key)) {
                updateKeyboardMap(action, key);
            }
            else if (isGamePadButton(key)) {
                updateGamepadMap(action, key);
            }
        }

        private static bool isKeyboardKey(WlKey key) => WlKeyboardManager.map(key) != Keys.None;

        private static bool isGamePadButton(WlKey key) => WlGamePadManager.map(key) != Buttons.None;

        private void updateKeyboardMap(WlAction action, WlKey key) => updateMap(keyboardMap, action, key);

        private void updateGamepadMap(WlAction action, WlKey key) => updateMap(gamePadMap, action, key);

        private static void updateMap(Dictionary<WlAction, WlKey> map, WlAction action, WlKey key) {
            var previousAction = (from pair in map where pair.Value == key select pair.Key).FirstOrDefault();

            if (previousAction != null) {
                map[previousAction] = WlKey.None;
            }

            map[action] = key;
        }
    }

    public class WlAction { }
}