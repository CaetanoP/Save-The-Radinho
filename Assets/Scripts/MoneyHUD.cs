using UnityEngine;

public class MoneyHUD : MonoBehaviour
{
    private Player player; // Referência ao script Player
    public GameObject moneyText; // Referência ao texto de crédito

    // Update is called once per frame
    public void Start()
    {
        // Pega referência do script Player
        player = GameObject.Find("Player").GetComponent<Player>();
    }   
    public void Update()
    {
        // Atualiza o texto de crédito
        moneyText.GetComponent<TMPro.TextMeshProUGUI>().text = player.credit.ToString();
        
    }
}
