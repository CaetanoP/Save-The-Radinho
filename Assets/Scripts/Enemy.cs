using UnityEngine;

/// <summary>
/// Este script gerencia o inimigo.
/// Ele controla a vida, ataque e velocidade de ataque do inimigo.
/// </summary>
public class Enemy : MonoBehaviour
{
    // Variáveis de controle do Inimigo
    [SerializeField] public float health = 100f; // Vida do Inimigo
    [SerializeField] private float attackSpeed = 1f; // Tempo entre ataques em segundos
    [SerializeField] private GameObject projectile; // Projétil do Inimigo

    private float nextAttackTime = 0f; // Tempo do próximo ataque

    private float randomStopTime = 0f; // Tempo aleatório para parar de andar

    private bool isWalking = true; // Verifica se o inimigo está andando

    void Start()
    {
        randomStopTime = Random.Range(2f, 5f); // Define um tempo aleatório para parar de andar
    }
    void Update()
    {
        // Verifica se o inimigo está vivo
        if (health <= 0)
        {
            Die();
        }

        // Realiza o ataque se for o momento
        if (Time.time >= nextAttackTime && isWalking)
        {
            Attack();
            nextAttackTime = Time.time + attackSpeed; // Atualiza o próximo momento para atacar
        }

        if (Time.time >= randomStopTime)
        {
            randomStopTime = Time.time + Random.Range(2f, 5f); // Atualiza o próximo momento para parar de andar
            isWalking = !isWalking; // Inverte o estado de andar
            Debug.Log("Inimigo parou de andar");
        }

    }

    private void Die()
    {
        // Lógica de morte do inimigo
        Destroy(gameObject);
        Debug.Log("O Inimigo morreu.");
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

