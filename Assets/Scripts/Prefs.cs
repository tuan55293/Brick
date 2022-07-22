using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{
    public static int bestScore
    {
        get => PlayerPrefs.GetInt(GameConsts.BEST_SCORE, 0);
        set
        {
            if (value > bestScore)
            {
                PlayerPrefs.SetInt(GameConsts.BEST_SCORE, value);
            }
        }
    }
}
