using Microsoft.Xna.Framework;

namespace WLEngine.Graphics.Sprite.Animation; 

public class WlAnimation : IDisposable {
    private readonly List<WlAnimationFrame> _frames = new();
    private int _currentFrame;
    private float _timeElapsedSinceLastFrame;

    private readonly bool _isLoop;

    public WlAnimation(bool isLoop = true) {
        _isLoop = isLoop;
    }

    public WlAnimation addFrame(WlAnimationFrame frame) {
        _frames.Insert(frame.index, frame);
        return this;
    }

    public WlSprite getFrame(GameTime gameTime) {
        _timeElapsedSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
        if (canShowNextFrame()) {
            setNextFrameIndex();
        }
        return getCurrentFrame().sprite;
    }

    public void reset() {
        _currentFrame = 0;
        _timeElapsedSinceLastFrame = 0f;
    }

    private bool canShowNextFrame() => _timeElapsedSinceLastFrame > getCurrentFrame().duration;

    private void setNextFrameIndex() {
        _currentFrame++;
        _timeElapsedSinceLastFrame = 0f;
        
        if (isEndOfAnimation() && _isLoop) {
            reset();
        }
    }

    private bool isEndOfAnimation() => _currentFrame == _frames.Count;

    private WlAnimationFrame getCurrentFrame() => _frames[_currentFrame];
    
    public void Dispose() {
        foreach (var frame in _frames) {
            frame.Dispose();
        }
    }
}