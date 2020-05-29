using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityStandardAssets.Utility;

public class CameraMove : MonoBehaviourPunCallbacks
{
    private Transform tr;
    private Transform FollowCam;
    private GameObject DeActiveCam;

    private void Start()
    {
        tr = GameObject.Find("CamPivot").GetComponent<Transform>();

        if (PhotonNetwork.LocalPlayer.NickName == "Player_1")
        {
            FollowCam = GameObject.Find("Main Camera1").GetComponent<Transform>();
            DeActiveCam = GameObject.Find("Main Camera2");
            DeActiveCam.SetActive(false);
        }
        else if (PhotonNetwork.LocalPlayer.NickName == "Player_2")
        {
            FollowCam = GameObject.Find("Main Camera2").GetComponent<Transform>();
            DeActiveCam = GameObject.Find("Main Camera1");
            DeActiveCam.SetActive(false);
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            FollowCam.position = tr.position;
            FollowCam.rotation = tr.rotation;
        }
    }
}
