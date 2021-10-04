using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public bool IsJumping;
    public float JumpForce;
    public bool DoubleJumping;
    private Animator anim;
    private Rigidbody2D rig;
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!IsJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                DoubleJumping = true;
                audioSource.clip = jumpSound;
                audioSource.Play();
            } else
            {
                if(DoubleJumping)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    DoubleJumping = false;
                    audioSource.clip = jumpSound;
                    audioSource.Play();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") IsJumping = false;

        if (collision.gameObject.tag == "Water")
        {
            audioSource.clip = deathSound;
            audioSource.Play();
            anim.SetBool("death", true);
            //GameController.instance.ShowGameOver();
        }

        if (collision.gameObject.tag == "Platform")
        {
            IsJumping = false;
            gameObject.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") IsJumping = true;

        if (collision.gameObject.tag == "Platform")
        {
            IsJumping = true;
            gameObject.transform.parent = null;
        }
    }
}
