using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

public class GameObject
{
    // ao ir fazer o menu eu preciso tornar clicavel, o iniciar e o exit game, por isso eles serao objetos do game, confinar a tela a um quadrado diferente, com uma imagem de fundo diferente se possivel.
    // com essa classe da para criar objetos em cena, ou no caso, o proprio menu precisa ser um objeto
    protected Rectangle _bounds;
    protected Texture2D _image;

    public Rectangle Bounds
    {
        get { return _bounds; }
    }
    public int X
    {
        get { return _bounds.X; }
        set { _bounds.X = value; }
    }

    public int Y
    {
        get { return _bounds.Y; }
        set { _bounds.Y = value; }
    }

    public Point Position
    {
        get { return _bounds.Location; }
        set { _bounds.Location = value; }
    }

    public GameObject(Texture2D image)
    {
        _image = image;
        _bounds = new Rectangle(0, 0, _image.Width, _image.Height);
    }

    // uso exemplo: texture2d bg = Content.Load<texture2d>("background");
    // _background = new GameObject(bg);


     public virtual void Initialize()
    {

    }

    public virtual void Update(float deltaTime)
    {

    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_image, _bounds, Color.White);
    }

    // uso: _spriteBatch.Begin();
    // _background.Draw(_spriteBatch);
    // spriteBatch.End();
}