using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WLEngine.Graphics.Sprite.Animation;

namespace WLEngine.Graphics.Sprite; 

public class WlSpriteSheet {
    private readonly Dictionary<string, WlAnimation> _animations = new();
    private WlAnimation? _currentAnimation;

    public WlSpriteSheet addAnimation(string name, WlAnimation animation) {
        _animations.Add(name, animation);
        return this;
    }

    public void setAnimation(string name) {
        _currentAnimation?.reset();
        _currentAnimation = _animations[name];
    }

    public void play(GameTime gameTime, SpriteBatch spriteBatch, Vector2 location) {
        var sprite = _currentAnimation?.getFrame(gameTime);
        sprite?.render(spriteBatch, location);
    }
}