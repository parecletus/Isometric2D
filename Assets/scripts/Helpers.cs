using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    public static Vector2 Iso_Cal(Vector2 vector)
    {
        return vector = new Vector2(vector.x - vector.y, (vector.x + vector.y) / 2);
    }
}
