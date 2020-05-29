using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSaw : MonoBehaviour
{
    private Transform Saw;

    private int Direction = 1;
    public float Move_fSpeed = 0.0f;
    public float Rotate_fSpeed = 0.0f;
    
    void Start() { Saw = GetComponent<Transform>(); }

    void Update()
    {
        Vector3 pos = this.gameObject.transform.localPosition;

        Saw.Rotate(0, 0, Direction * Rotate_fSpeed * Time.deltaTime, Space.Self);
        Saw.Translate(Vector3.left * Direction * Move_fSpeed * Time.deltaTime, Space.World);

        if (pos.x >= 3.0f)
            Direction = 1;
        else if (pos.x <= -3.0f)
            Direction = -1;
    }
}
