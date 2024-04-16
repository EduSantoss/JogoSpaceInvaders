using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class MenuScreen : IScreen
{
    private Button _playButton;
    private Button _exitButton;

    public void LoadContent(ContentManager content){

        _playButton = new Button(content.Load<Texture2D>("PlayImage"), Play);
        _exitButton = new Button(content.Load<Texture2D>("ExitImage"), Exit);
    }

    public void Initialize(){
        _playButton.Position = new Point((Globals.SCREEN_WIDTH - _playButton.Bounds.Width) / 2, 200);
        _exitButton.Position = new Point((Globals.SCREEN_WIDTH - _exitButton.Bounds.Width) / 2, 250);
    }
    
     public void Update(float deltaTime)
    {
        _playButton.Update(deltaTime);
        _exitButton.Update(deltaTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
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