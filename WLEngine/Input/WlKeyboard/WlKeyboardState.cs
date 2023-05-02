using Microsoft.Xna.Framework.Input;

namespace WLEngine.Input.WlKeyboard;

public class WlKeyboardState {
    private KeyboardState _currentState;
    private KeyboardState _previousState;

    public WlKeyboardState() {
        _currentState = Keyboard.GetState();
        _previousState = Keyboard.GetState();
    }

    public KeyboardState getCurrent() => _currentState;

    public KeyboardState getPrevious() => _previousState;

    public void update() {
        _previousState = _currentState;
        _currentState = Keyboard.GetState();
    }

}