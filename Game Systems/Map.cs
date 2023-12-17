using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project1.Game_Systems.Input;

namespace Project1.Game_Systems
{
    public class Map
    {
        private SpriteBatch _spriteBatch;
        private ContentManager _contentManager;

        private Texture2D _groundUnselectedV1;
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
            _groundUnselectedV1 = this._contentManager.Load<Texture2D>("grass_var2");

            // Upon loading the content, generate a new map;
            GenerateRandomMap();

        }

        public void Draw()
        {
            DrawMap();
        }

        public void Update()
        {
            for (int i = 0; i < _mapTiles.Count; i++)
            {
                HoverOverTile(_mapTiles[i]);
            }
        }


        private void GenerateRandomMap()
        {

            int mapRightOffset = 200;

            Vector2 mapStartPosition = new Vector2(640, 100);
            Vector2 offset = new Vector2(0, 0);
            int unselectedBlockHeight = 18;

            for (int i = 0; i < 4; i++, IncreaseOffset(ref offset, _groundUnselectedV1.Width / 2,
                _groundUnselectedV1.Height / 2 - unselectedBlockHeight))
            {
                for (int j = 0; j < 4; j++ )
                {
                    Vector2 tilePosition =
                        new Vector2(
                            mapStartPosition.X - (_groundUnselectedV1.Width / 2 - 2) * j + offset.X,
                            mapStartPosition.Y + (_groundSelected.Height / 2 + unselectedBlockHeight) * j + offset.Y 
                        );

                    MapTile tile = new MapTile(_groundUnselectedV1, _groundSelected, _spriteBatch, tilePosition);
                    _mapTiles.Add(tile);

                }
            }
        }

        private void IncreaseOffset(ref Vector2 offset, int xAmount, int yAmount)
        {
            offset.X += xAmount;
            offset.Y += yAmount;
        }


        private void DrawMap()
        {
            for (int i = 0; i < _mapTiles.Count; i++) 
            {
                _mapTiles[i].Draw();
            }
        }

        private void HoverOverTile(MapTile tile)
        {
            Point mousePoint = InputManager.GetMousePositionPoint();
            
            if (tile.GetTileBounds().Contains(mousePoint))
            {
                tile.SetTileSelected(true);
            }
            else
            {
                tile.SetTileSelected(false);
            }

        }



    }


}
