using UnityEngine;
/// <summary>
/// Esse script é responsável por gerenciar a mecânica de pegar e arrastar objetos no jogo.
/// Focado na experiência do usuário mobile.
/// </summary>
public class GrabAndDrop : MonoBehaviour
{
    private GameObject selectedObject; // Armazena o objeto que está sendo arrastado

    // Start é chamado uma vez antes do primeiro frame de Update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft; // Define a orientação da tela
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Verifica se o jogador está tocando na tela
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); // Pega a posição do toque
            touchPosition.z = 0; // Define a profundidade como 0, já que é um jogo 2D

            // Verifica a fase do toque
            switch (touch.phase)
            {
                case TouchPhase.Began: // Quando o toque começa
                    Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);

                    if (touchedCollider != null)
                    {
                        selectedObject = touchedCollider.gameObject; // Seleciona o objeto tocado
                    }
                    break;

                case TouchPhase.Moved: // Quando o toque se move
                    if (selectedObject != null)
                    {
                        selectedObject.transform.position = touchPosition; // Move o objeto para a posição do toque
                    }
                    break;

                case TouchPhase.Ended: // Quando o toque termina
                    selectedObject = null; // Libera o objeto arrastado
                    break;
            }
        }
    }
}