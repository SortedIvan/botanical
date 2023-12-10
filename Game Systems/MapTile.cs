using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Project1.Game_Systems
{
    public class MapTile
    {
        private Texture2D _mapTileTextureUnselected;
        private Texture2D _mapTileTextureSelected;
        private SpriteBatch _spriteBatch;
        private Vector2 _position;
        private bool _isSelected = false;

        public MapTile(Texture2D mapTileTextureUnselected,Texture2D mapTileTextureSelected, SpriteBatch spriteBatch, Vector2 initialPosition)
        {
            _mapTileTextureUnselected = mapTileTextureUnselected;
            _mapTileTextureSelected = mapTileTextureSelected;
            _spriteBatch = spriteBatch;
            _position = initialPosition;
        }

        public void Draw()
        {

            if (!_isSelected)
            {
                _spriteBatch.Draw(_mapTileTextureUnselected, _position, Color.White);
            }
            else
            {
                _spriteBatch.Draw(_mapTileTextureSelected, _position, Color.White);
            }

        }

        public void SetTileTextureSelected(Texture2D mapTileTextureSelected)
        {
            _mapTileTextureSelected = mapTileTextureSelected;
        }

        public void SetTileTextureUnselected(Texture2D mapTileTextureUnselected)
        {
            _mapTileTextureUnselected = mapTileTextureUnselected;
        }




    }
}
