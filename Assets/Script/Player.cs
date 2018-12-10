using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum Type
    {
        EXACT,
        INERTIE,
        VELOCITY

    }
    private Rigidbody2D rigidbody2D;

    [SerializeField] private float playerSpeed;

    [SerializeField] private bool type;

    [SerializeField] private float maxSpeed;
    [SerializeField] private float decreasevalue;

    [SerializeField] private int life;

    [SerializeField] private float hitCooldown;
    [SerializeField] private Type currentType;

    [SerializeField] private Sprite playerIdle;
    [SerializeField] private Sprite playerLeft;
    [SerializeField] private Sprite playerRight;
    [SerializeField] private Sprite playerUp;
    [SerializeField] private Sprite playerDown;


    private Animator animator;

    private AudioSource audioSource;
	// Use this for initialization
	void Start ()
	{
	    animator = GetComponent<Animator>();
	    rigidbody2D = GetComponent<Rigidbody2D>();
	    audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (currentType == Type.EXACT)
	    {
	        float v = Input.GetAxis("Vertical");
	        Vector2 myVelocityY = Vector2.up;
	        myVelocityY *= v * playerSpeed;
	        float h = Input.GetAxis("Horizontal");
	        Vector2 myVelocityX = Vector2.right;
	        myVelocityX *= h * playerSpeed;
	        rigidbody2D.velocity = myVelocityX + myVelocityY;
	    }
	    if (currentType == Type.INERTIE)
        {
	        float v = Input.GetAxis("Vertical");
            if (v * rigidbody2D.velocity.y < maxSpeed)
	        {
	            rigidbody2D.AddForce(Vector2.up * v * playerSpeed);
	        }
	        float h = Input.GetAxis("Horizontal");
	        if (h * rigidbody2D.velocity.x < maxSpeed)
	        {
	            rigidbody2D.AddForce(Vector2.right * h * playerSpeed);
	        }
            if (Mathf.Abs(rigidbody2D.velocity.y) > maxSpeed)
	        {
	            rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, Mathf.Sign(rigidbody2D.velocity.y) * maxSpeed);
	        }

            if (Mathf.Abs(rigidbody2D.velocity.y) > maxSpeed)
            {
                while (rigidbody2D.velocity.y > 0.001 || rigidbody2D.velocity.y > 0.001 ||
                       rigidbody2D.velocity.y > 0.001 || rigidbody2D.velocity.y > 0.001)
                {
                    float xdecrease = 0;
                    float ydecrease = 0;
                    if (rigidbody2D.velocity.x > 0)
                    {
                        xdecrease = -decreasevalue;
                    }
                    else
                    {
                        xdecrease = +decreasevalue;
                    }

                    if (rigidbody2D.velocity.y > 0)
                    {
                        ydecrease = -decreasevalue;
                    }
                    else
                    {
                        ydecrease = +decreasevalue;
                    }

                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + xdecrease,
                        rigidbody2D.velocity.y + ydecrease);
                }
            }

        }
	    if (currentType == Type.VELOCITY)
	    {
	        float v = Input.GetAxis("Vertical");
	        Vector2 myVelocityY = Vector2.up;
	        myVelocityY *= v * playerSpeed;
	        float h = Input.GetAxis("Horizontal");
	        Vector2 myVelocityX = Vector2.right;
	        myVelocityX *= h * playerSpeed;
	        rigidbody2D.velocity += myVelocityX + myVelocityY;
        }

	    if (Input.GetAxis("Vertical") > 0)
	    {
	        GetComponentInChildren<SpriteRenderer>().sprite = playerUp;
	    } else if (Input.GetAxis("Vertical") < 0)
	    {
            GetComponentInChildren<SpriteRenderer>().sprite = playerDown;
	    }
	    else if (Input.GetAxis("Horizontal") > 0)
	    {
            GetComponentInChildren<SpriteRenderer>().sprite = playerRight;
	    }
	    else if (Input.GetAxis("Horizontal") < 0)
	    {
            GetComponentInChildren<SpriteRenderer>().sprite = playerLeft;
	    }
	    else
	    {
            GetComponentInChildren<SpriteRenderer>().sprite = playerIdle;
	    }
    }

    public void Hit(int damage, AudioClip audio)
    {
        if (!animator.GetBool("HitCooldown"))
        {
            life -= damage;
            GameManager.Instance.SetUILife(life);
            audioSource.PlayOneShot(audio);
            if (life <= 0)
            {
                animator.SetTrigger("Death");
                GlobalGameManager.Instance.Death();
            }
            else
            {
                StartCoroutine(Animation("HitCooldown", hitCooldown));
            }
        }
    }

    IEnumerator Animation(string animName, float time)
    {
        animator.SetBool(animName, true);
        yield return new WaitForSecondsRealtime(time);
        animator.SetBool(animName, false);
    }
}
