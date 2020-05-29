using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountTest : MonoBehaviour
{
    public Text timeText;

    private float fTime;
    private int imin = 0;
    private int isec = 0;
    private int imsec = 0;

    void Update()
    {
        fTime += Time.deltaTime;

        if (isec >= 59)
        {
            imin++;
            isec = 0;
        }

        if (imsec >= 99)
        {
            isec++;
            imsec = 0;
            fTime = 0.0f;
        }
        else if (imsec < 99)
            imsec = (int)(fTime * 100);

        timeText.text = string.Format("{0:d2}:{1:d2}:{2:d2}", imin, isec, imsec);
        //timeText.text = string.Format("{0:d2}", isec);
    }
}
