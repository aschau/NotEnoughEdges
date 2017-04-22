using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper {
    public static float findAngle (Vector3 v1, Vector3 v2)
    {
        float result = Mathf.Atan2(v2.y-v1.y, v2.x-v1.x);

        if (Mathf.Sin(result) < 0 && v2.x - v1.x > 0 || Mathf.Sin(result) > 0 && v2.x - v1.x < 0)
            result += Mathf.PI;

        return result*180/Mathf.PI;
    }

    public static float sumList (List<float> l)
    {
        float result = 0.0f;

        foreach (float val in l)
            result += val;

        return result;
    }

}
