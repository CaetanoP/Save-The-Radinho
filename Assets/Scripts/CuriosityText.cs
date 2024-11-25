using UnityEngine;
using TMPro;
public class CuriosityText : MonoBehaviour
{
    // Referência para o componente de texto na UI
    public TextMeshProUGUI factText;
    private string[] facts = new string[]
    {
        "A radiação ionizante pode causar mutações no DNA, que às vezes levam a câncer.",
        "O Sol é a maior fonte natural de radiação não ionizante, como a luz visível e os raios ultravioleta.",
        "Os aparelhos de raio-X utilizam radiação ionizante para gerar imagens médicas, mas sua exposição deve ser controlada.",
        "A radiação não ionizante, como as micro-ondas, é usada em comunicações e aquecimento de alimentos.",
        "Os efeitos biológicos da radiação dependem do tempo de exposição e da dose recebida.",
        "A radiação ionizante pode ser usada para esterilizar alimentos e equipamentos médicos.",
        "O corpo humano está naturalmente exposto a pequenas quantidades de radiação ionizante do ambiente.",
        "A proteção contra radiação ionizante inclui barreiras de chumbo e roupas específicas.",
        "Os campos eletromagnéticos de celulares emitem radiação não ionizante, considerada segura em níveis normais de uso.",
        "A radiação ultravioleta é uma forma de radiação não ionizante que pode causar queimaduras solares e câncer de pele."
    };
    public void Start()
    {
        // Exibe uma curiosidade aleatória ao iniciar o jogo
        ShowRandomFact();
    }


    // Método para exibir uma curiosidade aleatória
    public void ShowRandomFact()
    {
        // Gera um índice aleatório com base no tamanho do array
        int randomIndex = Random.Range(0, facts.Length);

        // Define o texto da UI com a curiosidade selecionada
        factText.text = facts[randomIndex];
    }
}
