using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    enum STATE
    {
        eIDLE   ,
        eUP     ,
        eDOWN   ,
    }

    private float fTime = 0.0f;
    private Vector3 Temp_PlayerPos;
    public float fJumpPower = 0.0f;
    public Rigidbody Player_rigidbody;
    public GameObject Player_Col;
    Animator Player_animator;
    private JumpButton JumpBtn;
    bool isJumping;
    int bCheck;
    
    void Start()
    {
        bCheck = (int)STATE.eIDLE;
        JumpBtn = GameObject.Find("JumpButton").GetComponent<JumpButton>();
        Player_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (JumpBtn.JumpButton_state == true && bCheck == (int)STATE.eIDLE)
        {
            isJumping = true;
            bCheck = (int)STATE.eUP;

            Player_Col.SetActive(false);
            Player_rigidbody.AddForce(Vector3.up * fJumpPower, ForceMode.Impulse);
            Player_animator.SetBool("isJumping", true);

            GetComponent<AudioSource>().Play();
        }
        else if (JumpBtn.JumpButton_state == true && bCheck == (int)STATE.eUP)
        {
            isJumping = false;
            Player_animator.SetBool("isJumping", false);
        }

        if (bCheck == (int)STATE.eUP)
        {
            fTime += Time.deltaTime;

            if (fTime >= 1.13f)
            {
                JumpBtn.JumpButton_state = false;
                Player_Col.SetActive(true);
                bCheck = (int)STATE.eIDLE;
                fTime = 0.0f;
            }
        }
    }
}
