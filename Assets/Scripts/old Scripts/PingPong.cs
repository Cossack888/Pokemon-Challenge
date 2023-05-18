using UnityEngine;
using System.Collections;

public class PingPong : MonoBehaviour
{
    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove = 5;
    public float EnemySpeed = 500;
    public bool _isFacingRight;
    private float _startPos;
    private float _endPos;
    public Animator anim;
    public bool _moveRight = true;


    // Use this for initialization
    public void Awake()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position.x;
        _endPos = _startPos + UnitsToMove;
        _isFacingRight = transform.localScale.x > 0;
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    public void FixedUpdate()
    {
        anim.SetFloat("Speed", Mathf.Abs(enemyRigidBody2D.velocity.x));
        if (_moveRight)
        {
           // enemyRigidBody2D.AddForce(Vector2.right * EnemySpeed * Time.deltaTime);

            enemyRigidBody2D.velocity = new Vector2(1, 0) * EnemySpeed * Time.deltaTime;
           
             
        }

        if (enemyRigidBody2D.position.x >= _endPos)
            _moveRight = false;

        if (!_moveRight)
        {
            enemyRigidBody2D.velocity = new Vector2(-1, 0) * EnemySpeed * Time.deltaTime;
            
               
        }
        if (enemyRigidBody2D.position.x <= _startPos)
            _moveRight = true;


    }

    

}