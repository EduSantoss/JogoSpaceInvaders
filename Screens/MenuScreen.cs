using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class MenuScreen : IScreen
{
    private Button _playButton;
    private Button _exitButton;
    private GameObject _background;

    public void LoadContent(ContentManager content){

        _playButton = new Button(content.Load<Texture2D>("PlayImage"), Play);
        _exitButton = new Button(content.Load<Texture2D>("ExitImage"), Exit);
        Texture2D backgroundImage = content.Load<Texture2D>("backgroundspaceship");
        _background = new GameObject(backgroundImage);
    }

    public void Initialize(){
        _playButton.Position = new Point((Globals.SCREEN_WIDTH - _playButton.Bounds.Width) / 2, 200);
        _exitButton.Position = new Point((Globals.SCREEN_WIDTH - _exitButton.Bounds.Width) / 2, 500);
    }
    
     public void Update(float deltaTime)
    {
        _background.Update(deltaTime);
        _playButton.Update(deltaTime);
        _exitButton.Update(deltaTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _background.Draw(spriteBatch);
        _playButton.Draw(spriteBatch);
        _exitButton.Draw(spriteBatch);
    }

    private void Play()
    {
        Globals.GameInstance.ChangeScreen(EScreen.Game);
    }

    private void Exit()
    {
        Globals.GameInstance.Exit();
    }
}