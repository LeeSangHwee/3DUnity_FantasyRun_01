using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//Test

public class Test : MonoBehaviour
{
    public SWS.splineMove spline_Move;
    public Item_Box ItemBox;
   

    private GameObject target;
    // Start is called befsore the first frame update
    void Start()
    {
        spline_Move = GameObject.FindGameObjectWithTag("Player").GetComponent<SWS.splineMove>();
        ItemBox.GetComponent<Item_Box>();
       // if(box_rotate.state == false)
       // this.gameObject.SetActive(true);
    }

    private void OnMouseDown()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (ItemBox.state == false)
            this.gameObject.SetActive(false);
        //일정시간동안 스피드업
        
        if(Input.GetMouseButton(0))
        {

            if(EventSystem.current.IsPointerOverGameObject())
            {
         
                this.gameObject.SetActive(false);

            }

            
        }
    
      
        
    }
}
