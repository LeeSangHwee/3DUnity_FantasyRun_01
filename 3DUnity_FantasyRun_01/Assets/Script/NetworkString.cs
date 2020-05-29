using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkString : MonoBehaviourPunCallbacks
{
    public GameObject UserGroup;
    public GameObject SysObj;
    private TimeCount Lap_Time;
    private Text My_Time;
    private Text OtherUser_Time;
    private EndTrigger Ending;

    void Awake()
    {
        if (PhotonNetwork.LocalPlayer.NickName == "Player_1")
       {
            GameObject User = PhotonNetwork.Instantiate("Player1", UserGroup.transform.localPosition, Quaternion.identity);
            User.transform.parent = UserGroup.transform;
            
            My_Time = GameObject.Find("Text_Player1Time").GetComponent<Text>();
            OtherUser_Time = GameObject.Find("Text_Player2Time").GetComponent<Text>();

            GameObject EndTrig = PhotonNetwork.Instantiate("EndTrigger", SysObj.transform.localPosition, Quaternion.identity);
            EndTrig.transform.parent = SysObj.transform;
        }
        else if (PhotonNetwork.LocalPlayer.NickName == "Player_2")
       {
            GameObject User = PhotonNetwork.Instantiate("Player2", UserGroup.transform.localPosition, Quaternion.identity);
            User.transform.parent = UserGroup.transform;
       
            My_Time = GameObject.Find("Text_Player2Time").GetComponent<Text>();
            OtherUser_Time = GameObject.Find("Text_Player1Time").GetComponent<Text>();

            GameObject EndTrig = PhotonNetwork.Instantiate("EndTrigger", SysObj.transform.localPosition, Quaternion.identity);
            EndTrig.transform.parent = SysObj.transform;
       }

        PhotonNetwork.IsMessageQueueRunning = true;

        Lap_Time = GameObject.Find("LapTime").GetComponent<TimeCount>();
    }

    void Update()
    {
        Ending = GameObject.FindWithTag("Trigger").GetComponent<EndTrigger>();

        if (Ending.EndState == true)
        {
            int imin = Lap_Time.imin, isec = Lap_Time.isec, imsec = Lap_Time.imsec;
            string msg = string.Format("{0:d2}:{1:d2}:{2:d2}", imin, isec, imsec);

            My_Time.text = msg;
            photonView.RPC("ReceiveMsg", RpcTarget.OthersBuffered, msg); // 보내기            
        }
    }

    [PunRPC]
    void ReceiveMsg(string msg) { OtherUser_Time.text = msg; }

    public void UserDelete() { PhotonNetwork.Disconnect(); }
}
