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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
