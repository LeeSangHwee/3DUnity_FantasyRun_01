//TimeCount
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public Text timeText;

    [HideInInspector]
    public bool Time_bState = true;    

    [HideInInspector]
    public int imin = 0;

    [HideInInspector]
    public int isec = 0;

    [HideInInspector]
    public int imsec = 0;

    private float fTime;

    void Update()
    {
        if(Time_bState == false)
            return;
        else if(Time_bState == true)
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
        }

        timeText.text = string.Format("{0:d2}:{1:d2}:{2:d2}", imin, isec, imsec);
    }
}
