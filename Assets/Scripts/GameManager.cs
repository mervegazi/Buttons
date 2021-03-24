using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{

   public Button PlayButton;
   public Text ButtonText;
    public bool GameControl = false,StartGame;
   public static GameManager ben;
   public bool isfinished;
   
    public Vector3 RandomPos;
    bool isokay;

    public GameObject Button;
    public Sprite[] Buttons_Pic;
    int Rand;

    GameObject cameraposmed;


    public GameObject background1;
    public GameObject background2;
    GameObject needlemed;
    float length = 0;
    bool siraikide;


    public Image blurimage;
    public Button restartbutton;
    public Text FinishScoreText;
    public Text ScoreText;


    void Start()
    {
        blurimage.gameObject.SetActive(false);
        restartbutton.gameObject.SetActive(false);





        ben = this;
        PlayButton.GetComponent<Button>();                                                                                   //butonu çektik        

        needlemed = GameObject.FindGameObjectWithTag("needletag");
     
        length = background1.transform.GetComponent<SpriteRenderer>().size.y*background1.transform.localScale.y;            //burada bir uzunluk değeri elde ettik arkaplan adlı resmin normal boyutu ve localdeki boyuta ulaşması için kaç kat büyümesi gerektiğini size dan alıyoruz mesela scalesi 3 olan bir nesne localde 600 boyutundaysa buna ulaşmak için localdeki size 200 dür bu büyüme katsayısıdır. 
       

    }
    void Update()
    {
        if (GameManager.ben.isfinished)                                                                                      //koşul sağlandığında aşağıdaki kodları çalıştırmasın hep buraya girsin çıkamasın.
        {
            FinishScoreText.text = ScoreText.text;
            blurimage.gameObject.SetActive(true);
            restartbutton.gameObject.SetActive(true);
            return;
        }



        if (!siraikide)                                                                                                      //backgrandun sıralı gelip sonsuza kadar devam etmesini sağlıyoruz.
        {
            if (needlemed.transform.position.y >= background1.transform.position.y)
            {
                background2.transform.position += new Vector3(0, length*2, 0);
                siraikide = true;
            }
        }
        if (siraikide)
        {
            if (needlemed.transform.position.y >= background2.transform.position.y)
            {
                background1.transform.position += new Vector3(0, length*2, 0);
                siraikide = false;
            }
        }

        


        cameraposmed = GameObject.FindGameObjectWithTag("MainCamera");
        cameraposmed.GetComponent<follwPlayer>().CameraPos();
        
        if (StartGame && !isokay)                                                                  //StartGame: ilk açılışta butona bastı mı kontrol etsin sürekli && isokay: bir kere çalıştırsın sürekli döngüye girmesin. Girerse update çalıştıkça üretir.
        {
            isokay = true;  
        InvokeRepeating("ProduceButton",1,1);                                                      //sonsuza kadar tekrar ediyor bu method(tekrar edecek medot adı, ilk açılışta kaç saniye beklesin, saniyede kaç oranla üretsin).
        
        }

    }
    public void GameOn()
    {
        PlayButton.gameObject.SetActive(false);                                                    // tap to start butona tıkladığımızda görünmez oluyor.

        GameControl = true;
    }


    
    void ProduceButton()
    {
        Rand = Random.Range(0, Buttons_Pic.Length);
        Vector3 vec = new Vector3(Random.Range(-RandomPos.x-10f, RandomPos.x+10f), cameraposmed.transform.position.y+80, 0);                   //butonları random oluşturuyor.
        GameObject ButtonChange= Instantiate(Button, vec, Quaternion.identity);                                                     //üretilen clonu elinde tut(ButtonChange de tut)
        ButtonChange.GetComponent<SpriteRenderer>().sprite = Buttons_Pic[Rand];                                                     //clonun sprite ini random ata yani resmini değiştiriyor.
      
    }
}
