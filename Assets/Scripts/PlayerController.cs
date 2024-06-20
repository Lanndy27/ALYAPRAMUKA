using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public static UnityAction OnDeath;

    private bool isMoving;

    private Vector2 input;

    private Animator animator;

    public LayerMask solidObjectsLayer;

    public bool movbuff;

    public float buffduration = 5;

    private float currentbufftime;

    public SpriteRenderer spriteRenderer;

    AudioManager audioManager;
    private bool isWalkingAudioPlaying = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        // Ensure Rigidbody2D settings
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void Update()
    {
        if (DialogueManager.Instance.isDialogueActive)
        {
            animator.speed = 0;
            isMoving = false;
            StopFootstepAudio();
            rb.velocity = Vector2.zero;
            return; 
        }
        else
        {
            animator.speed = 1;
        }
        if (movbuff)
        {
            currentbufftime += Time.deltaTime;
            if (currentbufftime > buffduration)
            {
                movbuff = false;
                currentbufftime = 0;
                moveSpeed = 4;
            }
        }

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        Debug.Log("This is input.x" + input.x);
        Debug.Log("This is input.y" + input.y);

        if (input != Vector2.zero)
        {
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);

            var targetVelocity = input.normalized * moveSpeed;
            rb.velocity = targetVelocity;

            if (!isWalkingAudioPlaying)
            {
                PlayFootstepAudio();
            }

            if (input.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (input.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            StopFootstepAudio();
            rb.velocity = Vector2.zero;
        }
        
        animator.SetBool("isMoving", input != Vector2.zero);
    }

    private void PlayFootstepAudio()
    {
        audioManager.PlayLoopedSFX(audioManager.playerWalk);
        isWalkingAudioPlaying = true;
    }

    private void StopFootstepAudio()
    {
        audioManager.StopLoopedSFX();
        isWalkingAudioPlaying = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnDeath?.Invoke();
        }
        if (other.CompareTag("HardDetak"))
        {
            audioManager.PlayDetakHardSFX(audioManager.detakHard);
            audioManager.StopDetakSFX();
        }
        if (other.CompareTag("Tuyul"))
        {
            audioManager.PlayTuyulSFX(audioManager.tuyul);
            audioManager.PlayDetakHardSFX(audioManager.detakHard);
        }
        if (other.CompareTag("Pocong"))
        {
            audioManager.PlayPocongSFX(audioManager.pocong);
            audioManager.PlayDetakSFX(audioManager.detak);
        }
        if (other.CompareTag("Kunti"))
        {
            audioManager.PlayKuntiSFX(audioManager.kunti);
            audioManager.PlayDetakSFX(audioManager.detak);
        }
        if (other.CompareTag("Boss"))
        {
            audioManager.PlayBossSFX(audioManager.boss);
            audioManager.PlayDetakSFX(audioManager.detak);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HardDetak"))
        {
            audioManager.StopDetakHardSFX();
            ResumeAppropriateSFX();
        }
        if (other.CompareTag("Tuyul"))
        {
            audioManager.StopTuyulSFX();
            audioManager.StopDetakHardSFX();
        }
        if (other.CompareTag("Pocong"))
        {
            audioManager.StopPocongSFX();
            audioManager.StopDetakSFX();
        }
        if (other.CompareTag("Kunti"))
        {
            audioManager.StopKuntiSFX();
            audioManager.StopDetakSFX();
        }
        if (other.CompareTag("Boss"))
        {
            audioManager.StopBossSFX();
            audioManager.StopDetakSFX();
        }
    }

    private void ResumeAppropriateSFX()
    {
        // Check if still in any of the large colliders to resume audio
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("Pocong"))
            {
                audioManager.PlayPocongSFX(audioManager.pocong);
                audioManager.PlayDetakSFX(audioManager.detak);
                return;
            }
            if (col.CompareTag("Kunti"))
            {
                audioManager.PlayKuntiSFX(audioManager.kunti);
                audioManager.PlayDetakSFX(audioManager.detak);
                return;
            }
            if (col.CompareTag("Boss"))
            {
                audioManager.PlayBossSFX(audioManager.boss);
                audioManager.PlayDetakSFX(audioManager.detak);
                return;
            }
        }
    }
}
