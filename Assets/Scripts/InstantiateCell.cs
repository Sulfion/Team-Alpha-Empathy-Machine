using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// The Instantiate Controller.
public class InstantiateCell : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Update()
    {
        NextDirection(0, 0);
    }
    Vector2 NextDirection(int x, int y)
    {
        if (x == 0 && y == 0) return new Vector2(1, 0);
        float a = Mathf.Atan2(y, x) / Mathf.PI;
        if (a >= -0.75f && a <= -0.25f) return new Vector2(x + 1, y);
        if (a >= 0.25f && a < 0.75f) return new Vector2(x - 1, y);
        if (a > -0.25 && a < 0.25f) return new Vector2(x, y + 1);
        return new Vector2(x, y - 1);
    }
}

