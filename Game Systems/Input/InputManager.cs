using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Project1.Game_Systems.Input
{
    static class InputManager
    {
        public static MouseState GetMouseState()
        {
            return Mouse.GetState();
        }

        public static Vector2 GetMousePositionVector()
        {
            MouseState state = GetMouseState();
            return new Vector2(state.X, state.Y);
        }

        public static Point GetMousePositionPoint()
        {
            Vector2 mousePosition = GetMousePositionVector();
            return new Point((int)mousePosition.X, (int)mousePosition.Y);
        }


    }
}
