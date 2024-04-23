using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Projectile
{
    public Vector2 Position { get; set; }
  //  public Rectangle Bounds { get; set; }
    public Vector2 Velocity { get; set; }
    public Texture2D Texture { get; set; }

    public Projectile(Texture2D texture, Vector2 position, Vector2 velocity)
    {
        Texture = texture;
        Position = position;
        Velocity = velocity;
       // Bounds = bounds;
    }

    public void Update()
    {
        Position += Velocity;
    }
         
         // tentar fazer isso abaixo para as animaçoes das imagens !!!!!!!!!!!
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Color.White);
    }

    public Rectangle Bounds
    {
        get { return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); }
    }
}