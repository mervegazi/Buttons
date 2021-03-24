using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NeedleMove : MonoBehaviour
{
    bool Buttonclicked = false;                                                                                //ilk başta bir sürükleme olayı olmayacağı için
    GameObject gamecontrolmed;
    public GameObject look;
    GameObject stitchmed;
    public GameObject stitchprefab;
    GameObject nt;
    float counter;





    void Start()
    {
        gamecontrolmed = GameObject.FindGameObjectWithTag("gamemanagertag");
        stitchmed = GameObject.FindGameObjectWithTag("stitchtag");
        nt = GameObject.FindGameObjectWithTag("needle-threadtag");


        transform.position = new Vector3(0, -27, 0);
        sensitivity = 0.5f;

    }

    bool isokay;
    float counter4, speed = 0.2f,sensitivity;
  
    void Update()
    {
        nt.GetComponent<Transform>();


        if (GameManager.ben.isfinished) //aşağıdaki kodları çalıştırma eğer finish olduysa
        {
            return;
        }


        if (Buttonclicked)
        {
            if (counter5<=5) //ilk açılışta 1 saniye beklesin sonra elimizi çektiğimiz an ölsün çünkü bunu yapmazsak anında elini basmazsa ölüyor 
            {
                counter5 += Time.deltaTime;

            }
            else
            {
                needlebreak();
            }

            if (!isokay)
            {
                isokay = true;

            }



            counter4 += Time.deltaTime;
            if (counter4 > speed - .15f) //dikiş üretme hızı
            {
                ProduceStitch();
                counter4 = 0;
            }


            counter += Time.deltaTime;
            if (counter > 0.008)
            {
                counter = 0;


                NMove();
                speed += 0.00005f; //gittikçe oyun hızlansın 

            }




        }

        if (Input.GetMouseButtonDown(0))
        {
            gamestart();
            Buttonclicked = true;
            GameManager.ben.StartGame = true;
        }
      
 
    }
    float counter5;
    public void NMove()  //iğne mause u takip etsin
    {

        transform.position = new Vector3(transform.position.x, transform.position.y + speed * 3.2f, transform.position.z); //needle ın yukarıya gitmesi


        //ilk pozisyon
        //    fark
        //    iğnenin


            float fark = 0;


        if (Input.GetMouseButtonDown(0))                                                                   
        {
            Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (transform.position.x > temp.x)
            {
                fark = transform.position.x - temp.x;
            }
            else
            {
                fark = temp.x - transform.position.x;
            }
           
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3((temp.x-fark)*sensitivity,transform.position.y,transform.position.z);

            float Xposobje = Mathf.Clamp(transform.position.x, -50, 50);                                   //needle ın x i 60 ile -60 arasında hareket etsin 
            transform.position = new Vector2(Xposobje, transform.position.y);
        }








        //if (Input.GetMouseButtonDown(0))                                                                   
        //{
        //    var evet = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    if (evet.x > transform.position.x)
        //    {
        //        isright = false;

        //    }
        //    else
        //    {

        ////        isright = true;
        //    }
        //}
        if (Input.GetMouseButton(0))
        {

            counter2 += Time.deltaTime;
            if (counter2 > speed * 2.5f)
            {
                //var xpos = transform.position;
                //var evet = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //if (isright)
                //{
                //    xpos.x = transform.position.x - evet.x;

                //}
                //else
                //{

                //    xpos.x = evet.x - transform.position.x;
                //}
                


                float delta, startx = 0;                                                         //needle ın dönmesi
                if (counter3 == 0)
                {
                    startx = transform.position.x;
                }
                counter3 += Time.deltaTime;

                if (counter3 > speed / 2)
                {
                    delta = transform.position.x - startx;
                    float angle = Mathf.Atan2(delta, transform.GetChild(0).GetComponent<SpriteRenderer>().size.y) * Mathf.Rad2Deg; //dönme açısı aldık
                    Quaternion rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, angle / 5)); // istenen yöne çevir
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationspeed * Time.deltaTime); //dönmeyi yumuşatmak için 
                    counter3 = 0;

                }

            }


        }

    }


    bool isgamestarted = false;
    public void gamestart()
    {

        gamecontrolmed.GetComponent<GameManager>().GameOn();
        isgamestarted = true;
    }



    bool isright;
    float counter2, counter3;

    public float rotationspeed;
    void ProduceStitch()
    {


        Vector3 producestitch = new Vector3(nt.transform.position.x, nt.transform.position.y - 1, nt.transform.position.z);
        GameObject StitchChange = Instantiate(stitchprefab, producestitch, transform.rotation);
        StitchChange.transform.Rotate(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.y, transform.rotation.eulerAngles.z * 3f));
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);

        //DİKİŞ SESİ AKTİF ET

    }
    void needlebreak()
    {

        if (Input.GetMouseButtonUp(0) && GameManager.ben.StartGame)
        {
            GameManager.ben.isfinished = true;
            
            
        }
    }
}
