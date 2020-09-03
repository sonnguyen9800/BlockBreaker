#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private enum GameState
    {
        IDLE,
        PLAYING,
        END
    }
    
    [SerializeField]private KeyCode launchKey = KeyCode.UpArrow;
    [SerializeField]private Ball ball;
    [SerializeField]private int currentHP = 3;
    [SerializeField]private Hitpoint hitpointDisplayer;
    [SerializeField]private int numBlocks = 0;

    private GameState gameState = GameState.IDLE;
    private Scene currentScene;


    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void Start()
    {
        if (hitpointDisplayer == null)
        {
            Debug.LogError("Null hitpoint");
        }else
        {
            hitpointDisplayer.setLife(this.currentHP);
        }
        
    }
    private void Update()
    {
        //Debug.Log(gameState);
        if (gameState == GameState.IDLE)
        {
            if (Input.GetKeyDown(launchKey))
            {
                ball.LaunchBall();
                gameState = GameState.PLAYING;
            }
            return;
        }
        if (gameState == GameState.PLAYING)
        {
            if (ball.HasTouchBottom)
            {
                LoseHealth();
            }
            return;
        }
        if (gameState == GameState.END)
        {
            ball.Die();
            return;
        }
    }
    public void LoseHealth()
    {
        currentHP--;
        hitpointDisplayer.setLife(this.currentHP);
        //Debug.Log("Current health:" + currentHP);
        if (currentHP > 0)
        {
            ball.MoveToPaddle();
            gameState = GameState.IDLE;
        }
        else
        {
            gameState = GameState.END;
            SceneManager.LoadScene("LoseScene");
        }


    }

    public void blockDestroyed()
    {
        this.numBlocks--;

        if (this.numBlocks == 0)
        {
            switch (currentScene.name)
            {
                case ("Level1"):
                    SceneManager.LoadScene("Level2");
                    break;
                case ("Level2"):
                    SceneManager.LoadScene("Level3");
                    break;
                case ("Level3"):
                    SceneManager.LoadScene("VictoryScene");
                    break;
            }
        }
    }

    public void addBlock()
    {
        this.numBlocks++;
    }

}
