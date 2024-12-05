using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    [Header("Carrusel Settings")]
    [SerializeField] private Vector2 backgroundSpeed; 

    [Header("Seguir al Jugador")]
    [SerializeField] private GameObject _player; 
    [SerializeField] private float fixedYPosition = 0f; 
    

    private Material material; 
    private Transform playerTransform; 
    private Vector2 textureOffset;

    private void Awake() {
        
        material = GetComponent<SpriteRenderer>().material;

        
        if (_player != null)
        {
            playerTransform = _player.transform;
        }
        else
        {
            Debug.LogError("No se asignó el jugador (_player) al script.");
        }
    }

    private void Update() {
        if (playerTransform != null)
        {
           
            transform.position = new Vector3(playerTransform.position.x , fixedYPosition + 1.5f, 0);

           
            textureOffset = new Vector2(playerTransform.position.x * backgroundSpeed.x, 0);
            material.SetTextureOffset("_MainTex", textureOffset);
        }
    }
}
