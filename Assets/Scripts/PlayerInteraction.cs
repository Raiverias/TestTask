using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteraction : MonoBehaviour
{
    public GameObject holder;
    public GameObject itemHolded;
    public bool isHolded = false;


    private void Update()
    {
        if (isHolded) 
        {
            itemHolded.transform.position = holder.transform.position;
        }
    }
    public void Hold(Transform item) 
    {
        isHolded = true;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.parent = holder.transform;
        
        itemHolded = item.gameObject;
        
        
    }
    public void PutDown() 
    {


        itemHolded.GetComponent<Rigidbody>().isKinematic = false;
        itemHolded.transform.parent = null;
        isHolded = false;
    }
   


    
}
