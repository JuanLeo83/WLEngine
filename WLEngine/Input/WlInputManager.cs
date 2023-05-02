using WLEngine.Input.WlGamePad;
using WLEngine.Input.WlKeyboard;
using WLEngine.Input.WlMouse;

namespace WLEngine.Input {
    public class WlInputManager {
        private readonly WlKeyboardManager _keyboardManager = new();
        private readonly WlMouseManager _mouseManager = new();
        private readonly WlGamePadManager _gamePadManager = new();

        private readonly WlInputMapper _inputMapper;

        public WlInputManager(WlInputMapper inputMapper) {
            _inputMapper = inputMapper;
        }

        public void getCommands(Action<WlInputCommand> actOnState) {
            updateManagers();

            foreach (var command in _inputMapper.getKeyboardState(_keyboardManager)) {
                actOnState(command);
            }

            foreach (var command in _inputMapper.getMouseState(_mouseManager)) {
                actOnState(command);
            }

            foreach (var command in _inputMapper.getGamePadState(_gamePadManager)) {
                actOnState(command);
            }
        }

        private void updateManagers() {
            _keyboardManager.update();
            _mouseManager.update();
            _gamePadManager.update();
        }
    }
}