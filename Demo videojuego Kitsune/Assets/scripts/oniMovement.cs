using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento
    public float checkDistance = 1f; // Distancia para verificar el borde de la plataforma
    public float detectionRange = 5f; // Rango de detección del jugador
    public LayerMask groundLayer; // Capa de la plataforma
    public LayerMask playerLayer; // Capa del jugador

    private bool isPlayerDetected = false; // Estado de detección del jugador
    private Transform player; // Referencia al jugador
    private SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer

    void Start()
    {
        // Buscar al jugador en la escena
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtener el SpriteRenderer del enemigo
    }

    void Update()
    {
        // Verificar si el jugador está dentro del rango de detección
        CheckForPlayerDetection();

        // Mover al enemigo si el jugador está detectado
        if (isPlayerDetected)
        {
            MoveTowardsPlayer();
        }

        // Verificar si el enemigo está cerca del borde de la plataforma y detenerse
        CheckForEdge();
    }

    void CheckForPlayerDetection()
    {
        // Detecta si el jugador está dentro del rango usando un Raycast hacia la dirección del enemigo
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, detectionRange, playerLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, detectionRange, playerLayer);
        
        if (hitLeft.collider != null && hitLeft.collider.CompareTag("Player"))
        {
            isPlayerDetected = true; // El jugador está a la izquierda
        }
        else if (hitRight.collider != null && hitRight.collider.CompareTag("Player"))
        {
            isPlayerDetected = true; // El jugador está a la derecha
        }
        else
        {
            isPlayerDetected = false; // El jugador no está dentro del rango
        }
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            // Calcular la dirección hacia el jugador (eje X)
            float direction = player.position.x > transform.position.x ? 1f : -1f;

            // Verificar si la dirección es hacia la izquierda
            if (direction < 0 && !spriteRenderer.flipX)
            {
                Flip(); // Voltear el sprite para que mire hacia la izquierda
            }
            // Verificar si la dirección es hacia la derecha
            else if (direction > 0 && spriteRenderer.flipX)
            {
                Flip(); // Voltear el sprite para que mire hacia la derecha
            }

            // Mover al enemigo hacia el jugador en el eje X
            transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);
        }
    }

    void CheckForEdge()
    {
        // Verificar si el enemigo está cerca del borde de la plataforma
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, checkDistance, groundLayer);

        // Si no hay plataforma debajo, el enemigo se detiene
        if (hit.collider == null)
        {
            StopMovement();
        }
    }

    void StopMovement()
    {
        // Detener el movimiento deteniendo la traducción
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void Flip()
    {
        // Cambiar el valor de flipX para voltear el sprite horizontalmente
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
