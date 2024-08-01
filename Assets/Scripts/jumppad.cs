using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.Callbacks;
using UnityEngine;

public class jumppad : MonoBehaviour
{
    [SerializeField] string direction; // 대문자로
    [SerializeField] float springPower;
    [SerializeField] float animateTime;
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] player_controller player_Controller;
    [SerializeField] Rigidbody2D playerRb;

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

    IEnumerator SpringPowerControl(int direction){ // direction: 1 = E, 2 = W

        float equalDivide = 3.5f;
        float initialSpringpower = springPower / equalDivide;

        playerRb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);

        if (direction == 1){ // E
            player_Controller.jumppadHoriVel += springPower / equalDivide;
            for(int i = 0; i < 5; i++){
                player_Controller.jumppadHoriVel -= initialSpringpower / 5;
                yield return new WaitForSeconds(0.04f);
            }
        }
        else if (direction == 2){ // W
            player_Controller.jumppadHoriVel += -springPower / equalDivide;
            for(int i = 0; i < 5; i++){
                player_Controller.jumppadHoriVel += initialSpringpower / 5;
                yield return new WaitForSeconds(0.04f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            player_Controller.ropeUsed = false;
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
            
            player_Controller.is_grounded = true; // 스프링으로 점프했을 때도 땅 밟은 판정으로.

            if (direction == "N"){
                playerRb.velocity = new Vector3(playerRb.velocity.x, springPower, 0f);
            }
            else if (direction == "S"){
                playerRb.velocity = new Vector3(playerRb.velocity.x, -springPower, 0f);
            }
            else if (direction == "E"){
                StopCoroutine(SpringPowerControl(1));
                StartCoroutine(SpringPowerControl(1));
            }
            else if (direction == "W"){
                StopCoroutine(SpringPowerControl(2));
                StartCoroutine(SpringPowerControl(2));
            }
            

            StartCoroutine(Animate());
        }
    }

    void Update()
    {
        if (player_Controller == null || playerRb == null){
            player_Controller = GameObject.FindWithTag("Player").GetComponent<player_controller>();
            playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        }
    }
}
