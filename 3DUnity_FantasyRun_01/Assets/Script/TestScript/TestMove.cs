using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float fForwardSpd = 5.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * fForwardSpd * Time.deltaTime);
    }
}
