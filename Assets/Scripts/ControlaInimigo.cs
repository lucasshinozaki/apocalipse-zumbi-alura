using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{

    public GameObject Jogador;
    public float VELOCIDADE_INIMIGO = 5;
    private Rigidbody rigidbodyInimigo;
    private Animator animatorInimigo;

    void Start()
    {
         Jogador = GameObject.FindWithTag("Jogador");
         int geraTipoZumbi = Random.Range(1, 28);
         transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
         rigidbodyInimigo = GetComponent<Rigidbody>();
         animatorInimigo = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);
        Vector3 direcao = Jogador.transform.position - transform.position;
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            rigidbodyInimigo.MoveRotation(novaRotacao);

        if (distancia > 2.5) {
            rigidbodyInimigo.MovePosition(
                rigidbodyInimigo.position + 
                direcao.normalized * VELOCIDADE_INIMIGO * Time.deltaTime);
            animatorInimigo.SetBool("Atacando", false);
        } else {
            animatorInimigo.SetBool("Atacando", true);
        }
    }

    void AtacaJogador() {
        Time.timeScale = 0;
        Jogador.GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);
        Jogador.GetComponent<ControlaJogador>().Vivo = false;
    }
}
