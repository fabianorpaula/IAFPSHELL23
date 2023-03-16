using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olhar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 frente = transform.TransformDirection(Vector3.forward) * 10;
        if(Physics.Raycast(transform.position, frente, out hit, 10))
        {
            if(hit.collider.gameObject.tag == "Inimigo")
            {
                Debug.Log("Acertou!!!!");
                Debug.DrawRay(transform.position, frente, Color.red);   
            }
            else
            {
                Debug.Log("Não Acertou!!!!");
                Debug.DrawRay(transform.position, frente, Color.green);
            }
        }
    }
}
