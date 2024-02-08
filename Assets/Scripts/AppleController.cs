using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AppleController : MonoBehaviour
{
    public TextMeshProUGUI skorText;
    float skor=0;
    //x=13.3 -14.5 
    //z=7.5  -10
    MovementController _movementScripti;

    private void Start(){
        _movementScripti=GameObject.Find("Head").GetComponent<MovementController>();
    }


    private void  OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("head"))
        {
            skor+=10;
            skorText.text="SKOR: "+(int)skor+"";
            Debug.Log("beyza");
            _movementScripti.IncreaseTail();
            ChangeCoordinate();

        }
        if(other.gameObject.tag=="tail")
        {
            Debug.Log("mankan");
            ChangeCoordinate();
        }
    }
    void ChangeCoordinate()
    {
        float x_values=Random.Range(-14.0f,13.0f);
        float z_values=Random.Range(-10.0f,7.0f);
        
        transform.position=new Vector3(x_values,0,z_values);
    }
}
