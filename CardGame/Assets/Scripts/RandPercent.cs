using System.Collections;
using UnityEngine;

public static class RandPercent
{
    public static float thisPercent;

    public static void AddPercent(bool isAdd)
    {
        if (isAdd)
            thisPercent += 5f;
        else
            thisPercent -= 1;
        thisPercent = Mathf.Clamp(thisPercent, 1f, 99f);
    }
    public static bool GetResult()
    {
        bool success = false;

        int rand = 100;

        int randNum = Random.Range(1, rand + 1);

        if (randNum <= thisPercent)
        {
            success = true;
        }

        return success;
    }

}
