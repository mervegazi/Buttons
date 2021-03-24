using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StitchMove : MonoBehaviour
{
    GameObject needlemed;
    //float timer = 0;


    float counter;
    //bool Isfront;
    //float time;
    void Start()
    {
        needlemed = GameObject.FindGameObjectWithTag("needletag");
        needlemed.GetComponent<GameManager>();

        //StartPos = transform.position;
        //time = 5;
    }
    Vector3 StartPos;

    void Update()
    {
        if (GameManager.ben.isfinished)
        {
            return;
        }

        counter += Time.deltaTime;
        if (counter > 0.2f)
        {
            counter = 0;
            StartCoroutine(Move());

        }
        //Evet();
    }

    //private void Evet()
    //{
    //    counter += Time.deltaTime;
    //    if (counter <= 5)
    //    {
    //        Isfront = true;
    //        Debug.Log("Girdi ilk");
    //    }
    //    if (counter > 5 && counter <= 10)
    //    {
    //        Isfront = false;

    //        Debug.Log("Girdi iki");

    //    }
    //    if (counter >= 10)
    //    {
    //        counter = 0;
    //        Debug.Log("Sıfır");

    //    }
    //    if (Isfront)
    //    {
    //        Vector3 ben = transform.position;
    //        ben.z = transform.root.position.z;
    //        transform.position = ben;
    //        Debug.Log("Isfront " + Isfront);
    //    }
    //    else
    //    {
    //        Vector3 ben = transform.position;
    //        ben.z = transform.root.position.z + 100;
    //        transform.position = ben;
    //        Debug.Log("Isfront " + Isfront);

    //    }


    IEnumerator Move()
    {
        if (!carpisma.evet)
        {
            transform.position = new Vector3(needlemed.transform.position.x, needlemed.transform.position.y - 8.234f, transform.root.position.z);
        }
        yield return new WaitForSeconds(0.1f);
       
        transform.position = new Vector3(needlemed.transform.position.x, needlemed.transform.position.y - 8.234f, transform.root.position.z + 100);
            
        

    }

    //void ilkkonum()
    //{
    //    transform.position = new Vector3(needlemed.transform.position.x, needlemed.transform.position.y - 8.234f, transform.root.position.z);
    //}
    //void sonkonum()
    //{
    //    transform.position = new Vector3(needlemed.transform.position.x, needlemed.transform.position.y - 8.234f, transform.root.position.z + 100);
    //}


}
