using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public float gravityModifier = 5f;
    public float jumpForce = 10f;
    private bool isOnGround = true;
    private bool doubleJump = false;
    private Rigidbody playerRb;
    private Animator playerAnim;
    public bool isGameOver = false;
    public bool isGameStarted = true;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    public float dashTimes = 1;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // playerAnim.Play("Walk");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                isOnGround = false;
                doubleJump = true;
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound);
                Invoke("ResetDoubleJump", 0.3f);
            }
            else if (doubleJump)
            {
                doubleJump = false;
                playerRb.AddForce(Vector3.up * jumpForce / 2, ForceMode.Impulse);
                playerAnim.SetTrigger("Jump_trig");
                playerAudio.PlayOneShot(jumpSound);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dashTimes = 2;
            Invoke("ResetDashTimes", 0.3f);
        }
    }

    void ResetDoubleJump()
    {
        doubleJump = false;
    }

    void ResetDashTimes()
    {
        dashTimes = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag("Ground"))
        {
            isOnGround = true;
            doubleJump = false;
            dirtParticle.Play();
        }
        else if (obj.CompareTag("Obstacle"))
        {
            isGameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
