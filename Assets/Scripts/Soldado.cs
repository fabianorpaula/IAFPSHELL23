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

    //maquina de estado
    public enum S_Estado { S_ronda, S_perseguir, S_atacar};
    public S_Estado MeuEstado;

    private bool atacando = false;
    private bool zonaDeAtaque = false;
    private int ponteiro;

    public GameObject PontodeSaida;
    public int hp = 10;




    void Start()
    {
        MeuEstado = S_Estado.S_ronda;
        Time.timeScale = 5;
        Anim = GetComponent<Animator>();
        Agente = GetComponent<NavMeshAgent>();
        //Randomizar
        ponteiro = Random.Range(0, Caminhos.Count);

    }

    // Update is called once per frame
    void Update()
    {

        ValidarAlvo();
        //Esta Fazendo Ronda
        if (MeuEstado == S_Estado.S_ronda)
        {
            Ronda();
        }
        //Esta Perseguindo
        if (MeuEstado == S_Estado.S_perseguir)
        {
            if(Fugiu(40))
            {
                MeuEstado = S_Estado.S_ronda;
            }
            else
            {
                CorrerAtras();
            }
            
        }
        //Esta Atacando
        if (MeuEstado == S_Estado.S_atacar)
        {
            if (Fugiu(20))
            {
                MeuEstado = S_Estado.S_perseguir;
            }
            else
            {
                Atirar();
            }
            
        }

        
    }

    void ValidarAlvo()
    {
        if(Alvo == null)
        {
            MeuEstado = S_Estado.S_ronda;
        }
    }

    public void Encontrou(GameObject meuAlvo)
    {
        //Recebe o Alvo
        Alvo = meuAlvo;
        MeuEstado = S_Estado.S_perseguir;
    }
    public bool Fugiu(int distanciaAlvo)
    {
        Agente.SetDestination(Alvo.transform.position);
        if (Vector3.Distance(transform.position, Alvo.transform.position) < distanciaAlvo)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void CorrerAtras()
    {
        //Encontrou Inimigo
        if(Alvo != null)
        {
            Agente.SetDestination(Alvo.transform.position);
            if (Vector3.Distance(transform.position, Alvo.transform.position) < 20)
            {
                MeuEstado = S_Estado.S_atacar;
            }
        }
        
        
    }

    public void Ronda()
    {
        Agente.speed = 10;
        
        Anim.SetBool("Atirando", false);

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

    public void Disparando()
    {
        RaycastHit hit;
        
        Vector3 frente = transform.TransformDirection(Vector3.forward) * 25;
        if (Physics.Raycast(PontodeSaida.transform.position, frente, out hit, 25))
        {
            if (hit.collider.gameObject.tag == "Inimigo")
            {

                hit.collider.gameObject.GetComponent<Soldado>().hp--;
                if(hit.collider.gameObject.GetComponent<Soldado>().hp <= 0)
                {
                    Destroy(hit.collider.gameObject);
                }
                Debug.DrawRay(PontodeSaida.transform.position, frente, Color.white);
            }
        }
        else
        {
           
        }
    }

}
