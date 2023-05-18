using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 40;
    private Vector3 MousePos;
    private float timer;
    public float delay;
    public int damage = 50;
    public int ZappPower = 100;
    public GameObject idleGun;
    GameObject target;
    Vector3 targetPos;
    float degrees;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target)
        {
            targetPos = target.transform.position;

            rb = GetComponent<Rigidbody2D>();
            Vector3 direction = targetPos - transform.position;
            float rotZ = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.localRotation = transform.localRotation * Quaternion.Euler(0, 0, 10);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
                collision.gameObject.GetComponent<LifeManager>().TakeDamage(50);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {

                        Destroy(gameObject);
        }




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<LifeManager>().TakeDamage(50);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {

            Destroy(gameObject);
        }
    }


}
