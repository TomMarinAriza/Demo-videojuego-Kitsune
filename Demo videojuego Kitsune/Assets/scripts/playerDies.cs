using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;

public class playerDies : MonoBehaviour
{
    bool isDead ;
    Rigidbody2D  _playerRigidbody;

    public event EventHandler OnPlayerDeath;


    void Start()
    {
        isDead = false;
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemies" && !isDead)
        {
            Die();
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "proyectile" && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        OnPlayerDeath?.Invoke(this, EventArgs.Empty);
        restartScene();
    }

    void restartScene()
    {
        Physics2D.IgnoreLayerCollision(3,6,false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
