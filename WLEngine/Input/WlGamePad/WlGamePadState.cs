using Microsoft.Xna.Framework.Input;

namespace WLEngine.Input.WlGamePad; 

public class WlGamePadState {
    private readonly int _index;
    
    private GamePadState _currentState;
    private GamePadState _previousState;

    public WlGamePadState(int index = 0) {
        _index = index;
        _currentState = GamePad.GetState(index);
        _previousState = GamePad.GetState(index);
    }

    public GamePadState getCurrent() => _currentState;

    public GamePadState getPrevious() => _previousState;

    public void update() {
        _previousState = _currentState;
        _currentState = GamePad.GetState(_index);
    }
}