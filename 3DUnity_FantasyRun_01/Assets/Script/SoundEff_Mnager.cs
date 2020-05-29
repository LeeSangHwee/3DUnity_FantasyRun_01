using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SoundEff_Mnager : MonoBehaviour
{
    public AudioSource Sound_Source;
    public AudioClip[] Sound_Arr = new AudioClip[6];
    private ItemEffet[] ItemEff = new ItemEffet[3];

    void Start()
    {
        ItemEff[0] = GameObject.Find("Item(Speed1)").GetComponent<ItemEffet>();
        ItemEff[1] = GameObject.Find("Item(Ignore)").GetComponent<ItemEffet>();
        ItemEff[2] = GameObject.Find("Item(Speed2)").GetComponent<ItemEffet>();
    }

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (ItemEff[i].PlaySound == true)
            {
                ItemEff[i].PlaySound = false;
                ItemEff[i].gameObject.SetActive(false);

                if (PhotonNetwork.LocalPlayer.NickName == "Player_1")
                    Sound_Source.clip = Sound_Arr[i];
                else if (PhotonNetwork.LocalPlayer.NickName == "Player_2")
                    Sound_Source.clip = Sound_Arr[i + 3];

                Sound_Source.Play();
            }
        }
    }
}
