using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFunctions : MonoBehaviour
{
    private float BPM = 85f;//85f;
    private float measureMS = 60/85f;
    // Start is called before the first frame update

    public float ReturnBPM()
    {
        return BPM;
    }

    public float ReturnSingleMeasure()
    {
        return measureMS;
    }

    public float ReturnCountMeasure(int count)
    {
        return count * measureMS;
    }
}
