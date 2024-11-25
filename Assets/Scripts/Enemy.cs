using UnityEngine;

/// <summary>
/// Este script gerencia o inimigo.
/// Ele controla a vida, ataque e velocidade de ataque do inimigo.
/// </summary>
public class Enemy : MonoBehaviour
{
    // Variáveis de controle do Inimigo
    private float health = 3f; // Vida do Inimigo
    [SerializeField] private float attackSpeed = 1f; // Tempo entre ataques em segundos
    [SerializeField] private GameObject projectile; // Projétil do Inimigo
    [SerializeField] private float velocity = 3f; // Velocidade do Inimigo

    private float nextAttackTime = 0f; // Tempo do próximo ataque

    public void Start()
    {
    
    }
    public void Update()
    {
        // Verifica se o inimigo está vivo
        if (health <= 0)
        {
            Die();
        }

        // Realiza o ataque se for o momento
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackSpeed; // Atualiza o próximo momento para atacar
        }

        //Se a distancia do player for menor que 10, o inimigo da dano no player e para de andar
        if(Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 1)
        {
            Debug.Log("Player está perto");
            GameObject.Find("Player").GetComponent<Player>().TakeDamage(10);
            Destroy(gameObject);
            velocity = 0;
        }
        else
        {
            // Movimenta o inimigo
            transform.position += Vector3.left * Time.deltaTime * velocity;
            velocity = 3;
        }


    }

    private void Die()
    {
        // Lógica de morte do inimigo
        Destroy(gameObject);
        //Debug.Log("O Inimigo morreu.");
    }

    private void Attack()
    {
        // Lógica de ataque ao Player
        GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);

        // Define a tagAlvo do projétil
        instance.GetComponent<Projectile>().targetTag = "Player";
        // Define a orientação do projétil
        instance.GetComponent<Projectile>().orientation = Vector3.left;
    }

    //Método para reduzir a vida do inimigo
    public void TakeDamage(float damage)
    {
        health -= damage;

    }
}

