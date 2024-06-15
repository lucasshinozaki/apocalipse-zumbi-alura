using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{

    public float VELOCIDADE = 10;

    public Vector3 direcao;
    public LayerMask MascaraDoChao;
    public GameObject TextoGameOver;
    public bool Vivo = true;

    private void Start()
    {
        Time.timeScale = 1;
    }
    
    void Update() {

        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        if (direcao != Vector3.zero) {
            GetComponent<Animator>().SetBool("Movendo", true);
        } else {
            GetComponent<Animator>().SetBool("Movendo", false);
        }

        if (Vivo == false) {
            if (Input.GetButtonDown("Fire1")) {
                SceneManager.LoadScene("game");
            }
        }
    }

    void FixedUpdate() {
        GetComponent<Rigidbody>().MovePosition(
            GetComponent<Rigidbody>().position + 
            (direcao * VELOCIDADE * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100, MascaraDoChao)) {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }

    }

}
