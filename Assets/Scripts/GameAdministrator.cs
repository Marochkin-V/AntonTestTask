using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAdministrator : MonoBehaviour
{

    [SerializeField] private GameObject winBack;
    [SerializeField] private GameObject loseBack;
    [SerializeField] private GameObject ESCMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ESCMenu.SetActive(!ESCMenu.active);
        }
    }

    private void OnEnable()
    {
        EventManager.GameOverEvent += GameOverHandler;
        EventManager.WinEvent += WinHandler;
        EventManager.PlayerDeathEvent += PlayerDeathHandler;
    }

    private void OnDisable()
    {
        EventManager.GameOverEvent -= GameOverHandler;
        EventManager.WinEvent -= WinHandler;
        EventManager.PlayerDeathEvent -= PlayerDeathHandler;
    }

    private void GameOverHandler(object sender, GameOverEventArgs e)
    {
        if (e.IsGameOver)
        {
            loseBack.SetActive(true);
        }
    }

    private void WinHandler(object sender, WinEventArgs e)
    {
        if (e.IsWin)
        {
            winBack.SetActive(true);
        }
    }

    private void PlayerDeathHandler(object sender, PlayerDeathEventArgs e)
    {
        if (e.IsDead)
        {
            loseBack.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        int nextLvlIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings >= nextLvlIndex)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
        {
            Debug.Log("Больше уровней в билде нет.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
