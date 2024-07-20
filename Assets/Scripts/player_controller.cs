using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    private Vector3 spawnpoint;
    private Animator anim;
    private SpriteRenderer sr;
    public float moveInput;
    public float jumppadHoriVel;
    
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float ropeJumpPower;
    public bool is_grounded = false;
    [SerializeField] bool ropeUsed = false;

    IEnumerator RopeJump(){
        if(!ropeUsed){
            ropeUsed = true;
            rb.velocity = new Vector2(rb.velocity.x, 0f);

            for(int i = 0; i < 5; i++){
                rb.AddForce(new Vector2(0, ropeJumpPower), ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.04f);
            }
        }
    }

    void Start()
    {
        spawnpoint = GameObject.FindWithTag("Spawn").transform.position;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        transform.position = spawnpoint;

        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("CheckpointObj");
        foreach(GameObject checkpoint in checkpoints){ // 가장 최근에 활성화한 체크포인트에 플레이어를 소환.
            if (checkpoint.GetComponent<checkpoint_controller>().recently_touched){
                transform.position = checkpoint.transform.position + new Vector3(0, 1f, 0);
            }
        }
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Debug.Log(moveInput);

        rb.velocity = new Vector2(moveInput * moveSpeed + jumppadHoriVel, rb.velocity.y);

        if(is_grounded && Mathf.Abs(moveInput) > 0){ //Walk Animation
            anim.SetBool("isWalk", true);
        }
        else{
            anim.SetBool("isWalk", false);
        }

        if(moveInput > 0){ //Flip
            sr.flipX = false;
        }
        else if(moveInput < 0){
            sr.flipX = true;
        }

        if (Input.GetKey(KeyCode.Space) && is_grounded){
            anim.SetBool("isJump", true);
            anim.SetBool("isLand", false);
            is_grounded = false;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if(!is_grounded && rb.velocity.y < 0){
            anim.SetBool("isJump", false);
            anim.SetBool("isFalling", true);
        }

    }

    void Update()
    {
        Debug.DrawRay(rb.position + new Vector2(0.25f, 0.7f), Vector3.down * 0.7f, new Color(1, 0, 0));

        RaycastHit2D hit = Physics2D.Raycast(rb.position + new Vector2(0.25f, 0.7f), Vector3.down, 0.7f, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isFalling", false);
            anim.SetBool("isLand", true);
            is_grounded = true;
            ropeUsed = false;
        }


        if (Input.GetKeyDown(KeyCode.C)){
            StartCoroutine(RopeJump());
        }
    }
}
