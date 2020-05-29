using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerCollision : MonoBehaviour
{
    private SWS.splineMove spline_move;
    private Animator Player_animator;

    private float fTime;

    void Start()
    {
        if (PhotonNetwork.LocalPlayer.NickName == "Player_1")
        {
            spline_move = GameObject.Find("avatar1").GetComponent<SWS.splineMove>();
            Player_animator = GameObject.Find("avatar1").GetComponent<Animator>();
        }
        else if (PhotonNetwork.LocalPlayer.NickName == "Player_2")
        {
            spline_move = GameObject.Find("avatar2").GetComponent<SWS.splineMove>();
            Player_animator = GameObject.Find("avatar2").GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (fTime <= 2.0f && spline_move.isCol == true)
            fTime += Time.deltaTime;
        else if (fTime >= 2.0f && spline_move.isCol == true)
        {
            spline_move.isCol = false;
            Player_animator.SetBool("isCol", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DangerousObj")
        {
            other.gameObject.tag = "Untagged";
            fTime = 0.0f;
            spline_move.isCol = true;
            Player_animator.SetBool("isCol", true);
            GetComponent<AudioSource>().Play();
        }
    }
}
