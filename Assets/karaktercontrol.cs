using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class karaktercontrol : MonoBehaviour
{
    // Start is called before the first frame update
    Animator karakter;
    GameObject hedef;
    public float kovalamamesafe;
    NavMeshAgent enemy;
    public float saldirmamesafe;
    public float mesafe;
    public int enemyhayat = 100;
    public Text enemytext;
   
    void Start()
    {
        karakter = GetComponent<Animator>();
        hedef = GameObject.Find("Player");
        enemy = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(hedef.transform.position);
        if (Input.GetKeyDown(KeyCode.G))
        {
            karakter.SetTrigger("blok");
        }
        else
        {
            karakter.SetTrigger("ziplama");
             mesafe = Vector3.Distance(this.transform.position, hedef.transform.position);
            if(mesafe < kovalamamesafe)
            {
                enemy.isStopped = false;
                enemy.SetDestination(hedef.transform.position);
                karakter.SetBool("box", false);
            }
            else
            {
                enemy.isStopped = true;
                karakter.SetBool("box", false);
                karakter.SetBool("tekme", false);
                karakter.SetBool("aparkat", false);

            }
            if(mesafe < saldirmamesafe)
            {
                enemy.isStopped = true;
                karakter.SetBool("box", true);
            }
        }
      
    }
    public void HasarVer()
    {
       hedef.GetComponent<NewBehaviourScript>().HasarAl();

    }
    private void OnCollisionEnter(Collision collision)
    {
        enemyhayat -= Random.Range(5, 10);
        enemytext.text = "Player 2" + enemyhayat;
        if (enemyhayat == 0)
        {  
            karakter.SetTrigger("ölme");
            Time.timeScale = 0;
        }
    }

}
