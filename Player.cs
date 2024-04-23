// using Microsoft.Xna.Framework;
// using Microsoft.Xna.Framework.Content;
// using Microsoft.Xna.Framework.Graphics;
// using Microsoft.Xna.Framework.Input;
// public class Player
// {

    
 // todas os metodos q utilizei aqui eram do iscreen, preciso do utilizar os do gameobject!!!


//     // nave espacial
//     private GameObject _player;
  
  
//     private Texture2D[] _spaceShip;
//     private Rectangle _positionShip;
//     private const float _speedShip = 400;
//     // private Rectangle[] _framesShip;

//     // animaçao
//     private int _index;
//     private double _time;

//     public void LoadContent(ContentManager content)
//     {
//         // _spaceShip = content.Load<Texture2D>("naveespacial");
//        // _player = new GameObject (_spaceShip);
//         _spaceShip = new Texture2D[3]
//         {
//            content.Load<Texture2D>("spaceship/naveespacialframe1"), content.Load<Texture2D>("spaceship/naveespacialframe2"),
//            content.Load<Texture2D>("spaceship/naveespacialframe3")
//         };
//         _player = new GameObject(_spaceShip[_index]);
//         // Texture2D[] spaceship = new Texture2D[3] 
//         // {
//         //     content.Load<Texture2D>("Content/naveespacialframe1"), content.Load<Texture2D>("Content/naveespacialframe2"),
//         //     content.Load<Texture2D>("Content/naveespacialframe3")
//         // };
//     }

//     public void Initialize()
//     {  
//         _index = 0;
        
//         // animaçao nave
//         // _framesShip = new Rectangle[3]
//         // {
//         //     new Rectangle(0, 0, 128, 128), new Rectangle(128, 0, 128, 128), new Rectangle(256, 0, 128, 128)
//         // };
        
//          _positionShip = new Rectangle((Globals.SCREEN_WIDTH - _player.Bounds.Width) / 2, (Globals.SCREEN_HEIGHT - _player.Bounds.Height) / 2 + 300, _spaceShip[0].Width, _spaceShip[0].Height);
//         // posiçao inicial nave
//          _player.Position = new Point((Globals.SCREEN_WIDTH - _player.Bounds.Width) / 2, (Globals.SCREEN_HEIGHT - _player.Bounds.Height) / 2 + 300);
        
//     }
    
//     public void Update(float deltaTime)
//     {   
//         Vector2 _playerDirection = Vector2.Zero; 
//         // spaceship animation
//         // testar aqui deltatime
//         if (_time > 0.1){
//             _time = 0.0;
//             _index++;
//             if (_index > 2){
//                 _index = 0;
//             }
//         }

//         // movimentaçao nave
//         if (Input.GetKey(Keys.A)){
//             _playerDirection.X = - _speedShip;
//         }
//         if (Input.GetKey(Keys.D)){
//             _playerDirection.X = _playerDirection.X * _speedShip;
//             _playerDirection.X = - _playerDirection.X;
//         }
        
//         // colisao com as laterais X
//         if (_positionShip.X < 0){
//             _positionShip.X = 0;
//         }
//         else if (_positionShip.X > Globals.SCREEN_WIDTH - _player.Bounds.Width + 256){
//             _positionShip.X = Globals.SCREEN_WIDTH - _player.Bounds.Width + 256;
//         }
//         _player.Update(deltaTime);
//     }

//     // public void Draw(SpriteBatch spriteBatch)
//     // {
//     //    spriteBatch.Draw(_spaceShip[_index], _positionShip, Color.White);
//     //   // _player.Draw(spriteBatch);
//     // }

// }