namespace WLEngine.Graphics.Sprite.Animation; 

public class WlAnimationFrame : IDisposable {
    public readonly int index;
    public readonly float duration;
    public readonly WlSprite sprite;

    public WlAnimationFrame(int index, float duration, WlSprite sprite) {
        this.index = index;
        this.duration = duration;
        this.sprite = sprite;
    }

    public void Dispose() {
        sprite.Dispose();
    }
}