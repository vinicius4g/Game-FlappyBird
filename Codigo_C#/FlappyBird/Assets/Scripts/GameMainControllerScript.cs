using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMainControllerScript : MonoBehaviour
{

    private int score;               //pontuacao do jogador
    public Text scoreText;           //text de pontuaçao
    public Image gameOverImage;      //Imagem de fim de jogo
    public Image restartImageButton; //botao de reinicio
    public Image tutorialImage;      //Imagem de tutorial
    public Image startImageButton;   //botao de inicio
    public Image logoImage;          //logo do jogo
    private int gameState;           //cuida dos estados do jogo, 0 = Pre-game, 1 = In-Game, 2 = End-Game


    void Start()
    {
        //fazer a escala de tempo voltar ao normal, para reiniciar o jogo
        Time.timeScale = 1;
    }

   
    void Update()
    {   
        //teste de console
       // Debug.Log("Pontos:" + score);

        //atualiza a pontuaçao na tela
        scoreText.text = "Pontos: " + score;

        //verifica se o jogo deve estar com tempo
        if (gameState == 0 || gameState == 2)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }

    //adiciona pontuacao
    public void addScore()
    {
        //incrementa a pontuaçao
        score = score + 1;
    }

    public void startGame()
    {
        gameState = 1;
        tutorialImage.gameObject.SetActive(false);
        startImageButton.gameObject.SetActive(false);
        logoImage.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);

    }


    //reinicia o jogo
    public void restartGame()
    {
        //pega a cena atual
        Scene scene = SceneManager.GetActiveScene();

        //abre a cena com o mesmo nome (reinicia a cena)
        SceneManager.LoadScene(scene.name);


    }

    //apos terminar o jogo
    public void endGame()
    {
        //faz os objetos nao se mexeram pois zerou o tempo
        gameState = 2;

        //aparece as imagens de fim do jogo e reinicio 
        gameOverImage.gameObject.SetActive(true);
        restartImageButton.gameObject.SetActive(true);


    }


}
