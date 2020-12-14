using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class control2 : MonoBehaviour
{
    public Image kalp1;
    public Image kalp2;
    public Image kalp3;
    bool cankaybi1;
    bool cankaybi2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.tag=="buttontag")                                                                                     //buton colladera değdi mi?
        {


          



            if (!(collision.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled) && !cankaybi1)                                  //düğme dikilmiş mi?
            {
                //  Time.timeScale = 0;                                                                                          //zamanı sıfırla oyun donar.

                kalp3.gameObject.SetActive(false);
                cankaybi1 = true;
                GetComponent<AudioSource>().Play();

            }
            else if (!(collision.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled) && !cankaybi2)
            {
                kalp2.gameObject.SetActive(false);
                cankaybi2 = true;
                GetComponent<AudioSource>().Play();
            }
           else if(!(collision.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled))
            {
                kalp1.gameObject.SetActive(false);


                GameManager.ben.isfinished = true;
                GetComponent<AudioSource>().Play();

            }
            Destroy(collision.gameObject);
                //TODO: İFLERE KALP KIRILMA SESİ EKLE
          //BURAYA DÜĞME DİKİŞ SESİ EKLE
       
           
          
        }
    }

   public void SceneDegis()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitButon()
    {
        Application.Quit();
      
    }
    
}
