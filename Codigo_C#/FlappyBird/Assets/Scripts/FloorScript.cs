using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move o pipe(cano) infinitamente para a esquerda
        transform.position += Vector3.left * 4f * Time.deltaTime; //time.deltaTime vai rodar de acordo como ele ta funcionando e nao influnciar

        // a posicao dele for menor que -10
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
