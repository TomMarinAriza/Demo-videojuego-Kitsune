using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class characterMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 10f;
    [SerializeField] float _jumpForce = 5.5f;
    int _remainingJumps = 0 ;

    Rigidbody2D _playerRigidbody;
    BoxCollider2D _playerCollider;

    bool _canJump;

    float _horizontal;


    void Start()
    {
        _playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        _playerCollider = gameObject.GetComponent<BoxCollider2D>();
        
        _playerRigidbody.transform.position = new Vector2(-6.46f, -3.21f);
    }

    
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        flipCharacter(_horizontal);

        _playerRigidbody.velocity = new Vector2(_horizontal * _movementSpeed, _playerRigidbody.velocity.y);


        if( Input.GetKeyDown(KeyCode.Space) && _canJump || Input.GetKeyDown(KeyCode.Space) && _remainingJumps == 1 )
        {
            _playerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _remainingJumps--;
        }
    }


    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("ground"))
        {
            _canJump = true;
            _remainingJumps = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("ground"))
        {
            _canJump = false;
        }
    }

    void flipCharacter(float horizontal)
    {
        if(horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
