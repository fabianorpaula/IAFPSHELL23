using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olhar : MonoBehaviour
{
    public Soldado meuSoldado;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 frente = transform.TransformDirection(Vector3.forward) * 40;
        if(Physics.Raycast(transform.position, frente, out hit, 40))
        {
            if(hit.collider.gameObject.tag == "Inimigo")
            {
                
                meuSoldado.Encontrou(hit.collider.gameObject);
                Debug.DrawRay(transform.position, frente, Color.red);   
            }
        }
        else
        {
            Debug.Log("Não Acertou!!!!");
            Debug.DrawRay(transform.position, frente, Color.yellow);
        }
    }
}
