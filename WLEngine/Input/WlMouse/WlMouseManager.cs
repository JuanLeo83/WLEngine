using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WLEngine.Input.WlMouse;

public class WlMouseManager {
    private readonly WlMouseState _state = new();

    public void update() => _state.update();

    public void setPosition(int x, int y) => Mouse.SetPosition(x, y);
    
    public void setPosition(Point point) => Mouse.SetPosition(point.X, point.Y);

    public void setCursor(MouseCursor cursor) => Mouse.SetCursor(cursor);

    public bool isLeftButtonPressed() => _state.getCurrent().LeftButton == ButtonState.Pressed;
    
    public bool isCenterButtonPressed() => _state.getCurrent().MiddleButton == ButtonState.Pressed;
    
    public bool isRightButtonPressed() => _state.getCurrent().RightButton == ButtonState.Pressed;

    public bool isLeftButtonReleased() => _state.getCurrent().LeftButton == ButtonState.Released;
    
    public bool isCenterButtonReleased() => _state.getCurrent().MiddleButton == ButtonState.Released;
    
    public bool isRightButtonReleased() => _state.getCurrent().RightButton == ButtonState.Released;

    public bool isLeftButtonJustPressed() => _state.getPrevious().LeftButton == ButtonState.Released &&
                                             _state.getCurrent().LeftButton == ButtonState.Pressed;

    public bool isCenterButtonJustPressed() => _state.getPrevious().MiddleButton == ButtonState.Released &&
                                               _state.getCurrent().MiddleButton == ButtonState.Pressed;

    public bool isRightButtonJustPressed() => _state.getPrevious().RightButton == ButtonState.Released &&
                                              _state.getCurrent().RightButton == ButtonState.Pressed;
    
    public bool isLeftButtonJustReleased() => _state.getPrevious().LeftButton == ButtonState.Pressed &&
                                              _state.getCurrent().LeftButton == ButtonState.Released;
    
    public bool isCenterButtonJustReleased() => _state.getPrevious().MiddleButton == ButtonState.Pressed &&
                                              _state.getCurrent().MiddleButton == ButtonState.Released;
    
    public bool isRightButtonJustReleased() => _state.getPrevious().RightButton == ButtonState.Pressed &&
                                              _state.getCurrent().RightButton == ButtonState.Released;
}