using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public ClickAni_Man ClickMan;
    public ClickAni_Woman ClickWoman;

    public void OnClickFunc()
    {
        if(ClickMan.Man_Select_State == true)
            SceneManager.LoadScene("Stage");
        else if (ClickWoman.Woman_Select_State == true)
        {
            // Load Woamn Scene
        }
    }
}
