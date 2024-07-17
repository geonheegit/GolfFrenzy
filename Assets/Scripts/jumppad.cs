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

    void Start()
    {
        player_Controller = GameObject.FindWithTag("Player").GetComponent<player_controller>();
    }

    IEnumerator Animate(){
        for(int i = 0; i < sprites.Length - 1; i++){
            spriteRenderer.sprite = sprites[i + 1];
            yield return new WaitForSeconds(animateTime / sprites.Length);
        }
        spriteRenderer.sprite = sprites[0];
    }

    // IEnumerator SpringHoriVelCalc(float power, float decayTime){
    //     int smooth = 4;
    //     for(int i = 0; i < decayTime * smooth; i++){
    //         player_Controller.jumppadHoriVel = -(power - (power * (i / decayTime * smooth))) / 2;
    //         yield return new WaitForSeconds(1 / (decayTime * smooth));
    //         Debug.Log((power - (power * (i / decayTime * smooth))) / 2);
    //         Debug.Log("qq: " + player_Controller.jumppadHoriVel);
    //     }
    // }

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
                // StopCoroutine(SpringHoriVelCalc(springPower, 1f));
                // StartCoroutine(SpringHoriVelCalc(springPower, 1f));
            }
            else if (direction == "W"){
                // StopCoroutine(SpringHoriVelCalc(-springPower, 1f));
                // StartCoroutine(SpringHoriVelCalc(-springPower, 1f));
            }
            

            StartCoroutine(Animate());
        }
    }
}
