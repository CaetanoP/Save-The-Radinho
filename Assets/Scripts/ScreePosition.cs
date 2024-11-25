using UnityEngine;

public class ScreePosition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Verifica qual cena está sendo executada se for Game a tela é horizontal e se for Menu a tela é vertical
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game")
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        
        
    }

    
}
