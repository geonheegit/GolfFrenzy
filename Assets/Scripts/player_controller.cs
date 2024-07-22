using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    private Vector3 spawnpoint;
    private Animator anim;
    private SpriteRenderer sr;
    private BoxCollider2D boxCollider2D;
    private LineRenderer lineRenderer;
    public float moveInput;
    public float jumppadHoriVel;
    public float lineLength;
    
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject ropeEndObj;
    [SerializeField] float moveSpeed;

    [SerializeField] float jumpPower;
    [SerializeField] float ropeJumpPower;
    public bool is_grounded = false;
    public bool ropeUsed = false;

    private Vector2 normalColliderOffset;
    private float colliderXOffset = 0.15f;

    IEnumerator RopeJump(){
        if(!ropeUsed){
            ropeUsed = true;
            rb.velocity = new Vector2(rb.velocity.x, 0f);

            for(int i = 0; i < 5; i++){
                rb.AddForce(new Vector2(0, ropeJumpPower), ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.04f);
                
            }
            anim.SetBool("isSpin", false);
        }
    }

    void Start()
    {
        spawnpoint = GameObject.FindWithTag("Spawn").transform.position;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.sortingOrder = 101;
        transform.position = spawnpoint;

        // linerenderer settings
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;

        // store original vector2 value before character flips.
        normalColliderOffset = new Vector2(boxCollider2D.offset.x, boxCollider2D.offset.y);

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

        rb.velocity = new Vector2(moveInput * moveSpeed + jumppadHoriVel, rb.velocity.y);

        if(is_grounded && Mathf.Abs(moveInput) > 0){ //Walk Animation
            anim.SetBool("isWalk", true);
        }
        else{
            anim.SetBool("isWalk", false);
        }

        if(moveInput > 0){ //Flip
            sr.flipX = false;
            boxCollider2D.offset = normalColliderOffset;
        }
        else if(moveInput < 0){
            sr.flipX = true;
            boxCollider2D.offset = new Vector2(normalColliderOffset.x - colliderXOffset, normalColliderOffset.y);
            
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
        else
        {
            anim.SetBool("isFalling", false);
        }

    }

    void Update()
    {
        float rayOffset = 0.4f;
        float leftRayPosX = -0.25f;
        float rightRayPosX = 0.65f;
        RaycastHit2D hitLeft;
        RaycastHit2D hitRight;
        if (!sr.flipX){
            hitLeft = Physics2D.Raycast(rb.position + new Vector2(leftRayPosX, 0.7f), Vector3.down, 0.7f, LayerMask.GetMask("Ground"));
            Debug.DrawRay(rb.position + new Vector2(leftRayPosX, 0.7f), Vector3.down * 0.7f, new Color(1, 0, 0));
            hitRight = Physics2D.Raycast(rb.position + new Vector2(rightRayPosX, 0.7f), Vector3.down, 0.7f, LayerMask.GetMask("Ground"));
            Debug.DrawRay(rb.position + new Vector2(rightRayPosX, 0.7f), Vector3.down * 0.7f, new Color(0, 1, 0));
        }
        else{
            hitLeft = Physics2D.Raycast(rb.position + new Vector2(leftRayPosX - rayOffset, 0.7f), Vector3.down, 0.7f, LayerMask.GetMask("Ground"));
            Debug.DrawRay(rb.position + new Vector2(leftRayPosX - rayOffset, 0.7f), Vector3.down * 0.7f, new Color(1, 0, 0));
            hitRight = Physics2D.Raycast(rb.position + new Vector2(rightRayPosX - rayOffset, 0.7f), Vector3.down, 0.7f, LayerMask.GetMask("Ground"));
            Debug.DrawRay(rb.position + new Vector2(rightRayPosX - rayOffset, 0.7f), Vector3.down * 0.7f, new Color(0, 1, 0));
        }
        
        if (hitLeft.collider != null || hitRight.collider != null)
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isLand", true);
            is_grounded = true;
            ropeUsed = false;
            
        }


        if (!is_grounded && Input.GetKeyDown(KeyCode.LeftShift)){
            anim.SetBool("isSpin", true);
            StartCoroutine(RopeJump());

            // 와이어 연결 코드
            
            GameObject ropeEndPoint = Instantiate(ropeEndObj);
            ropeEndPoint.transform.position = transform.position + new Vector3(0, lineLength, -0.5f);
            lineRenderer.SetPosition(0, new Vector3(ropeEndPoint.transform.position.x, ropeEndPoint.transform.position.y + 2f, -0.5f));
        }

        // 와이어 연결 코드
        if (!is_grounded && ropeUsed && rb.velocity.y > 10f){
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y + 1.5f, -0.5f));
        }
        else{
            lineRenderer.enabled = false;
            Destroy(GameObject.FindWithTag("RopeEndPoint"));
        }

    }
}
