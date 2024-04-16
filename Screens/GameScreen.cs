using System.Drawing;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class GameScreen : IScreen
{
    private GameObject _background;
     private Rectangle _framesBackground;

    public void LoadContent(ContentManager content)
    {
        Texture2D backgroundImage = content.Load<Texture2D>("backgroundspaceship");
        _background = new GameObject(backgroundImage);
    }

    public void Initialize()
    {
         _framesBackground = new Rectangle[2]
        {
            new Rectangle(0, 0, 1600, 1000), new Rectangle(1600, 0, 1600, 1000)
        };
    }

    public void Update(float deltaTime)
    {
        if (Input.GetKeyDown(Keys.Escape))
        {
            Globals.GameInstance.ChangeScreen(EScreen.Menu);
        }

         if (_time > 0.1){
            _time = 0.0;
            _index++;
            if (_index > 1){
                _index = 0;
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _background.Draw(spriteBatch);
    }
}