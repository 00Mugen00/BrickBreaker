using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField]
    AudioClip breakSound;
    [SerializeField]
    GameObject brickSparklesVFX;
    [SerializeField]
    Sprite[] hitSprites;

    LevelManager levelManager;

    [SerializeField]
    int timesHit;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        if (tag == "Breakable")
        {
            levelManager.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length+1;
            if (timesHit >= maxHits)
            {
                DestroyBrick();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    private void DestroyBrick()
    {
        FindObjectOfType<GameManager>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        levelManager.BrickDestroyed();
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(brickSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles);
    }
}
