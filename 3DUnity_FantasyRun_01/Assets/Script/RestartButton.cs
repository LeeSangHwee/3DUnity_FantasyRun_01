using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class RestartButton : MonoBehaviourPunCallbacks
{
    public NetworkString NetString;

    public void OnClickFunc()
    {
        if (photonView.IsMine)
        {
            NetString.UserDelete();
            SceneManager.LoadScene("Main");
        }
    }
}
