using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColMove : MonoBehaviour
{
    public GameObject Player;
    public GameObject Player_Col;

    void Update()
    {
        Player_Col.transform.localPosition = Player.transform.localPosition;
    }
}
