using Microsoft.Xna.Framework.Input;

namespace WLEngine.Input.WlKeyboard {
    public class WlKeyboardManager {
        private readonly WlKeyboardState _state = new();

        public void update() => _state.update();

        public bool isCapsLockEnabled() => _state.getCurrent().CapsLock;

        public bool isNumLockEnabled() => _state.getCurrent().NumLock;

        public bool isShiftPressed() => _state.getCurrent().IsKeyDown(Keys.LeftShift) ||
                                        _state.getCurrent().IsKeyDown(Keys.RightShift);

        public bool isControlPressed() => _state.getCurrent().IsKeyDown(Keys.LeftControl) ||
                                          _state.getCurrent().IsKeyDown(Keys.RightControl);

        public bool isAltPressed() =>
            _state.getCurrent().IsKeyDown(Keys.LeftAlt) || _state.getCurrent().IsKeyDown(Keys.RightAlt);

        public bool isKeyPressed(WlKey key) => _state.getCurrent().IsKeyDown(map(key));

        public bool isKeyReleased(WlKey key) => _state.getCurrent().IsKeyUp(map(key));

        public bool isKeyJustPressed(WlKey key) =>
            _state.getPrevious().IsKeyUp(map(key)) && _state.getCurrent().IsKeyDown(map(key));

        public bool isKeyJustReleased(WlKey key) =>
            _state.getPrevious().IsKeyDown(map(key)) && _state.getCurrent().IsKeyUp(map(key));

        public bool isAnyKeyJustPressed() => _state.getPrevious().GetPressedKeys().Any();

