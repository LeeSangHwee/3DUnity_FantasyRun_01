using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAni_Woman : MonoBehaviour
{
    private Animator Anim;
    [HideInInspector]
    public bool Woman_Select_State = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = Input.mousePosition;

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
               if(hit.transform.gameObject.tag == "Char_Woman")
                {
                    //Destroy(hit.transform.gameObject);
                    Anim = GetComponent<Animator>();

                    Anim.SetBool("IsTouchWoman", true);
                    Woman_Select_State = true;
                    //die();
                }

                if (hit.transform.gameObject.tag == "Char_Man")
                {
                    //Destroy(hit.transform.gameObject);
                    Anim = GetComponent<Animator>();

                    Anim.SetBool("IsTouchWoman", false);
                    Woman_Select_State = false;

                    //die();
                }
            }
        }
    }

   // void die()
   // {

        //Anim.SetTrigger("run");
   // }
}
