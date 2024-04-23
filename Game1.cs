using System;
using System.Collections.Generic;
using System.Linq;
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
    //  private Player _player;

    private Texture2D _spaceShip;
    private Vector2 _positionShip;
    private float _speedShip;
    private Rectangle[] _framesShip;



    // inimigos 
      private Enemy _enemies;
 //   private List<Enemy> _enemies;
    private Texture2D _enemyTexture;

    // tiro da nave
    private Texture2D _projectileTexture;
    private List<Projectile> _projectile;
    private bool _isLaserSpaced;

    // pontuaçao
    private int _score;
    private bool _releasedScore;

    // fonte 
    private SpriteFont _font;

    // movimentaçao da nave
    private KeyboardState _kState;

    // index das animaçoes
    private int _index;
    private int _indexShip;
    private double _time;
    private double _timeShip;

    // random 
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

        // atualizar para poo, classes
        // _player = new Player();
        // _player.LoadContent(Content);

        _font = Content.Load<SpriteFont>("arial24");

        _spaceShip = Content.Load<Texture2D>("naveespacial");
        // _background = Content.Load<Texture2D>("backgroundspaceship");
        _enemyTexture = Content.Load<Texture2D>("alien (1)");
        //_bossEnemie = Content.Load<Texture2D>("alienboss");
        _projectileTexture = Content.Load<Texture2D>("laser");

        _currentScreen = _menuScreen;
    }

    protected override void Initialize()
    {
        base.Initialize();
        _random = new Random();

        _graphics.PreferredBackBufferWidth = 1600;
        _graphics.PreferredBackBufferHeight = 1000;
        _graphics.ApplyChanges();

        Globals.SCREEN_WIDTH = _graphics.PreferredBackBufferWidth;
        Globals.SCREEN_HEIGHT = _graphics.PreferredBackBufferHeight;
        Globals.GameInstance = this;

        // projetil
        _projectile = new List<Projectile>();
        // _isLaserSpaced = false;


        // pontuaçao 
        _score = 0;
        _releasedScore = true;

        _index = 0;
        _indexShip = 0;
        _time = 0;
        _timeShip = 0;

        _framesShip = new Rectangle[3]
        {
         new Rectangle(0, 0, 128, 128), new Rectangle(128, 0, 128, 128), new Rectangle(256, 0, 128, 128)
        };


        //  posiçao da nave (versao sem poo)
        _positionShip = new Vector2((_graphics.PreferredBackBufferWidth - _spaceShip.Width + 256) / 2.0f, (_graphics.PreferredBackBufferHeight - _spaceShip.Height) / 2.0f + 300);

        // criaçao de um novo inimigo
         _enemies = new Enemy(_enemyTexture, new Vector2((Globals.SCREEN_WIDTH - _enemyTexture.Width) / 2, 0), 5f, new Vector2(1, 0));
     //   Enemy _enemy = new Enemy(_enemyTexture, new Vector2((Globals.SCREEN_WIDTH - _enemyTexture.Width) / 2, 0), 5f, new Vector2(1, 0));
      //  Enemy _enemy2 = new Enemy(_enemyTexture, new Vector2((Globals.SCREEN_WIDTH - _enemyTexture.Width) / 2, 200), 6f, new Vector2(1, 0));

        // _enemies.Add(_enemy);
        // _enemies.Add(_enemy2);

        _speedShip = 500f;

        _currentScreen.Initialize();
        //  _player.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        _currentScreen.Update((int)gameTime.ElapsedGameTime.TotalSeconds);

        //  float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _time = _time + gameTime.ElapsedGameTime.TotalSeconds;
        _timeShip = _timeShip + gameTime.ElapsedGameTime.TotalSeconds;

        // spaceship animation
        if (_timeShip > 0.1)
        {
            _timeShip = 0.0;
            _indexShip++;
            if (_indexShip > 2)
            {
                _indexShip = 0;
            }
        }

        // logica base para colisao do projeto com inimigos
        // se tecla espaço for apertada, projetil sera desenhado na posiçao frontal a nave, e saiara reto no eixo Y do projetil, precisar de direçao do projetil mais speed dele, criar colisao do projetil com altura do inimigo, e quando eles coliderem, tirar o inimigo de cena e adicionar um ponto no score, criar booleano para corrigir o update, e logica para quando aparecer o inimigo novamente, posiçao do laser a ser lançado precisa ser igual a posiçao atual da nave


        // foreach (var enemy in _enemies.ToList())
        // {
        //     enemy.Update();
        // }
        // Disparar projetil a partir da posiçao da nave ate o inimigo
        if (_kState.IsKeyDown(Keys.Space))
        {
            // ajustar saida do projetil
            Vector2 projectileVelocity = Vector2.Normalize(_enemies._position - _positionShip) * 10f;
            //  Vector2 projectileVelocity = new Vector2( 0 , -_positionShip.Y);
            //  projectileVelocity.Normalize();
            Projectile newProjectile = new Projectile(_projectileTexture, _positionShip, projectileVelocity);
            _projectile.Add(newProjectile);
            // _isLaserSpaced = true;
        }

        // if (_isLaserSpaced)
        // {

        // }

        // atualizar projeteis
        foreach (var projectile in _projectile.ToList())
        {
            projectile.Update();

            // checar para colisao com inimigo
            if (Rectangle.Intersect(projectile.Bounds, _enemies.Bounds) != Rectangle.Empty)
            {
                _score = _score + 1;
                _releasedScore = false;
                _projectile.Remove(projectile);
                //  _enemy.Remove();
            }
            // if (_projectile.Remove(projectile)) {
            //    _releasedScore = true;
            // }
        }

        // movimentaçao nave
        // aqui teria q substituir por classe player.X ou enemie.X, as classes no eixo X e fazer colisao com a tela
        _kState = Keyboard.GetState();
        if (_kState.IsKeyDown(Keys.A))
        {
            _positionShip.X -= _speedShip * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        if (_kState.IsKeyDown(Keys.D))
        {
            _positionShip.X += _speedShip * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        // colisao com as laterais X
        if (_positionShip.X < 0)
        {
            _positionShip.X = 0;
        }
        else if (_positionShip.X > _graphics.PreferredBackBufferWidth - _spaceShip.Width + 256)
        {
            _positionShip.X = _graphics.PreferredBackBufferWidth - _spaceShip.Width + 256;
        }

        //Input.Update();
        _enemies.Update();
        base.Update(gameTime);
        //  _player.Update(deltaTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // para posicionar uma imagem animada, com o position, basta retirar o argumento new rectangule
        // o problema disso é que o tamanho da imagem fica o tamanho total das fotos, soluçao que eu encontrei, ja que nao sei se tem outra maneira foi somar na logica o resto dos pixels das imagens, no caso da nave, 260 de 390 totais.

        _spriteBatch.Begin();
        _currentScreen.Draw(_spriteBatch);
        if (_currentScreen == _gameScreen)
        {
            _spriteBatch.Draw(_spaceShip, _positionShip, _framesShip[_indexShip], Color.White);
            // foreach (var _enemy in _enemies.ToList())
            // {
            //     _enemy.Draw(_spriteBatch);
            // }
            _enemies.Draw(_spriteBatch);
            _spriteBatch.DrawString(_font, "Pontuacao: " + _score.ToString(), new Vector2(100, 600), Color.Yellow);

            foreach (var projectile in _projectile)
            {
                projectile.Draw(_spriteBatch);
            }
        }
        // _spriteBatch.Draw(_basicEnemie, _positionEnemie, Color.White);
        //  _spriteBatch.Draw(_background, new Rectangle(0, 0, 1600, 1000), _framesBackground[_index], Color.White);
        // atualizar para poo em breve, colocar em classes.
        //   _player.Draw(_spriteBatch);
        _spriteBatch.End();


        base.Draw(gameTime);
    }
    public float GetRandomX()
    {
        return (_random.NextSingle() * 2.0f) - 1.0f;
    }
}
