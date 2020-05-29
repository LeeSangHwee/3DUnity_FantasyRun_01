using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemEffet : MonoBehaviour
{
    private SWS.splineMove spline_Move;

    [HideInInspector]
    public Item_Box Item_Box;
    private GameObject taget;
    private float timer;
    private int wait;
 
    [HideInInspector]
    public bool Speed1_state, Speed2_state, Ignore_state;
    [HideInInspector]
    public bool PlaySound = false;

    public bool State;

    void Start()
    {
        timer = 0.0f;
        State = false;
        spline_Move = GameObject.FindGameObjectWithTag("Player").GetComponent<SWS.splineMove>();
        Item_Box = FindObjectOfType<Item_Box>();
    }

    private void OnMouseDown()
    {
        this.gameObject.SetActive(false);
        spline_Move.ChangeSpeed(2.0f);
    }

    void Update()
    {
        //Debug.Log("Effet state = " + Speed1_state);
        //Debug.Log("Effet state = " + Speed2_state);
        //Debug.Log("Effet state = " + Ignore_state);
        //Debug.Log("Item_Box.Speed1_state = " + Item_Box.Speed1_state);
        //Debug.Log("Item_Box.Speed2_state = " + Item_Box.Speed2_state);
        //Debug.Log("Item_Box.Ignore_state = " + Item_Box.Ignore_state);

        if (Item_Box.Speed1_state == false)
            this.gameObject.SetActive(false);
        if (Item_Box.Speed2_state == false)
            this.gameObject.SetActive(false);
        if (Item_Box.Ignore_state == false)
            this.gameObject.SetActive(false);

        if (Item_Box.Speed1_state == true || Speed1_state == true)
        {
            this.gameObject.SetActive(true);
        }
        if (Item_Box.Speed2_state == true || Speed2_state == true)
        {
            this.gameObject.SetActive(true);
        }
        if (Item_Box.Ignore_state == true || Ignore_state == true)
        {
            this.gameObject.SetActive(true);
        }
        //if (Input.GetTouch(0).phase == TouchPhase.Ended)
        //{
        //    if(EventSystem.current.IsPointerOverGameObject())
        //    {

        //    }
        //}

        //StartCoroutine(SpeedUpItem());
        //ItemSpeed1Up();
    }

    IEnumerator SpeedUpItem()
    {
        while (State)
        {
            spline_Move.ChangeSpeed(1.55f);
            yield return new WaitForSeconds(1.5f);
            Debug.Log("food");
            spline_Move.ChangeSpeed(1.0f);
            State = false;
        }
    }

    private void ItemSpeed1Up()
    {
        if (State)
        {
            timer += Time.deltaTime;
            wait = 2;
            spline_Move.ChangeSpeed(2.55f);
            if (timer > wait)
            {
                spline_Move.ChangeSpeed(1.0f);
                timer = 0.0f;
                State = false;
            }
        }
    }

    public void OnClick()
    {
        if (Item_Box.Speed2_state == true)
            State = true;
        else if (Item_Box.Ignore_state == true)
            State = true;
        else if (Item_Box.Speed1_state == true)
            State = true;

        PlaySound = true;
    }
}
