using System;
using UnityEngine;

public class flyingYokaiAttack : MonoBehaviour
{
    [Header("Movimiento del Enemigo")]
    [SerializeField] private float speed = 5f; // Velocidad de movimiento del enemigo (en ambos ejes X y Y).
    [SerializeField] private float stopHeight = 1.5f; // Altura relativa al jugador donde se detendrá (en Y).
    
    private Transform player; // Referencia al jugador.
    private bool isAttacking = false; // Indica si el enemigo está atacando.

    private void Start()
    {
        // Encontrar al jugador por su etiqueta.
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró un objeto con la etiqueta 'Player'.");
        }
    }

    private void Update()
    {
        if (player != null && !isAttacking)
        {
            // Mover al enemigo hacia la posición del jugador en ambos ejes X y Y.
            Vector2 targetPosition = new Vector2(player.position.x, player.position.y + stopHeight);

            // Calcular la dirección hacia el jugador.
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

            // Mover al enemigo suavemente hacia la posición objetivo.
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar si el jugador colisiona con el enemigo.
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("El jugador ha sido atacado por el enemigo.");
        }
    }
}
