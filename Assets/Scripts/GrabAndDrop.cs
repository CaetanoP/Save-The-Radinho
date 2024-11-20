using UnityEngine;

/// <summary>
/// Script responsável por gerenciar a mecânica de pegar e arrastar objetos no jogo.
/// Focado na experiência do usuário mobile.
/// </summary>
public class GrabAndDrop : MonoBehaviour
{
    private GameObject selectedObject; // Objeto atualmente selecionado
    private Vector3 touchPosition; // Posição do toque convertida para o mundo
    private Collider2D touchedCollider; // Collider do objeto tocado

    
    private bool isSomeTimeFar = false; // Verifica se o objeto esta muito longe do mouse

    // Start é chamado uma vez antes do primeiro frame de Update
    private void Start()
    {
        // Configura a orientação da tela para LandscapeLeft
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Update é chamado uma vez por frame
    private void Update()
    {
        HandleTouchInput();
    }

    /// <summary>
    /// Gerencia a entrada do toque na tela.
    /// </summary>
    private void HandleTouchInput()
    {
        // Verifica se há toques na tela
        if (Input.touchCount <= 0)
            return;

        Touch touch = Input.GetTouch(0);
        touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchPosition.z = 0; // Garantir que o movimento seja em 2D

        // Processa o toque com base na fase
        switch (touch.phase)
        {
            case TouchPhase.Began:
                HandleTouchBegan();
                break;

            case TouchPhase.Moved:
                HandleTouchMoved();
                break;

            case TouchPhase.Ended:
                HandleTouchEnded();
                break;
        }
    }

    /// <summary>
    /// Lida com o início do toque na tela.
    /// </summary>
    private void HandleTouchBegan()
    {
        touchedCollider = Physics2D.OverlapPoint(touchPosition);
        isSomeTimeFar = false;
        if (touchedCollider != null)
        {
            selectedObject = touchedCollider.gameObject;

            // Verifica se o objeto possui o componente Item
            Item itemComponent = selectedObject.GetComponent<Item>();
            if (itemComponent != null)
            {
                itemComponent.WhenGrabbed();
            }
        }
    }


    /// <summary>
    /// Lida com o movimento do toque na tela.
    /// </summary>
    private void HandleTouchMoved()
    {
        if (selectedObject != null)
        {
            //Verifica se o objeto nao esta muito longe do mouse
            if (Vector3.Distance(selectedObject.transform.position, touchPosition) < 2 && isSomeTimeFar == false)
            {
                selectedObject.transform.position = touchPosition;
            }
            else
            {
                isSomeTimeFar = true;
            }
            
        }
    }

    /// <summary>
    /// Lida com o fim do toque na tela.
    /// </summary>
    private void HandleTouchEnded()
    {
        if (selectedObject != null)
        {
            Item itemComponent = selectedObject.GetComponent<Item>();
            if (itemComponent != null)
            {
                // Retorna o objeto para a posição inicial
                selectedObject.transform.position = itemComponent.initialPosition;
            }

            // Limpa a referência do objeto selecionado
            selectedObject = null;
        }
    }
}
