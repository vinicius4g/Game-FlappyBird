using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
   
    private Vector2 jumpForce = new Vector2(0,300); //força do pulo
    private Rigidbody2D rb2D;                       //usada para acessar o Rigibody2D, corpo do personagem
    private Animator anim;                          //responsável pelas animaçoes
    private bool IsFaling;                          //se o jogador esta caindo ou nao
    public GameObject gameMainController;           //controlador do jogo



    void Start()
    {
        //corpo fisico do personagem pega o componente
        rb2D = GetComponent<Rigidbody2D>();

        //conecta ao componente animator
        anim = GetComponent<Animator>();

    }

    
    void Update(){

        //atualiza o animador de acordo com a variavel
        anim.SetBool("IsFaling", IsFaling);

        //verifica se está caindo
        if (rb2D.velocity.y > 0)
        {
            IsFaling = false;
            Debug.Log("Subindo");
        }
        else
        {
            IsFaling = true;
            Debug.Log("Caindo");
        }

        //verifica se houve um toque
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || ( Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began  )){

            //Para a velocidade no ar
            rb2D.velocity = Vector2.zero;
            
            //Adiciona força no pulo
            rb2D.AddForce(jumpForce);

            Debug.Log("Pula!");
        }



        
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Pipe(Clone)")
        {
            //termina o jogo
            gameMainController.GetComponent<GameMainControllerScript>().endGame();

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.gameObject.name == "ScorePipe(Clone)")
        {
            //adiciona pontos ao colidir com ScorePipe 
            gameMainController.GetComponent<GameMainControllerScript>().addScore();

            Debug.Log("+1 ponto");

        }

    }


}
