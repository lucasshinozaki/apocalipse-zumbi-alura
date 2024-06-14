using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float VELOCIDADE = 10;

    public Vector3 direcao;
    
    void Update() {

        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        if (direcao != Vector3.zero) {
            GetComponent<Animator>().SetBool("Movendo", true);
        } else {
            GetComponent<Animator>().SetBool("Movendo", false);
        }
    }

    void FixedUpdate() {
        GetComponent<Rigidbody>().MovePosition(
            GetComponent<Rigidbody>().position + 
            (direcao * VELOCIDADE * Time.deltaTime));
    }

}