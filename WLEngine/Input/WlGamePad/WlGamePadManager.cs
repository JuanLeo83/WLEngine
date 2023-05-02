using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WLEngine.Input.WlGamePad;

public class WlGamePadManager {
    private readonly WlGamePadState _state = new();

    public void update() => _state.update();

    #region PAD

    public bool isPadPressed(WlKey wlKey) => _state.getCurrent().IsButtonDown(map(wlKey));

    public bool isPadReleased(WlKey wlKey) => _state.getCurrent().IsButtonUp(map(wlKey));

    public bool isPadJustPressed(WlKey wlKey) {
        var button = map(wlKey);
        return _state.getPrevious().IsButtonUp(button) && _state.getCurrent().IsButtonDown(button);
    }

    public bool isPadJustReleased(WlKey wlKey) {
        var button = map(wlKey);
        return _state.getPrevious().IsButtonDown(button) && _state.getCurrent().IsButtonUp(button);
    }

    #endregion

    #region Triggers

    public bool isTriggerPressed(WlKey trigger) => _state.getCurrent().IsButtonDown(map(trigger));

    public bool isTriggerReleased(WlKey trigger) => _state.getCurrent().IsButtonUp(map(trigger));

    public bool isTriggerJustPressed(WlKey trigger) {
        var button = map(trigger);
        return _state.getPrevious().IsButtonUp(button) && _state.getCurrent().IsButtonDown(button);
    }

    public bool isTriggerJustReleased(WlKey trigger) {
        var button = map(trigger);
        return _state.getPrevious().IsButtonDown(button) && _state.getCurrent().IsButtonUp(button);
    }

    #endregion

    #region Buttons

    public bool isButtonPressed(WlKey button) => _state.getCurrent().IsButtonDown(map(button));

    public bool isButtonReleased(WlKey button) => _state.getCurrent().IsButtonUp(map(button));

    public bool isButtonJustPressed(WlKey fButton) {
        var button = map(fButton);
        return _state.getPrevious().IsButtonUp(button) && _state.getCurrent().IsButtonDown(button);
    }

    public bool isButtonJustReleased(WlKey fButton) {
        var button = map(fButton);
        return _state.getPrevious().IsButtonDown(button) && _state.getCurrent().IsButtonUp(button);
    }

    #endregion

    #region Specials

    public bool isSpecialButtonPressed(WlKey button) => _state.getCurrent().IsButtonDown(map(button));

    public bool isSpecialButtonReleased(WlKey button) => _state.getCurrent().IsButtonUp(map(button));

    public bool isSpecialJustPressed(WlKey special) {
        var button = map(special);
        return _state.getPrevious().IsButtonUp(button) && _state.getCurrent().IsButtonDown(button);
    }

    public bool isSpecialJustReleased(WlKey special) {
        var button = map(special);
        return _state.getPrevious().IsButtonDown(button) && _state.getCurrent().IsButtonUp(button);
    }

    #endregion

    #region Sticks

    public Vector2 getLeftStick() => _state.getCurrent().ThumbSticks.Left;

    public Vector2 getRightStick() => _state.getCurrent().ThumbSticks.Right;

    #endregion

    public static Buttons map(WlKey wlKey) {
        return wlKey switch {
            WlKey.GPadLeft => Buttons.DPadLeft,
            WlKey.GPadUp => Buttons.DPadUp,
            WlKey.GPadRight => Buttons.DPadRight,
            WlKey.GPadDown => Buttons.DPadDown,
            WlKey.GPadLeftB => Buttons.LeftShoulder,
            WlKey.GPadLeftT => Buttons.LeftTrigger,
            WlKey.GPadRightB => Buttons.RightShoulder,
            WlKey.GPadRightT => Buttons.RightTrigger,
            WlKey.GPadA => Buttons.A,
            WlKey.GPadB => Buttons.B,
            WlKey.GPadX => Buttons.X,
            WlKey.GPadY => Buttons.Y,
            WlKey.GPadSelect => Buttons.Back,
            WlKey.GPadStart => Buttons.Start,
            _ => Buttons.None
        };
    }
}