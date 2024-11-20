using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Nome do Item")]
    [SerializeField] private string itemName; // Nome do item
    [Header("Custo do item")]
    public int cost = 10; // Custo do item
    private Player player;  // Referência ao script Player
    [NonSerialized] public Vector3 initialPosition; // Armazena a posição inicial do item
    public void Start()
    {
        //Pega referência do script Player
        player = GameObject.Find("Player").GetComponent<Player>();
        //Armazena a posição inicial do item
        initialPosition = transform.position;
    }

    // Update is called once per frame
    public void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Verifica se o item colidiu com o projétil
        if (other.CompareTag("Projectile"))
        {
            //Pega o nome do objeto que colidiu
            string gameObjectGetName = other.gameObject.GetComponent<Projectile>().projectileName;
            Debug.Log("Colisão com " + gameObjectGetName);
            Debug.Log("Item: " + itemName);
            switch (itemName)
            {
                case "Papel":
                    if (gameObjectGetName== "Alfa")
                    {
                        RewardPlayer(other.GetComponent<Projectile>().credit, other.gameObject);
                    }
                    break;
                case "Aluminio":
                    if (gameObjectGetName == "Alfa" || gameObjectGetName == "Beta")
                    {
                        RewardPlayer(other.GetComponent<Projectile>().credit, other.gameObject);
                    }
                    break;
                case "Concreto":
                    if (gameObjectGetName == "Alfa" || gameObjectGetName == "Beta" || gameObjectGetName == "RaioX")
                    {
                        RewardPlayer(other.GetComponent<Projectile>().credit, other.gameObject);
                    }
                    break;
                case "Chumbo":
                    if (gameObjectGetName == "Alfa" || gameObjectGetName == "Beta" || gameObjectGetName == "RaioX"|| gameObjectGetName == "Gama")
                    {
                        RewardPlayer(other.GetComponent<Projectile>().credit, other.gameObject);
                    }
                    break;
            }
            //Move o item para a posição inicial
            transform.position = initialPosition;
            //Desabilita o GrabAndDrop
            GameObject.Find("main").GetComponent<GrabAndDrop>().enabled = false;
            //Chama o método ReloadGrabAndDrop após 1 segundo
            Invoke("ReloadGrabAndDrop", 0.1f);
        }
    }
    private void ReloadGrabAndDrop()
    {
        //Habilita o GrabAndDrop
        GameObject.Find("main").GetComponent<GrabAndDrop>().enabled = true;
    }

    public void WhenGrabbed()
    {
        //Tira creditos do jogador
        player.credit -= cost;
    }

    private void RewardPlayer(int credit, GameObject proj)
    {
        //Adiciona créditos ao jogador
        player.credit += credit;
        //Destroi o projétil
        Destroy(proj);
    }
}
