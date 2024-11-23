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
        //Verifica se o dinheiro do player é menor que 0
        if (player.GetComponent<Player>().credit <= 0)
        {
            GameOver();
        }
        if(player.GetComponent<Player>().credit >= 200)
        {
            Win();
        }
        
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Spawner.SetActive(false);

    }
    public void Win()
    {
        winScreen.SetActive(true);
        Spawner.SetActive(false);
    }

    public void Restart()
    {
        //Restarta a cena
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    
}
