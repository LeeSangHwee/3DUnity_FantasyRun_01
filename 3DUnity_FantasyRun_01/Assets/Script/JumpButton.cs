using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    [HideInInspector]
    public bool JumpButton_state = false;

    public void OnClickFunc()
    {
        JumpButton_state = true;
    }
}