using UnityEngine;

public static class Helper
{
    public static Vector2 PointCalculator(float x, float y, float tileWidth, float tileHeight)
    {
        return new Vector2(x * tileWidth / (100 * 2), y * tileHeight / 100);
    }
    public static Vector2 Isometric_Vector2(Vector2 orj)
    {
        return new Vector2(orj.x - orj.y, (orj.x + orj.y) / -2);
    }
    public static Vector2 GridCalculator(Vector2 orj)
    {
        return new Vector2(orj.y - orj.x, 2 * (orj.x + orj.y));
    }
}
