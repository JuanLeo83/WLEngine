using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WLEngine.Event;
using WLEngine.Input;
using WLEngine.Sound;
using WLEngineExample.Screens.Gameplay;
using WLEngineExample.Screens.Gameplay.Input;

namespace WLEngineExample;

public class Game1 : Game {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private WlInputManager _inputManager;
    private GameplayInputMapper _inputMapper;
    
    private WlSoundFxManager _wlSoundFxManager;
    private WlMusicManager _wlMusicManager;

    event EventHandler<WlGameEvent> OnEventNotification;

    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
        _inputMapper = new GameplayInputMapper();
        _inputManager = new WlInputManager(_inputMapper);
        
        _wlSoundFxManager = new WlSoundFxManager(Content);
        _wlMusicManager = new WlMusicManager(Content);
        OnEventNotification += _currentGameState_OnEventNotification;
        
        _inputMapper.updateExplosion(WlKey.KeyboardA);

        base.Initialize();
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        loadSound(new GameplayEvents.PlaySoundEvent(), "explosion");
        loadMusic(new GameplayEvents.PlayMusicEvent(), "musicJazz");
    }

    protected override void Update(GameTime gameTime) {
        handleInput();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

    public void handleInput() {
        _inputManager.getCommands(command => {
            switch (command) {
                case Gameplay.GameExit:
                    notifyEvent(new WlGameEvent.GameQuit());
                    break;
                case Gameplay.PlayerShoots:
                    notifyEvent(new GameplayEvents.PlaySoundEvent());
                    break;
                case Gameplay.TestMusic:
                    notifyEvent(new GameplayEvents.PlayMusicEvent(), WlMusicManager.Action.SetCurrent);
                    break;
                case Gameplay.TestMusic2:
                    notifyEvent(new GameplayEvents.PlayMusicEvent(), WlMusicManager.Action.Play);
                    break;
                // case GameplayInputCommand.PlayerMoveLeft:
                //     _playerSprite.moveLeft();
                //     break;
                // case GameplayInputCommand.PlayerMoveRight:
                //     _playerSprite.moveRight();
                //     break;
                // case GameplayInputCommand.PlayerMoveUp:
                //     _playerSprite.moveUp();
                //     break;
                // case GameplayInputCommand.PlayerMoveDown:
                //     _playerSprite.moveDown();
                //     break;
                // case GameplayInputCommand.PlayerShoots:
                //     shoot();
                //     break;
            }
        });
    }

    void notifyEvent(WlGameEvent eventType, object argument = null) {
        OnEventNotification?.Invoke(this, eventType);

        // foreach (var gameObject in _gameObjects) {
        //     gameObject.OnNotify(eventType);
        // }
        //     
        _wlSoundFxManager.onNotify(eventType, argument);
        _wlMusicManager.onNotify(eventType, argument);
    }

    void _currentGameState_OnEventNotification(object sender, WlGameEvent eventType) {
        switch (eventType) {
            case WlGameEvent.GameQuit:
                Exit();
                break;
        }
    }

    void loadSound(WlGameEvent eventType, string soundName) {
        _wlSoundFxManager.register(eventType, soundName);
    }

    void loadMusic(WlGameEvent eventType, string musicName) {
        _wlMusicManager.register(eventType, musicName, true, 0.2f);
    }
}