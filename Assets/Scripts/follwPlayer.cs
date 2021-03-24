using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follwPlayer : MonoBehaviour
{
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.position = new Vector3(Mathf.Clamp(Player.transform.position.x,-40,40),Player.transform.position.y,transform.position.z);
    }
     public  void CameraPos()
    {
        Vector3 CameraPos = Player.transform.position;
    }
}
