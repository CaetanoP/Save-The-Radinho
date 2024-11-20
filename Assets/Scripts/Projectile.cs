using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{   

    [SerializeField] private float speed = 10f; // Velocidade do projétil
    [SerializeField] private float damage = 10f; // Dano do projétil
    [NonSerialized] public string targetTag; // Tag do alvo
    [NonSerialized] public Vector3 orientation; // Orientação do projétil

    [Header("Crédito do projétil")]
    public int credit = 0; // Custo do projétil
    [Header("Nome do projétil")]
    public string projectileName; // Nome do projétil

    //Método Update para movimentar o projétil sem depender do frame rate
    public void Update()
    {
        transform.Translate(orientation * speed * Time.deltaTime); // Move o projétil para cima
        //Se o projétil sair da tela, ele é destruído
        if (transform.position.y > 20f)
        {
            Destroy(gameObject);
        }

    }


    /// <summary>
    /// Para que possa colidir com outros objetos, é necessário adicionar um Collider2D ao projétil e ao objeto que ele irá colidir.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Colisão com " + other.name);
        //Verifica se o projétil colidiu com um inimigo
        if (other.CompareTag(targetTag))
        {
            if(targetTag == "Player")
                other.GetComponent<Player>().TakeDamage(damage);
            else
            other.GetComponent<Enemy>().TakeDamage(damage);
            //Destroi o projétil
            Destroy(gameObject);
        }
    }



}
