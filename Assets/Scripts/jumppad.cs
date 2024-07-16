using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class jumppad : MonoBehaviour
{
    [SerializeField] float springPower;
    [SerializeField] float animateTime;
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer spriteRenderer;

    IEnumerator Animate(){
        for(int i = 0; i < sprites.Length - 1; i++){
            spriteRenderer.sprite = sprites[i + 1];
            yield return new WaitForSeconds(animateTime / sprites.Length);
        }
        spriteRenderer.sprite = sprites[0];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball"){
            Rigidbody2D ballRb = other.GetComponent<Rigidbody2D>();
            ballRb.velocity = new Vector3(ballRb.velocity.x, springPower, 0f);

            StartCoroutine(Animate());
        }
    }
}
