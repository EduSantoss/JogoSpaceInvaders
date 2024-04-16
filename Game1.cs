using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameSpaceInvaders;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    // Telas
    private IScreen _menuScreen;
    private IScreen _gameScreen;
    private IScreen _currentScreen; 

    // nave espacial
    private Texture2D _spaceShip;
    private Vector2 _positionShip;
    private float _speedShip;
    private Rectangle[]  _framesShip;

    // inimigos 
    private Texture2D _basicEnemie;
    private Vector2 _positionEnemie;
    private Vector2 _directionEnemie;
    private Texture2D _bossEnemie;
    private float _speedEnemie;

    // tiro da nave
    private Texture2D _laser;
    private Texture2D _directionLaser;
    private float _speedLaser;
   

    // movimentaçao da nave
    private KeyboardState _kState;
    
    // index das animaçoes
    private int _index;
    private int _indexShip;
    private double _time;
    private double _timeShip;

    // background
    private Texture2D _background;
    // private Rectangle[] _framesBackground;

    private Random _random;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    public void ChangeScreen(EScreen screenType)
    {
        switch (screenType)
        {
            case EScreen.Menu:
            _currentScreen = _menuScreen;
            break;
            case EScreen.Game:
            _currentScreen = _gameScreen;
            break;      
        }
        _currentScreen.Initialize();
    }

     protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Telas
        _menuScreen = new MenuScreen();
        _menuScreen.LoadContent(Content);

        _gameScreen = new GameScreen();
        _gameScreen.LoadContent(Content);


    
        _spaceShip = Content.Load<Texture2D>("naveespacial");
        // _background = Content.Load<Texture2D>("backgroundspaceship");
        _basicEnemie = Content.Load<Texture2D>("alien (1)");
        _bossEnemie = Content.Load<Texture2D>("alienboss");
        _laser = Content.Load<Texture2D>("laser");

        _currentScreen = _menuScreen;
    }

    protected override void Initialize()
    {
        base.Initialize();
        _random = new Random();

        // _graphics.PreferredBackBufferWidth = 1600;
        // _graphics.PreferredBackBufferHeight = 1000;
        // _graphics.ApplyChanges();
  
        _index = 0;
        _indexShip = 0;
        _time = 0;
        _timeShip = 0;
        // _framesBackground = new Rectangle[2]
        // {
        //     new Rectangle(0, 0, 1600, 1000), new Rectangle(1600, 0, 1600, 1000)
        // };

        _framesShip = new Rectangle[3]
        {
            new Rectangle(0, 0, 128, 128), new Rectangle(128, 0, 128, 128), new Rectangle(256, 0, 128, 128)
        };
  // testar 104      
        // movimentaçao da nave
        _positionShip = new Vector2((_graphics.PreferredBackBufferWidth - _spaceShip.Width + 256) / 2.0f, (_graphics.PreferredBackBufferHeight - _spaceShip.Height) / 2.0f + 300);

        // movimentçao inimigos
        _positionEnemie = new Vector2((_graphics.PreferredBackBufferWidth - _basicEnemie.Width) / 2.0f, 0);
        _directionEnemie = new Vector2(GetRandomX(), 0);
        _speedEnemie = 7f;
        // _directionShip = Vector2.UnitX;
        // _directionShip.Normalize();
        _speedShip = 500f;

        _currentScreen.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        //     Exit();
        
        _currentScreen.Update((int)gameTime.ElapsedGameTime.TotalSeconds);
        
        _time = _time + gameTime.ElapsedGameTime.TotalSeconds;
        _timeShip = _timeShip + gameTime.ElapsedGameTime.TotalSeconds;
        // background animation 
        // if (_time > 0.1){
        //     _time = 0.0;
        //     _index++;
        //     if (_index > 1){
        //         _index = 0;
        //     }
        // }
        // spaceship animation
        if (_timeShip > 0.1){
            _timeShip = 0.0;
            _indexShip++;
            if (_indexShip > 2){
                _indexShip = 0;
            }
        }

        // movimentaçao inimigos basicos
        _positionEnemie = _positionEnemie + (_directionEnemie * _speedEnemie);

        // logica da colisao do projeto com inimigos
        // se tecla espaço for apertada, projetil sera desenhado na posiçao frontal a nave, e saiara reto no eixo Y do projetil, precisar de direçao do projetil mais speed dele, criar colisao do projetil com altura do inimigo, e quando eles coliderem, tirar o inimigo de cena e adicionar um ponto no score, criar booleano para corrigir o update, e logica para quando aparecer o inimigo novamente, posiçao do laser a ser lançado precisa ser igual a posiçao atual da nave

        // colisao com as laterais X
        if (_positionEnemie.X < 0){
            _positionEnemie.X = 0;
            _directionEnemie.X = - _directionEnemie.X;
        }
        else if (_positionEnemie.X > _graphics.PreferredBackBufferWidth - _basicEnemie.Width){
            _positionEnemie.X = _graphics.PreferredBackBufferWidth - _basicEnemie.Width;
            _directionEnemie.X = - _directionEnemie.X;
        }

        // movimentaçao nave
        _kState = Keyboard.GetState();
        if (_kState.IsKeyDown(Keys.A)){
            _positionShip.X -= _speedShip * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        if (_kState.IsKeyDown(Keys.D)){
            _positionShip.X += _speedShip * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        
        // colisao com as laterais X
        if (_positionShip.X < 0){
            _positionShip.X = 0;
        }
        else if (_positionShip.X > _graphics.PreferredBackBufferWidth - _spaceShip.Width + 256){
            _positionShip.X = _graphics.PreferredBackBufferWidth - _spaceShip.Width + 256;
        }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // para posicionar uma imagem animada, com o position, basta retirar o argumento new rectangule
        // o problema disso é que o tamanho da imagem fica o tamanho total das fotos, soluçao que eu encontrei, ja que nao sei se tem outra maneira foi somar na logica o resto dos pixels das imagens, no caso da nave, 260 de 390 totais.

        _spriteBatch.Begin();
        _currentScreen.Draw(_spriteBatch);
        _spriteBatch.Draw(_background, new Rectangle(0, 0, 1600, 1000), _framesBackground[_index], Color.White);
        _spriteBatch.Draw(_basicEnemie, _positionEnemie, Color.White);
        _spriteBatch.Draw(_spaceShip, _positionShip, _framesShip[_indexShip], Color.White);
        _spriteBatch.End();


        base.Draw(gameTime);
    }
     private float GetRandomX()
    {
        return(_random.NextSingle() * 2.0f) - 1.0f;
    }
}
