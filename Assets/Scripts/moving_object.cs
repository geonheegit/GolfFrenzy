using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class moving_object : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float move_time;
    public bool go;
    private bool moveTogether = false;
    private GameObject player;
    public bool horizontal = true;
    public bool left_active = false;
    public bool right_active = false;

    void Start()
    {
        go = true;
        StartCoroutine(Move(move_time));
        player = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        if (horizontal){
            if (go){
                transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            }
            else if (!go){
                transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            }
        }
        else{
            if (go){
                transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
            }
            else if (!go){
                transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
            }
        }
        
        if (moveTogether){
            if (horizontal && go && right_active){
                player.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
            else if (horizontal && !go && left_active){
                player.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            }
            else if (!horizontal && go){
                player.transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
            }
            else if (!horizontal && !go){
                player.transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
            }
        }

    }

    IEnumerator Move(float time){
        yield return new WaitForSeconds(time / 2); // pos2로 가는 시간
        go = false;
        yield return new WaitForSeconds(time / 2); // pos1으로 돌아오는 시간
        go = true;
        StartCoroutine(Move(time));

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"){
            moveTogether = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"){
            moveTogether = false;
        }
    }
}
