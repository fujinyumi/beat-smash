using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResultStats
{
    private static int score, maxCombo, good, great, bad, miss;
    private static string grade;

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public static string Grade
    {
        get
        {
            return grade;
        }
        set
        {
            grade = value;
        }
    }

    public static int MaxCombo
    {
        get
        {
            return maxCombo;
        }
        set
        {
            maxCombo = value;
        }
    }

    public static int Good
    {
        get
        {
            return good;
        }
        set
        {
            good = value;
        }
    }

    public static int Great
    {
        get
        {
            return great;
        }
        set
        {
            great = value;
        }
    }

    public static int Bad
    {
        get
        {
            return bad;
        }
        set
        {
            bad = value;
        }
    }

    public static int Miss
    {
        get
        {
            return miss;
        }
        set
        {
            miss = value;
        }
    }
}