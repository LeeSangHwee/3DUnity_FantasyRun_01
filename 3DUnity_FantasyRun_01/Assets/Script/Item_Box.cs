using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Box
public class Item_Box : MonoBehaviour
{
    //public float Xspeed,Yspeed = -100f,Zspeed;
    public float Yspeed = 70;
    public int iRandom;
    public bool Speed1_state, Speed2_state, Ignore_state;
    private GameObject Speed_Item1, Speed_Item2, Ignore_Item;   

    // Update is called once per frame
    void Start()
    {
        Speed_Item2 = GameObject.FindGameObjectWithTag("Item2");
        Ignore_Item = GameObject.FindGameObjectWithTag("Item1");
        Speed_Item1 = GameObject.FindGameObjectWithTag("Item");

        //Speed_Item1.SetActive(false);
        //Speed_Item2.SetActive(false);
        //Ignore_Item.SetActive(false);
        Speed1_state = false;
        Speed2_state = false;
        Ignore_state = false;
    }

    void Update()
    {
        this.transform.Rotate(0, Time.deltaTime * Yspeed, 0, Space.World);
        //this.transform.Rotate(new Vector3(0, 0, 70) * Time.deltaTime);
        //transform.Rotate(Time.deltaTime*Xspeed, Time.deltaTime*Yspeed, Time.deltaTime*Zspeed, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        iRandom = Random.Range(0, 17);
        //플레이어가 아이템에 닿았을 때   
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ItemCheck());
            Destroy(gameObject);
        }
    }

    IEnumerator ItemCheck()
    {
      
        if (iRandom <= 5)
        {
            Speed_Item2.SetActive(true);
            Speed2_state = true;
        }
        else if (iRandom > 5 && iRandom <= 10)
        {
            Ignore_Item.SetActive(true);
            Ignore_state = true;
        }
        else if (iRandom > 10)
        {
            Speed_Item1.SetActive(true);
            Speed1_state = true;
        }

        yield return new WaitForSeconds(0.5f);
    }

}
//30.67 3.58 63.94
//34.33 13.09 -98.47
       // 10.48
//72 -7 16