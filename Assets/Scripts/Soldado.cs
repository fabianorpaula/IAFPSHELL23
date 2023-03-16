using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldado : MonoBehaviour
{
    private NavMeshAgent Agente;
    public List<GameObject> Caminhos;
    private int ponteiro;
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        //Randomizar
        ponteiro = Random.Range(0, Caminhos.Count);

    }

    // Update is called once per frame
    void Update()
    {
        Ronda();
    }

    public void Ronda()
    {
        //Quero que vá para ronda
        Agente.SetDestination(Caminhos[ponteiro].transform.position);
        //Distancia Entre os Pontos
        float minhaDistancia = Vector3.Distance(transform.position, Caminhos[ponteiro].transform.position);
        if(minhaDistancia < 3)
        {
            ponteiro = Random.Range(0, Caminhos.Count);
        }
    }
}
