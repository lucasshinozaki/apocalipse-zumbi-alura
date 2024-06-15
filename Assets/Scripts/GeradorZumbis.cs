using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{
    public GameObject Zumbi;
    float contadorTempo = 0;
    public float TempoGeraZumbi = 1;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        contadorTempo += Time.deltaTime;

        if (contadorTempo >= TempoGeraZumbi) {
            Instantiate(Zumbi, transform.position, transform.rotation);
            contadorTempo = 0;
        }

    }
}
