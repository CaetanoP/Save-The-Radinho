using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> 
/// Esse é um abiente de script para gerenciar o menu do jogo mobile.
/// Todas as funcionalidades devem ser implementadas visando a melhor experiência do usuário.
/// </summary>
/// 
/// <remarks>
/// O menu do jogo é a primeira tela que o jogador irá ver, por isso é importante que ele seja bem feito.
/// </remarks>
/// 
public class Menu : MonoBehaviour
{

    public void PlayGame()
    {
        // Carrega a cena do jogo
        SceneManager.LoadScene("Game");
        Debug.Log("Jogo iniciado");
    }

    public void QuitGame()
    {
        // Fecha o jogo
        Application.Quit();
    }


}
