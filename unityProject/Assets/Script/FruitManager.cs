using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public float puan;
    
    bool colliderBusy = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag == "Player" )
        {

            colliderBusy = true;
            other.GetComponent<PlayerManager>().GetSkor(puan);
            Destroy(gameObject);
           
        }
        
    }

  
}
