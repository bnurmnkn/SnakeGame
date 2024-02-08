using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{
    public GameObject tail;
    List<GameObject> tails;
    Vector3 oldCoordinate;
    GameObject oldTail;
    public float Speed=30.0f;

    public GameObject FinishPanel;


    void Start()
    {
        tails=new List<GameObject>();
        for(int i=0;i<5;i++)
        {
            GameObject newTail=Instantiate(tail,transform.position,Quaternion.identity);
            tails.Add(newTail);

        }
        InvokeRepeating("Movement",0.0f,0.1f);
    }

    
    void Movement()
    {
        oldCoordinate=transform.position;
        transform.Translate(0,0,Speed*Time.deltaTime);
        FollowTail();
    }
    void FollowTail()
    {
        tails[0].transform.position=oldCoordinate;
        oldTail=tails[0];
        tails.RemoveAt(0);
        tails.Add(oldTail);


    }
    public void Rotation(float angle)
    {
        transform.Rotate(0,angle,0);

    }
    public void IncreaseTail()
    {
        GameObject newTail=Instantiate(tail,transform.position,Quaternion.identity);
        tails.Add(newTail);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("wall") )
        {
            FinishPanel.SetActive(true);
            Time.timeScale=0.0f;
        }
        
    }
    public void AgainButton()
    {
        Time.timeScale=1.0f;
        SceneManager.LoadScene(0);
        

    }
}
