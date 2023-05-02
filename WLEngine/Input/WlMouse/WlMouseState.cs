using Microsoft.Xna.Framework.Input;

namespace WLEngine.Input.WlMouse; 

public class WlMouseState {
    private MouseState _currentState;
    private MouseState _previousState;

    public WlMouseState() {
        _currentState = Mouse.GetState();
        _previousState = Mouse.GetState();
    }

    public MouseState getCurrent() => _currentState;

    public MouseState getPrevious() => _previousState;
    
    public void update() {
        _previousState = _currentState;
        _currentState = Mouse.GetState();
    }
}