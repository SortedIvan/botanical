using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Project1.Game_Systems
{
    public class Map
    {
        private SpriteBatch _spriteBatch;
        private ContentManager _contentManager;

        private Texture2D _groundUnselected;
        private Texture2D _groundSelected;

        private List<MapTile> _mapTiles = new List<MapTile>();

        public Map(SpriteBatch spriteBatch, ContentManager contentManager)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
        }

        public void LoadContent()
        {
            _groundSelected = this._contentManager.Load<Texture2D>("ground_selected");
            _groundUnselected = this._contentManager.Load<Texture2D>("ground_unselected");

            // Upon loading the content, generate a new map;
            GenerateRandomMap();

        }

        public void Draw()
        {
            DrawMap();
        }

        public void Update()
        {

        }


        private void GenerateRandomMap()
        {
            Vector2 startingPoint = new Vector2(200,100);

            // Generate a 3x3 map
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Vector2 tilePosition = new Vector2(startingPoint.X + i * _groundSelected.Width, startingPoint.Y + j * _groundSelected.Height);
                    MapTile tile = new MapTile(_groundUnselected, _groundSelected, _spriteBatch, tilePosition);
                    _mapTiles.Add(tile);
                }   
            }


        }

        private void DrawMap()
        {
            for (int i = 0; i <  _mapTiles.Count; i++) 
            {
                _mapTiles[i].Draw();
            }
        }




    }


}
