using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public interface IScreen
{
    // interface IScreen, contrato geral para classes screen
    void LoadContent(ContentManager content);
    void Initialize();
    void Update(float deltaTime);
    void Draw(SpriteBatch spriteBatch);
}