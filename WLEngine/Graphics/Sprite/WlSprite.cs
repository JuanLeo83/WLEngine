using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace WLEngine.Graphics.Sprite;

public class WlSprite : IDisposable {
    private readonly Texture2D _texture;
    private readonly Size _dimensions;

    private bool _isEnabled = true;

    private Rectangle _destinationRectangle;
    private readonly Rectangle _sourceRectangle;

    public WlSprite(Texture2D texture, int row, int column, int width, int height) {
        _texture = texture;
        _dimensions = new Size(width, height);

        _sourceRectangle = new Rectangle(width * column, height * row, width, height);
        _destinationRectangle = new Rectangle(0, 0, width, height);
    }

    public WlSprite(Texture2D texture, int row = 0, int column = 0) :
        this(texture, row, column, texture.Width, texture.Height) { }

    public Texture2D getTexture() => _texture;

    public Size getDimensions() => _dimensions;

    public void render(SpriteBatch spriteBatch, Vector2 location) {
        if (!_isEnabled) return;

        _destinationRectangle.X = (int)location.X;
        _destinationRectangle.Y = (int)location.Y;
        spriteBatch.Draw(_texture, _destinationRectangle, _sourceRectangle, Color.White);
    }

    public void setEnabled(bool isEnabled) {
        _isEnabled = isEnabled;
    }

    public void Dispose() => _texture.Dispose();
}