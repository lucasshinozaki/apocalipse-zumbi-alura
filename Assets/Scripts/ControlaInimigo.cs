using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{

    public GameObject Jogador;
    public float VELOCIDADE_INIMIGO = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 direcao = Jogador.transform.position - transform.position;
        GetComponent<Rigidbody>().MovePosition(
            GetComponent<Rigidbody>().position + 
            direcao.normalized * VELOCIDADE_INIMIGO * Time.deltaTime); 
    }
}
