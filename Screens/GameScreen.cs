using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class GameScreen : IScreen
{
    private GameObject _background;
    private Texture2D _backgroundImage;
    private Rectangle[] _framesBackground;
    private int _index;
    private double _time;

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

     // background animation 
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
     //   spriteBatch.Draw(_backgroundImage, new Vector2(0, 0), _framesBackground[_index], Color.White);
        
    }
}