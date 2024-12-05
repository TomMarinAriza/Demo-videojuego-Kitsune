using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Configuración de Ataque")]
    [SerializeField] private KeyCode attackKey = KeyCode.E; // Tecla de ataque.

    private List<Collider2D> enemiesInRange = new List<Collider2D>(); // Lista de enemigos en rango.

    private void Update()
    {
        // Detectar entrada de ataque.
        if (Input.GetKeyDown(attackKey) && enemiesInRange.Count > 0)
        {
            Attack();
        }
    }

    private void Attack()
    {
        // Iterar sobre los enemigos en rango y destruirlos.
        foreach (Collider2D enemyCollider in enemiesInRange)
        {
            if (enemyCollider != null)
            {
                Debug.Log($"Golpeaste y destruiste a {enemyCollider.name}");
                Destroy(enemyCollider.gameObject); // Destruir el objeto enemigo.
            }
        }

        // Vaciar la lista después de destruir los enemigos.
        enemiesInRange.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detectar si un enemigo entra al rango.
        if (collision.CompareTag("enemies"))
        {
            enemiesInRange.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Eliminar al enemigo de la lista si sale del rango.
        if (collision.CompareTag("enemies"))
        {
            enemiesInRange.Remove(collision);
        }
    }
}
