using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    static MiniGameManager minigameManager;
    UIManager uiManager;

    public UIManager UIManager
    {
        get { return uiManager; }
    }

    public static MiniGameManager Instance
    {
        get { return minigameManager; }
    }

    private int currentScore = 0;

    private void Awake()
    {
        minigameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene"); // 메인 타일맵 씬 이름을 여기에 입력
    }


    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
        Debug.Log("Score: " + currentScore);
    }

}
