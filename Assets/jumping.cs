using UnityEngine;
public class jumping : MonoBehaviour
{
    [Header("For Patrolling")]
    [SerializeField] float moveSpeed;
    
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float circleRadius;
    public bool checkingGround;
    private bool checkingWall;

    [Header("For JumpAttacking")]
    [SerializeField] float jumpHeight;
    [SerializeField] Transform player;
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 boxSize;
    public bool isGrounded;

    [Header("For SeeingPlayer")]
    [SerializeField] Vector2 lineOfSite;
    [SerializeField] LayerMask playerLayer;
    private bool canSeePlayer;
    [Header("Other")]
    private Animator enemyAnim;
    private Rigidbody2D enemyRB;
    public Transform target;
        public GameObject[] targets;
    public bool finalTarget;
    public GameObject final;
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        targets = GameObject.FindGameObjectsWithTag("target");

        foreach (GameObject tempTarget in targets)
        {
            if (tempTarget.GetComponent<JumpedOver>().nextTarget)
            {
                target = tempTarget.transform;
            }
        }
    }


    void FixedUpdate()
    {
        if (enemyRB.velocity.x>0)
        {
            enemyAnim.SetBool("running", true);
        }
        if (enemyRB.velocity.x == 0)
        {
            enemyAnim.SetBool("running", false);
        }
        if (!finalTarget)
        {
            checkingGround = Physics2D.OverlapCircle(groundCheckPoint.position, circleRadius, groundLayer);

            isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
            targets = GameObject.FindGameObjectsWithTag("target");

            foreach (GameObject tempTarget in targets)
            {
                if (tempTarget.GetComponent<JumpedOver>().nextTarget)
                {
                    target = tempTarget.transform;
                }
            }
        }
        if (finalTarget)
        {
            target = final.transform;
        }
       
        Patrolling();
        Jump();

        


    }

    void Patrolling()
    {
        if (isGrounded&&checkingGround&&!finalTarget)
        {
            enemyRB.velocity = new Vector2(moveSpeed, enemyRB.velocity.y);
        }
        
    }

    void Jump()
    {
        if (transform.position.y < -20)
        {
            transform.position = final.transform.position;
        }
        float distanceFromGround = target.position.x - transform.position.x;

        if (isGrounded&&!checkingGround&&!finalTarget)
        {
            enemyRB.velocity = new Vector2(1, enemyRB.velocity.y);
            enemyRB.AddForce(new Vector2(distanceFromGround, jumpHeight), ForceMode2D.Impulse);
        }
        if (finalTarget)
        {
            transform.position = transform.position + new Vector3(1, 1, 0)*30*Time.deltaTime;
            if (transform.position.y > 30)
            {
                transform.position = final.transform.position;
            }


            if (gameObject.transform.position == final.transform.position)
            {
                gameObject.GetComponent<runningAway>().enabled = true;
                gameObject.GetComponent<jumping>().enabled = false;
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            finalTarget = true;
        }




    }




}
