using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class StartCount : MonoBehaviour
{
    public SWS.splineMove spline_move;

    private float fTime;

    void Start()
    {
        if (PhotonNetwork.LocalPlayer.NickName == "Player_1")
        {
            spline_move = GameObject.Find("avatar1").GetComponent<SWS.splineMove>();
            spline_move.WayPointUpdate = false;
        }            
        else if (PhotonNetwork.LocalPlayer.NickName == "Player_2")
        {
            spline_move = GameObject.Find("avatar2").GetComponent<SWS.splineMove>();
            spline_move.WayPointUpdate = false;
        }

        fTime = 0.0f;
    }

    void Update()
    {
        if (fTime >= 3.0f)
            spline_move.WayPointUpdate = true;
        else if (fTime < 3.0f)
            fTime += Time.deltaTime;
    }
}
