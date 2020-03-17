using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerScript : MonoBehaviour 
{

    public GameObject pipePrefab; //objeto do cano
    public GameObject floorPrefab; //objeto do chao
    public GameObject scorePipePrefab; //objeto da pontuaçao

    void Start()
    {
        //chama a função repetidamente (Nome da funçao, Após quanto tempo Chama, A cada Quanto tempo Chama)
        InvokeRepeating("GenarateNewPipe", 3f , 1f);

        //chama a funcao chao infinito
        InvokeRepeating("GenarateFloor", 0f, 0.5f);

    }


    void GenarateFloor()
    {
        //posicao do chao gerado
        Vector2 floorPositon = new Vector2(5f, -4.8f);

        //cano de cima                              
        GameObject floor = Instantiate(floorPrefab, floorPositon, Quaternion.identity) as GameObject;
    }



    void GenarateNewPipe()
    {

        //gera uma altura aleatoria
        float middleYPositon = Random.Range(-2, 2);

        //posiçoes dos canos
        Vector2 upperPipePositon = new Vector2(transform.position.x, middleYPositon + 5f);
        Vector2 bottomPipePositon = new Vector2(transform.position.x, middleYPositon - 5f);
        Vector2 scorePipePositon = new Vector2(transform.position.x + 0.5f, middleYPositon);

        //pipe da pontuaçao
        GameObject scorePipe = Instantiate(scorePipePrefab, scorePipePositon, Quaternion.identity) as GameObject;



        //cano de cima                     //quem ele quer chamar, onde ele quer chamar, angulo quele quer rotacionar quando esta instanciando           
        GameObject upperPipe = Instantiate(pipePrefab, upperPipePositon, Quaternion.identity) as GameObject;

        //Cano de baixo
        GameObject bottomPipe = Instantiate(pipePrefab, bottomPipePositon, Quaternion.identity) as GameObject;
        
        //inverte o cano de baixo
        bottomPipe.transform.localScale = new Vector3(bottomPipe.transform.localScale.x, -bottomPipe.transform.localScale.y, 0);
    }


}
