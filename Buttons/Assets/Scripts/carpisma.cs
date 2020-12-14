using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carpisma : MonoBehaviour
{
    public Animator needlestitchanim;
    public GameObject stitch;
    public GameObject buttonstitch;
    public static bool evet;
    public Text ScoreText;



    int score;

    void Start()
    {
        score = 0;

        buttonstitch.GetComponent<SpriteRenderer>().enabled = false;
        ScoreText.text = "Score: 0";
    }


    void Update()
    {
        

    }
    void OnTriggerEnter2D(Collider2D col)                                               //herhangi bir objeye çarptığında çalışır
    {
        if (col.gameObject.tag == "buttontag")                                      //tagı buttontag olan bir objeye çarptığında çalışır needle ın butonla çarpışması
        {
           
            needlestitchanim.SetTrigger("needletrigger");    
            evet = true;
            Invoke("evetfalse",0.2f);
            col.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

            score+=10;
            ScoreText.text = "Score: " + score;
            transform.GetChild(3).GetComponent<AudioSource>().Play();



        }
        

    }

    void evetfalse()
    {
        evet = false;
    }
}
