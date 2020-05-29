using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkMgr : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1.0";
    public byte maxPlayer = 2;
    public ClickAni_Man ClickMan;
    public ClickAni_Woman ClickWoman;

    private void Awake() { PhotonNetwork.AutomaticallySyncScene = true; }

    #region SELF_CALLBACK_FUNCTIONS
    public void OnLogin()
    {
        Debug.Log("login");
        PhotonNetwork.GameVersion = this.gameVersion;

        if (ClickMan.Man_Select_State == true)
        {
            PhotonNetwork.NickName = "Player_1";
            PlayerPrefs.SetString("USER_ID", PhotonNetwork.NickName);
        }
        else if (ClickWoman.Woman_Select_State == true)
        {
            PhotonNetwork.NickName = "Player_2";
            PlayerPrefs.SetString("USER_ID", PhotonNetwork.NickName);
        }

        PhotonNetwork.ConnectUsingSettings();
    }

    public void OnCreateRoomClick()
    {
        Debug.Log("Create Room !!!");
        PhotonNetwork.CreateRoom("FantasyRun_Room", new RoomOptions { MaxPlayers = this.maxPlayer });
    }

    public void OnJoinedRoomClick()
    {
        Debug.Log("Joined Room !!!");
        PhotonNetwork.JoinRoom("FantasyRun_Room");
    }
    #endregion

    #region PHOTON_CALLBACK_FUNCTIONS
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connect To Master");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Call Create Room !!!");
    }

    public override void OnJoinedRoom()          
    {
        Debug.Log("Call Joined Room !!!");
        PhotonNetwork.IsMessageQueueRunning = false;
        SceneManager.LoadScene("Stage1");
    }
    #endregion
}
