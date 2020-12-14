using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour
{

    bool Buttonclicked = false;
    GameObject gamecontrolmed;

    void Start()
    {
        gamecontrolmed = GameObject.FindGameObjectWithTag("gamemanagertag");
       
    }


    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    gamecontrolmed.GetComponent<GameManager>().GameOn();
        //    Buttonclicked = true;
        //}
        if (GameManager.ben.StartGame)
        {
            transform.position -= new Vector3(0, .2f, 0);                           //butonların aşağı düşmesini sağlıyor.
        }
     
    }
    
}
