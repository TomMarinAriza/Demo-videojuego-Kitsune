using UnityEngine;

public class EnemyShooter2D : MonoBehaviour
{
    [Header("Enemy Settings")]
    public Transform player; // Referencia al jugador
    public Transform shootPoint; // Punto desde el que se disparan los proyectiles
    public GameObject projectilePrefab; // Prefab del proyectil
    public float shootInterval = 2f; // Intervalo entre disparos
    public float projectileSpeed = 7f; // Velocidad del proyectil
    public float followSpeed = 2f; // Velocidad de movimiento en el eje X
    public float detectionRange = 15f; // Rango de detección para seguir al jugador

    private float shootCooldown;

    void Update()
    {
        if (player != null)
        {
            // Moverse hacia el jugador en el eje X
            FollowPlayer();

            // Disparar si el jugador está dentro del rango
            if (Vector2.Distance(transform.position, player.position) <= detectionRange)
            {
                AimAndShoot();
            }
        }
    }

    void FollowPlayer()
    {
        // Solo se mueve en el eje X hacia el jugador
        Vector2 targetPosition = new Vector2(player.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Girar al enemigo según la dirección del jugador
        Vector3 scale = transform.localScale;
        scale.x = (player.position.x < transform.position.x) ? Mathf.Abs(scale.x) * -1 : Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    void AimAndShoot()
    {
        // Reducir el tiempo de enfriamiento
        shootCooldown -= Time.deltaTime;

        if (shootCooldown <= 0f)
        {
            // Apuntar hacia el jugador
            Vector2 direction = (player.position - shootPoint.position).normalized;

            // Instanciar el proyectil
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

            // Configurar la velocidad del proyectil
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * projectileSpeed;
            }

            // Destruir el proyectil después de 5 segundos
            Destroy(projectile, 3f);

            // Reiniciar el tiempo de enfriamiento
            shootCooldown = shootInterval;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizar el rango de detección en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
