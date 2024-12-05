using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuración de Spawn")]
    [SerializeField] private GameObject enemyPrefab; // Prefab del enemigo.
    [SerializeField] private float spawnInterval = 3f; // Tiempo entre revisiones.
    [SerializeField] private float spawnY = 12f; // Coordenada fija en Y.
    [SerializeField] private float spawnRangeX = 3f; // Rango de distancia alrededor del jugador en X para el spawn.
    [SerializeField] private float movementSpeedX = 2f; // Velocidad de movimiento del spawn en X.
    
    private Transform player; // Referencia al jugador.
    private float spawnX; // Posición de spawn en X.

    private void Start()
    {
        // Buscar al jugador por su etiqueta.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        // Iniciar la rutina de spawn.
        StartCoroutine(CheckAndSpawnEnemy());
    }

    private void Update()
    {
        // Mover el spawn en el eje X, siguiendo al jugador.
        if (player != null)
        {
            // Actualizar la posición de spawn, desplazándose hacia la posición X del jugador
            spawnX = Mathf.Lerp(transform.position.x, player.position.x, movementSpeedX * Time.deltaTime);
            transform.position = new Vector2(spawnX, transform.position.y);
        }
    }

    private IEnumerator CheckAndSpawnEnemy()
    {
        while (true)
        {
            // Solo spawnea si no hay un enemigo activo.
            if (GameObject.FindGameObjectWithTag("enemies") == null)
            {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(spawnInterval); // Esperar el intervalo antes de volver a verificar.
        }
    }

    private void SpawnEnemy()
    {
        // Generar una posición aleatoria en X dentro del rango alrededor del jugador.
        float randomOffsetX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(player.position.x + randomOffsetX, spawnY);

        // Instanciar el prefab del enemigo.
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
