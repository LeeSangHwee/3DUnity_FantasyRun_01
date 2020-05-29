using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class EndTrigger : MonoBehaviourPunCallbacks
{
    public AudioSource Sound_Source;
    public AudioClip[] Sound_Arr = new AudioClip[2];

    public GameObject BGM_Mgr;
    private GameObject EndWindow;
    private TimeCount LapTime;
    private PhotonView pv;
    private Animator Player_animator;
    private float fTime;
    [HideInInspector]
    public bool EndState;

    void Start()
    {
        pv = GetComponent<PhotonView>();
        pv.ObservedComponents[0] = this;
        EndState = false;
        BGM_Mgr = GameObject.Find("BGM_Manager");
        LapTime = GameObject.Find("LapTime").GetComponent<TimeCount>();
        EndWindow = GameObject.Find("Stage1_EndWindow");

        if (PhotonNetwork.LocalPlayer.NickName == "Player_1")
        {
            Sound_Source.clip = Sound_Arr[0];
            Player_animator = GameObject.Find("avatar1").GetComponent<Animator>();
        }
        else if (PhotonNetwork.LocalPlayer.NickName == "Player_2")
        {
            Sound_Source.clip = Sound_Arr[1];
            Player_animator = GameObject.Find("avatar2").GetComponent<Animator>();
        }

        EndWindow.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            EndState = true;
            Player_animator.SetBool("EndMotion", true);
            LapTime.Time_bState = false;

            BGM_Mgr.SetActive(false);
            Sound_Source.Play();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (photonView.IsMine)
        {
            fTime += Time.deltaTime;

            if (fTime >= 1.5f)
                EndWindow.SetActive(true);
        }
    }
}
