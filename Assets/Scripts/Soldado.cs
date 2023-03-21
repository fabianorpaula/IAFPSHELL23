using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldado : MonoBehaviour
{
    private NavMeshAgent Agente;
    public List<GameObject> Caminhos;
    private GameObject Alvo;
    private Animator Anim;

    private bool atacando = false;
    private bool zonaDeAtaque = false;
    private int ponteiro;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Agente = GetComponent<NavMeshAgent>();
        //Randomizar
        ponteiro = Random.Range(0, Caminhos.Count);

    }

    // Update is called once per frame
    void Update()
    {
        if(atacando == true)
        {
            if(zonaDeAtaque == true)
            {
                Atirar();
            }
            else
            {
                Ataque();
            }
            
        }
        else
        {
            Ronda();
        }
        
    }
    public void Encontrou(GameObject meuAlvo)
    {
        //Recebe o Alvo
        Alvo = meuAlvo;
        atacando = true;
    }
    public void Ataque()
    {
        //Encontrou Inimigo
        Agente.SetDestination(Alvo.transform.position);
        if(Vector3.Distance(transform.position, Alvo.transform.position) < 5)
        {
            zonaDeAtaque = true;
        }
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

    void Atirar()
    {
        Agente.speed = 0;
        transform.LookAt(Alvo.transform.position);
        Anim.SetBool("Atirando", true);
        
    }

}
