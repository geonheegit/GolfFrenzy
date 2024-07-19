using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class jumppad : MonoBehaviour
{
    [SerializeField] string direction; // 대문자로
    [SerializeField] float springPower;
    [SerializeField] float animateTime;
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer spriteRenderer;
    private player_controller player_Controller;
    private Rigidbody2D playerRb;

    void Start()
    {
        player_Controller = GameObject.FindWithTag("Player").GetComponent<player_controller>();
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    IEnumerator Animate(){
        for(int i = 0; i < sprites.Length - 1; i++){
            spriteRenderer.sprite = sprites[i + 1];
            yield return new WaitForSeconds(animateTime / sprites.Length);
        }
        spriteRenderer.sprite = sprites[0];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            

            if (direction == "N"){
                playerRb.velocity = new Vector3(playerRb.velocity.x, springPower, 0f);
            }
            else if (direction == "S"){
                playerRb.velocity = new Vector3(playerRb.velocity.x, -springPower, 0f);
            }
            else if (direction == "E"){
                playerRb.AddForce(new Vector2(springPower, 0), ForceMode2D.Impulse);
            }
            else if (direction == "W"){
                playerRb.AddForce(new Vector2(-springPower, 0), ForceMode2D.Impulse);
            }
            

            StartCoroutine(Animate());
        }
    }
}
