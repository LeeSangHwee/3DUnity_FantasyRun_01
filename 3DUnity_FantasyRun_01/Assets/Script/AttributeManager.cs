using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class AttributeManager : MonoBehaviour
{
    enum ATTRIBUTE
    {
        eSpace = 1,
        eFire,
        ePeace,
        eForest,
    }

    private Animator Animator_Player;
    private SWS.splineMove spline_move;

    private GameObject AttributeObj_Space;
    private GameObject AttributeObj_Fire;
    private GameObject AttributeObj_Peace;
    private GameObject AttributeObj_Forest;

    private ItemEffet Item1;
    private ItemEffet Item2;
    private ItemEffet Item3;

    private int Rand_Attribute;
    private int Rand_Item;

    void Start()
    {
        if (PhotonNetwork.LocalPlayer.NickName == "Player_1")
        {
            Animator_Player = GameObject.Find("avatar1").GetComponent<Animator>();
            spline_move = GameObject.Find("avatar1").GetComponent<SWS.splineMove>();
        }
        else if (PhotonNetwork.LocalPlayer.NickName == "Player_2")
        {
            Animator_Player = GameObject.Find("avatar2").GetComponent<Animator>();
            spline_move = GameObject.Find("avatar2").GetComponent<SWS.splineMove>();
        }

        AttributeObj_Space = GameObject.Find("Attribute_Space");
        AttributeObj_Fire = GameObject.Find("Attribute_Fire");
        AttributeObj_Peace = GameObject.Find("Attribute_Peace");
        AttributeObj_Forest = GameObject.Find("Attribute_Forest");

        AttributeObj_Space.SetActive(false);
        AttributeObj_Fire.SetActive(false);
        AttributeObj_Peace.SetActive(false);
        AttributeObj_Forest.SetActive(false);

        Item1 = FindObjectOfType<ItemEffet>();
        Item2 = FindObjectOfType<ItemEffet>();
        Item3 = FindObjectOfType<ItemEffet>();

        Rand_Item = Random.Range(1, 4);
        Rand_Attribute = Random.Range(1, 5);

        switch (Rand_Attribute)
        {
            case (int)ATTRIBUTE.eSpace:
                AttributeObj_Space.SetActive(true);
                AttributeFunc_Space();
                break;
            case (int)ATTRIBUTE.eFire:
                AttributeObj_Fire.SetActive(true);
                AttributeFunc_Fire();
                break;
            case (int)ATTRIBUTE.ePeace:
                AttributeObj_Peace.SetActive(true);
                AttributeFunc_Peace();
                break;
            case (int)ATTRIBUTE.eForest:
                AttributeObj_Forest.SetActive(true);
                AttributeFunc_Forest();
                break;
        }
    }

    void AttributeFunc_Space()
    {
        spline_move.AddTime = 1.0f;
    }

    void AttributeFunc_Fire()
    {
        // Fire 속성 수치 조정 부분
        spline_move.speed = 18.0f;
    }

    void AttributeFunc_Peace()
    {
        // Peace 속성 수치 조정 부분
        Animator_Player.SetFloat("fSpeed", 2.0f);
    }

    void AttributeFunc_Forest()
    {
        StartCoroutine(RandomItem());
    }

    IEnumerator RandomItem()
    {
        yield return new WaitForSeconds(8.0f);
        switch (Rand_Item)
        {
            case 1:
                Item1.Item_Box.Speed1_state = true;
                Item1.gameObject.SetActive(true);
                Item1.Speed1_state = true;
                break;
            case 2:
                Item2.Item_Box.Speed2_state = true;
                Item2.gameObject.SetActive(true);
                Item2.Speed1_state = true;
                break;
            case 3:
                Item3.Item_Box.Ignore_state = true;
                Item3.gameObject.SetActive(true);
                Item3.Speed1_state = true;
                break;
        }
    }
}
