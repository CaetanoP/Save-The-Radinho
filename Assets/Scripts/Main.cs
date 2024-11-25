using TMPro;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject Spawner;

    public void Start()
    {
        // Pega referência do script Player
        player = GameObject.Find("Player");
    }
    public void Update()
    {
        //verifica se o player nao é nulo
        if (player != null)
        {
            // Verifica se o jogador está vivo
            if (player.GetComponent<Player>().health <= 0 ||player.GetComponent<Player>().credit <= 0)
            {
                GameOver();
            }
            else if (player.GetComponent<Player>().credit >= 200)
            {
                Win();
            }
        }
        else
        {
            GameOver();
        }

    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Spawner.SetActive(false);
        FinalSetup();
    }
    public void Win()
    {
        winScreen.SetActive(true);
        Spawner.SetActive(false);
        FinalSetup();
    }

    public void Restart()
    {
        Debug.Log("Restart");
        //Restarta a cena
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void FinalSetup()
    {
        //Procura todo os inimigos e destroi
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        //Desativa o Spawn
        Spawner.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
