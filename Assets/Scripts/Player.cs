using System;
using TMPro;
using UnityEngine;
/// <summary>
/// Este script gerencia o jogador.
/// Ele controla a vida, ataque e velocidade de ataque do jogador.
/// O jogador não é controlado diretamente pelo usuário.
/// </summary>
public class Player : MonoBehaviour
{
    // Variáveis de controle do jogador
    [SerializeField] public float health = 100f; // Vida do jogador
    [SerializeField] private float reloadTime = 3f; // Tempo entre ataques em segundos
    [SerializeField] private GameObject projectile; // Projétil do jogador
    [Header("Crédito do jogador")]
    [SerializeField] public int credit = 0; // Crédito do jogador
    // Variáveis de controle do ataque
    [SerializeField] private TextMeshProUGUI healthText; // Barra de vida do jogador
    bool canAttack = true; // Pode atacar?
    private float nextAttackTime = 0f; // Tempo do próximo ataque

    public void Start()
    {
        // Da crédito inicial ao jogador
        credit = 100; 
        //Atualiza a barra de vida
        healthText.text = health.ToString();
    }
    public void Update()
    {
        // Verifica se o jogador está vivo
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Lógica de morte do jogador
        Destroy(gameObject);
        Debug.Log("O jogador morreu.");
    }

    /// <summary>
    /// Metodo chamdo pelo botão de ataque
    /// </summary>
    public void Attack()
    {
        if(!canAttack)
        {
            return;
        }
        // Lógica de ataque ao inimigo
        GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);

        // Define a tagAlvo do projétil
        instance.GetComponent<Projectile>().targetTag = "Enemy";
        // Define a orientação do projétil
        instance.GetComponent<Projectile>().orientation = Vector3.right;
        canAttack = false;
        Invoke("Reload", reloadTime);
    }

    // Método para reduzir a vida do jogador
    public void TakeDamage(float damage)
    {
        health -= damage;
        //Atualiza a barra de vida
        healthText.text = health.ToString();
    }

    public void Reload()
    {
        canAttack = true;
    }
}
