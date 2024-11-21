using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] public int damageDealt;

    [SerializeField] private float speed;

    private Transform target;
    private SpriteRenderer spriteRenderer;
    private Knockback knockback;
    private Rigidbody2D rb;
    private Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        knockback = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDir = direction;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDir.x, moveDir.y) * speed;
        }

        if (knockback.GettingKnockedBack) { return; }

        AdjustPlayerFacingDirection();
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 playerPos = target.position;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (playerPos.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
