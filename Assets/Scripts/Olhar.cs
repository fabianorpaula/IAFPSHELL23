using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olhar : MonoBehaviour
{
    public Soldado meuSoldado;
    public float visaoO = 40;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 frente = transform.TransformDirection(Vector3.forward) * visaoO;
        if(Physics.Raycast(transform.position, frente, out hit, visaoO))
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
