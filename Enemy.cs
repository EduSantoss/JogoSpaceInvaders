using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Enemy
{
    public Vector2 _position { get; set; }
    public Texture2D _texture { get; set; }
    public float _speed { get; set; }
    public Vector2 _direction { get; set; }
    private Random _random;

    public Enemy(Texture2D texture, Vector2 position, float velocity, Vector2 directon)
    {
        _texture = texture;
        _position = position;
        _speed = velocity;
        _direction = directon;
    }

    public void Update()
    {
        _random = new Random();
        // Aqui vai ser adicionado a lógica de movimento para o inimigo/inimigos, podendo ainda adicionar coisas como vida e dano

        _position = _position + (_direction * _speed);

        // Verificar limites horizontais da tela
        if (_position.X < 0)
        {
            _position = new Vector2(0, _position.Y);
            _direction = -_direction;
        }
        else if (_position.X > Globals.SCREEN_WIDTH - _texture.Width)
        {
            _position = new Vector2(Globals.SCREEN_WIDTH - _texture.Width, _position.Y);
            _direction = -_direction;
        }

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Color.White);
    }

    public Rectangle Bounds
    {
        get { return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height); }
    }

}