using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAni_Man : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator Anim;
    [HideInInspector]
    public bool Man_Select_State = false;

    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Char_Man")
                {
                    //Destroy(hit.transform.gameObject);
                    //die();

                    Anim = GetComponent<Animator>();

                    Anim.SetBool("IsTouchMan", true);
                    Man_Select_State = true;
                }

                if (hit.transform.gameObject.tag == "Char_Woman")
                {
                    //Destroy(hit.transform.gameObject);
                    //die();

                    Anim = GetComponent<Animator>();

                    Anim.SetBool("IsTouchMan", false);
                    Man_Select_State = false;
                }
            }
        }
    }

  //  void die()
  //  {

        //Anim.SetTrigger("run");
   // }
}
