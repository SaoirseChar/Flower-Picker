using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractWithFlowers();
    }
    
    public void InteractWithFlowers()
    {
        Ray ray = new Ray(transform.position + transform.forward * 0.5f, transform.forward); //Creates line from player to infinity 
        RaycastHit hitInfo; 
        int layerMask = LayerMask.NameToLayer("Interactable");
        
        layerMask = 1 << layerMask;

        //If Ray hits something
        if (Physics.Raycast(ray, out hitInfo, 10f, layerMask))
        {
            if (hitInfo.collider.name.Equals("Yellow Flower") || hitInfo.collider.name.Equals("Blue Flower") || hitInfo.collider.name.Equals("Pink Flower"))
            {
                Debug.Log("Interacting with" + hitInfo);
            }
            
            Debug.DrawRay(transform.position, transform.forward * 50, Color.blue );
        }
    }
}
