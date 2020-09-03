#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // config params
    [SerializeField] private AudioClip breakSound = null;
    [SerializeField] private GameObject blockSparklesVFX;
    [SerializeField] private Sprite[] hitSprites;
    GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private int currentHP;
    // state variables
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = hitSprites.Length;
        SetSprite(currentHP);

        // Initialize Game Manager:
        gameManager = FindObjectOfType<GameManager>();

    }

    private void Start()
    {
        gameManager.addBlock();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball == null) return;
        HandleHit();
  
    }

    private void HandleHit()
    {
        currentHP--;
        if (currentHP <= 0)
        {
            DestroyBlock();
            gameManager.blockDestroyed();
        }
        else
        {
            SetSprite(currentHP);
        }
    }

    private void SetSprite(int health)
    {
        spriteRenderer.sprite = hitSprites[health - 1];
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        TriggerSparklesVFX();
        Destroy(gameObject);
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
