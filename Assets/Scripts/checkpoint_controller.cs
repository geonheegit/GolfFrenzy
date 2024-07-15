using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class checkpoint_controller : MonoBehaviour
{
    private Vector3 checkpoint;
    private SpriteRenderer spriteRenderer;
    private GameObject ball;
    private Rigidbody2D ballrb;
    public bool touched = false;
    public bool recently_touched = false;
    void Start()
    {
        transform.position = transform.parent.position; // 부모의 위치에 자신의 위치를 맞춤. (부모는 game_manager.cs에서의 체크포인트 지점들.)
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        checkpoint = transform.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Ball" && !touched){ // 현재 공이 닿은 체크포인트를 제외한 다른 체크포인트의 recently_touched를 false로.
            GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("CheckpointObj");
            foreach (GameObject checkpoint in checkpoints){
                checkpoint.GetComponent<checkpoint_controller>().recently_touched = false;
            }

            touched = true; // 이미 사용한 체크포인트 색깔 노란색으로 바꾸기 & 다시 터치하는거 방지.
            recently_touched = true; // 현재 체크포인트만 recently_touched를 true. (재시작시 제일 최근 체크포인트로 가는 용도; game_manager.cs에서 활용)

            ball = GameObject.FindWithTag("Ball");
            ballrb = ball.GetComponent<Rigidbody2D>();
            ball.transform.position = checkpoint + new Vector3(0, 1f, 0);
            ballrb.velocity = new Vector3(0, 0, 0);

            spriteRenderer.color = Color.yellow;
        }
    }

    void Update()
    {
        
    }
}