        public static Keys map(WlKey key) {
            return key switch {
                WlKey.None => Keys.None,
                WlKey.KeyboardBack => Keys.Back,
                WlKey.KeyboardTab => Keys.Tab,
                WlKey.KeyboardEnter => Keys.Enter,
                WlKey.KeyboardPause => Keys.Pause,
                WlKey.KeyboardCapsLock => Keys.CapsLock,
                WlKey.KeyboardKana => Keys.Kana,
                WlKey.KeyboardKanji => Keys.Kanji,
                WlKey.KeyboardEscape => Keys.Escape,
                WlKey.KeyboardImeConvert => Keys.ImeConvert,
                WlKey.KeyboardImeNoConvert => Keys.ImeNoConvert,
                WlKey.KeyboardSpace => Keys.Space,
                WlKey.KeyboardPageUp => Keys.PageUp,
                WlKey.KeyboardPageDown => Keys.PageDown,
                WlKey.KeyboardEnd => Keys.End,
                WlKey.KeyboardHome => Keys.Home,
                WlKey.KeyboardLeft => Keys.Left,
                WlKey.KeyboardUp => Keys.Up,
                WlKey.KeyboardRight => Keys.Right,
                WlKey.KeyboardDown => Keys.Down,
                WlKey.KeyboardSelect => Keys.Select,
                WlKey.KeyboardPrint => Keys.Print,
                WlKey.KeyboardExecute => Keys.Execute,
                WlKey.KeyboardPrintScreen => Keys.PrintScreen,
                WlKey.KeyboardInsert => Keys.Insert,
                WlKey.KeyboardDelete => Keys.Delete,
                WlKey.KeyboardHelp => Keys.Help,
                WlKey.KeyboardD0 => Keys.D0,
                WlKey.KeyboardD1 => Keys.D1,
                WlKey.KeyboardD2 => Keys.D2,
                WlKey.KeyboardD3 => Keys.D3,
                WlKey.KeyboardD4 => Keys.D4,
                WlKey.KeyboardD5 => Keys.D5,
                WlKey.KeyboardD6 => Keys.D6,
                WlKey.KeyboardD7 => Keys.D7,
                WlKey.KeyboardD8 => Keys.D8,
                WlKey.KeyboardD9 => Keys.D9,
                WlKey.KeyboardA => Keys.A,
                WlKey.KeyboardB => Keys.B,
                WlKey.KeyboardC => Keys.C,
                WlKey.KeyboardD => Keys.D,
                WlKey.KeyboardE => Keys.E,
                WlKey.KeyboardF => Keys.F,
                WlKey.KeyboardG => Keys.G,
                WlKey.KeyboardH => Keys.H,
                WlKey.KeyboardI => Keys.I,
                WlKey.KeyboardJ => Keys.J,
                WlKey.KeyboardK => Keys.K,
                WlKey.KeyboardL => Keys.L,
                WlKey.KeyboardM => Keys.M,
                WlKey.KeyboardN => Keys.N,
                WlKey.KeyboardO => Keys.O,
                WlKey.KeyboardP => Keys.P,
                WlKey.KeyboardQ => Keys.Q,
                WlKey.KeyboardR => Keys.R,
                WlKey.KeyboardS => Keys.S,
                WlKey.KeyboardT => Keys.T,
                WlKey.KeyboardU => Keys.U,
                WlKey.KeyboardV => Keys.V,
                WlKey.KeyboardW => Keys.W,
                WlKey.KeyboardX => Keys.X,
                WlKey.KeyboardY => Keys.Y,
                WlKey.KeyboardZ => Keys.Z,
                WlKey.KeyboardLeftWindows => Keys.LeftWindows,
                WlKey.KeyboardRightWindows => Keys.RightWindows,
                WlKey.KeyboardApps => Keys.Apps,
                WlKey.KeyboardSleep => Keys.Sleep,
                WlKey.KeyboardNumPad0 => Keys.NumPad0,
                WlKey.KeyboardNumPad1 => Keys.NumPad1,
                WlKey.KeyboardNumPad2 => Keys.NumPad2,
                WlKey.KeyboardNumPad3 => Keys.NumPad3,
                WlKey.KeyboardNumPad4 => Keys.NumPad4,
                WlKey.KeyboardNumPad5 => Keys.NumPad5,
                WlKey.KeyboardNumPad6 => Keys.NumPad6,
                WlKey.KeyboardNumPad7 => Keys.NumPad7,
                WlKey.KeyboardNumPad8 => Keys.NumPad8,
                WlKey.KeyboardNumPad9 => Keys.NumPad9,
                WlKey.KeyboardMultiply => Keys.Multiply,
                WlKey.KeyboardAdd => Keys.Add,
                WlKey.KeyboardSeparator => Keys.Separator,
                WlKey.KeyboardSubtract => Keys.Subtract,
                WlKey.KeyboardDecimal => Keys.Decimal,
                WlKey.KeyboardDivide => Keys.Divide,
                WlKey.KeyboardF1 => Keys.F1,
                WlKey.KeyboardF2 => Keys.F2,
                WlKey.KeyboardF3 => Keys.F3,
                WlKey.KeyboardF4 => Keys.F4,
                WlKey.KeyboardF5 => Keys.F5,
                WlKey.KeyboardF6 => Keys.F6,
                WlKey.KeyboardF7 => Keys.F7,
                WlKey.KeyboardF8 => Keys.F8,
                WlKey.KeyboardF9 => Keys.F9,
                WlKey.KeyboardF10 => Keys.F10,
                WlKey.KeyboardF11 => Keys.F11,
                WlKey.KeyboardF12 => Keys.F12,
                WlKey.KeyboardF13 => Keys.F13,
                WlKey.KeyboardF14 => Keys.F14,
                WlKey.KeyboardF15 => Keys.F15,
                WlKey.KeyboardF16 => Keys.F16,
                WlKey.KeyboardF17 => Keys.F17,
                WlKey.KeyboardF18 => Keys.F18,
                WlKey.KeyboardF19 => Keys.F19,
                WlKey.KeyboardF20 => Keys.F20,
                WlKey.KeyboardF21 => Keys.F21,
                WlKey.KeyboardF22 => Keys.F22,
                WlKey.KeyboardF23 => Keys.F23,
                WlKey.KeyboardF24 => Keys.F24,
                WlKey.KeyboardNumLock => Keys.NumLock,
                WlKey.KeyboardScroll => Keys.Scroll,
                WlKey.KeyboardLeftShift => Keys.LeftShift,
                WlKey.KeyboardRightShift => Keys.RightShift,
                WlKey.KeyboardLeftControl => Keys.LeftControl,
                WlKey.KeyboardRightControl => Keys.RightControl,
                WlKey.KeyboardLeftAlt => Keys.LeftAlt,
                WlKey.KeyboardRightAlt => Keys.RightAlt,
                WlKey.KeyboardBrowserBack => Keys.BrowserBack,
                WlKey.KeyboardBrowserForward => Keys.BrowserForward,
                WlKey.KeyboardBrowserRefresh => Keys.BrowserRefresh,
                WlKey.KeyboardBrowserStop => Keys.BrowserStop,
                WlKey.KeyboardBrowserSearch => Keys.BrowserSearch,
                WlKey.KeyboardBrowserFavorites => Keys.BrowserFavorites,
                WlKey.KeyboardBrowserHome => Keys.BrowserHome,
                WlKey.KeyboardVolumeMute => Keys.VolumeMute,
                WlKey.KeyboardVolumeDown => Keys.VolumeDown,
                WlKey.KeyboardVolumeUp => Keys.VolumeUp,
                WlKey.KeyboardMediaNextTrack => Keys.MediaNextTrack,
                WlKey.KeyboardMediaPreviousTrack => Keys.MediaPreviousTrack,
                WlKey.KeyboardMediaStop => Keys.MediaStop,
                WlKey.KeyboardMediaPlayPause => Keys.MediaPlayPause,
                WlKey.KeyboardLaunchMail => Keys.LaunchMail,
                WlKey.KeyboardSelectMedia => Keys.SelectMedia,
                WlKey.KeyboardLaunchApplication1 => Keys.LaunchApplication1,
                WlKey.KeyboardLaunchApplication2 => Keys.LaunchApplication2,
                WlKey.KeyboardOemSemicolon => Keys.OemSemicolon,
                WlKey.KeyboardOemPlus => Keys.OemPlus,
                WlKey.KeyboardOemComma => Keys.OemComma,
                WlKey.KeyboardOemMinus => Keys.OemMinus,
                WlKey.KeyboardOemPeriod => Keys.OemPeriod,
                WlKey.KeyboardOemQuestion => Keys.OemQuestion,
                WlKey.KeyboardOemTilde => Keys.OemTilde,
                WlKey.KeyboardChatPadGreen => Keys.ChatPadGreen,
                WlKey.KeyboardChatPadOrange => Keys.ChatPadOrange,
                WlKey.KeyboardOemOpenBrackets => Keys.OemOpenBrackets,
                WlKey.KeyboardOemPipe => Keys.OemPipe,
                WlKey.KeyboardOemCloseBrackets => Keys.OemCloseBrackets,
                WlKey.KeyboardOemQuotes => Keys.OemQuotes,
                WlKey.KeyboardOem8 => Keys.Oem8,
                WlKey.KeyboardOemBackslash => Keys.OemBackslash,
                WlKey.KeyboardProcessKey => Keys.ProcessKey,
                WlKey.KeyboardOemCopy => Keys.OemCopy,
                WlKey.KeyboardOemAuto => Keys.OemAuto,
                WlKey.KeyboardOemEnlW => Keys.OemEnlW,
                WlKey.KeyboardAttn => Keys.Attn,
                WlKey.KeyboardCrsel => Keys.Crsel,
                WlKey.KeyboardExsel => Keys.Exsel,
                WlKey.KeyboardEraseEof => Keys.EraseEof,
                WlKey.KeyboardPlay => Keys.Play,
                WlKey.KeyboardZoom => Keys.Zoom,
                WlKey.KeyboardPa1 => Keys.Pa1,
                WlKey.KeyboardOemClear => Keys.OemClear,
                _ => Keys.None
            };
        }
    }
}