using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic : MonoBehaviour
{
    public float life = 10;
    public int exppoint = 300;
    private bool isObstacle;
    private bool isPlayerInCircle;
    private bool facingRight = true;

    private Transform playerCheck;
    public GameObject bullet;
    private Rigidbody2D rb;

    public float shootspeed = 5f;
    float shootCheck;
    public bool isHitted = false;

    public Transform player;
    

    void Awake() {
        playerCheck = transform.Find("PlayerCheck");
        rb = GetComponent<Rigidbody2D>();
        shootCheck = shootspeed;
    }

    void FixedUpdate() {
        if(life <= 0) {
            transform.GetComponent<Animator>().SetBool("IsDead",true);
            StartCoroutine(DestroyEnemy());
        }
        isPlayerInCircle = Physics2D.OverlapCircle(playerCheck.position, 3f);
        
        if(player.position.x < transform.position.x){
            transform.localScale = new Vector3(-1,1,1);
        } else {
            transform.localScale = new Vector3(1,1,1);
        }
        
        if(!isHitted && life > 0)
        {
            if(shootCheck < 0)
            {
                shootCheck = shootspeed;
                Shoot();
            }
            shootCheck -= Time.deltaTime;
        }
    }
    
    void Shoot()
    {
        transform.GetComponent<Animator>().SetBool("isShoot",true);
        GameObject b = Instantiate(bullet, transform.position + new Vector3(transform.localScale.x * 0.5f,-0.2f),Quaternion.identity) as GameObject;
        Destroy(b,3f);
        Vector2 direction = new Vector2(transform.localScale.x,0);
        b.GetComponent<ThrowableProjectile>().direction = direction;
        if(transform.localScale.x < 0) b.GetComponent<SpriteRenderer>().flipX = true;
        b.name = "bullet";
    }

    public void ApplyDamage(float damage) {
        float direction = damage / Mathf.Abs(damage);
        damage = Mathf.Abs(damage);
        transform.GetComponent<Animator>().SetBool("Hit", true);
        life -= damage;
        // rb.velocity = Vector2.zero;
        // rb.AddForce(new Vector2(direction * 500f, 100f));
        StartCoroutine(HitTime());
    }

    void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && life > 0)
		{
			collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(2f, transform.position);
		}
	}

    IEnumerator HitTime()
	{
		isHitted = true;
		yield return new WaitForSeconds(0.1f);
		isHitted = false;
	}

    IEnumerator DestroyEnemy()
	{
		//exppoint gain
		GameManager.instance.Expcontrol(exppoint);
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}

}
