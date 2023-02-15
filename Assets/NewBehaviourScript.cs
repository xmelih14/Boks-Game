using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator hareket;
    public Text can;
    private int hayat = 100;

    void Start()
    {
        hareket = GetComponent<Animator>();
 
    }
    public void HasarAl()
    {
        
        hayat -= Random.Range(5, 10);


    }

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.D))
        {
            hareket.SetTrigger("box");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            hareket.SetTrigger("blok 0");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            hareket.SetTrigger("tekme");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            hareket.SetTrigger("aparkat");
        }
    
       else if(Input.GetKey(KeyCode.W))
        {
            hareket.SetBool("Yürüme", true);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            hareket.SetBool("Yürüme", false);
        } 
        else
        {
            hareket.SetTrigger("durma");

        }
       

        if (hayat <= 0)
        {
            hareket.SetTrigger("ölme");
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            can.text = "Player 1: " + hayat;
        }
          
    }

}
