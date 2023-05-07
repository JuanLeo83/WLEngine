using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WLEngine.Event;
using WLEngine.Graphics.Sprite;
using WLEngine.Graphics.Sprite.Animation;
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

    private Texture2D _texture;
    private WlSprite _sprite;
    private WlSpriteSheet _spriteSheet;

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

        loadSpriteSheet();
    }

    protected override void Update(GameTime gameTime) {
        handleInput();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        // _sprite.render(_spriteBatch, new Vector2(30, 30));
        _spriteSheet.play(gameTime, _spriteBatch, new Vector2(30, 30));
        _spriteBatch.End();

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

    private void loadSpriteSheet() {
        _texture = Content.Load<Texture2D>("Sprite/sprites");
        _spriteSheet = new WlSpriteSheet()
            .addAnimation("right", rightAnimation())
            .addAnimation("left", leftAnimation())
            .addAnimation("up", upAnimation())
            .addAnimation("down", downAnimation());
        _spriteSheet.setAnimation("right");
    }

    private WlAnimation rightAnimation() {
        var animation = new WlAnimation();
        animation
            .addFrame(
                new WlAnimationFrame(0, 100f,
                    new WlSprite(_texture, 0, 2, 16, 16)
                )
            )
            .addFrame(
                new WlAnimationFrame(1, 100f,
                    new WlSprite(_texture, 0, 1, 16, 16)
                )
            )
            .addFrame(
                new WlAnimationFrame(2, 100f,
                    new WlSprite(_texture, 0, 0, 16, 16)
                )
            )
            .addFrame(
                new WlAnimationFrame(3, 100f,
                    new WlSprite(_texture, 0, 1, 16, 16)
                )
            );
        return animation;
    }

    private WlAnimation leftAnimation() {
        var animation = new WlAnimation();
        animation
            .addFrame(
                new WlAnimationFrame(0, 20f,
                    new WlSprite(_texture, 0, 2, 16, 16)
                )
            )
            .addFrame(
                new WlAnimationFrame(1, 20f,
                    new WlSprite(_texture, 1, 1, 16, 16)
                )
            )
            .addFrame(
                new WlAnimationFrame(2, 20f,
                    new WlSprite(_texture, 1, 0, 16, 16)
                )
            )
            .addFrame(
                new WlAnimationFrame(3, 20f,
                    new WlSprite(_texture, 1, 1, 16, 16)
                )
            );
        return animation;
    }

    private WlAnimation upAnimation() {
        var animation = new WlAnimation();
        animation
            .addFrame(
                new WlAnimationFrame(0, 20f,
                    new WlSprite(_texture, 0, 2, 16, 16)
                )
            )
            .addFrame(
                new WlAnimationFrame(1, 20f,
                    new WlSprite(_texture, 2, 1, 16, 16)
                )
            )
            .addFrame(
                new WlAnimationFrame(2, 20f,
                    new WlSprite(_texture, 2, 0, 16, 16)
                )
            )
            .addFrame(
                new WlAnimationFrame(3, 20f,
                    new WlSprite(_texture, 2, 1, 16, 16)
                )
            );
        return animation;
    }

    private WlAnimation downAnimation() {
        var animation = new WlAnimation();
        animation
            .addFrame(
                new WlAnimationFrame(0, 20f,
                    new WlSprite(_texture, 0, 2, 16, 16)
                )
            )
            .addFrame(
                new WlAnimationFrame(1, 20f,
                    new WlSprite(_texture, 3, 1, 16, 16)
                )
            )
            .addFrame(
                new WlAnimationFrame(2, 20f,
                    new WlSprite(_texture, 3, 0, 16, 16)
                )
            )
            .addFrame(
                new WlAnimationFrame(3, 20f,
                    new WlSprite(_texture, 3, 1, 16, 16)
                )
            );
        return animation;
    }
}