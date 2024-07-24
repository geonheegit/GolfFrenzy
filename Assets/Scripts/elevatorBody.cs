using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorBody : MonoBehaviour
{
    private elevator_lever up_elevator_Lever;
    private elevator_lever down_elevator_Lever;
    private GameObject player;
    public bool is_upward_on;
    public bool is_downward_on;
    public bool upward_available;
    public bool downward_available;
    public float elevator_speed;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        up_elevator_Lever = GameObject.Find("EV1_lever_up").GetComponent<elevator_lever>();
        down_elevator_Lever = GameObject.Find("EV1_lever_down").GetComponent<elevator_lever>();
        is_upward_on = false;
        is_downward_on = false;
        upward_available = true;
        downward_available = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_upward_on){
            transform.position += new Vector3(0, elevator_speed / 100, 0);
            player.transform.position += new Vector3(0, elevator_speed / 100, 0);
        }
        else if (is_downward_on){
            transform.position += new Vector3(0, -elevator_speed / 100, 0);
            player.transform.position += new Vector3(0, -elevator_speed / 100, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "uptrigger_EV1" && is_upward_on){ // 올라가고 있는 도중에 트리거랑 만나면
            is_upward_on = false;
            is_downward_on = false;
            upward_available = false;
            downward_available = true;
            
            up_elevator_Lever.spriteRenderer.sprite = up_elevator_Lever.lever_sprites[0]; // up lever off
            down_elevator_Lever.spriteRenderer.sprite = down_elevator_Lever.lever_sprites[0]; // down lever off
        }
        else if (other.gameObject.name == "downtrigger_EV1" && is_downward_on){ // 내려가고 있는 도중에 트리거랑 만나면
            is_upward_on = false;
            is_downward_on = false;
            downward_available = false;
            upward_available = true;

            up_elevator_Lever.spriteRenderer.sprite = up_elevator_Lever.lever_sprites[0]; // up lever off
            down_elevator_Lever.spriteRenderer.sprite = down_elevator_Lever.lever_sprites[0]; // down lever off
        }
        else if (other.gameObject.name == "startTrigger_upward_EV1" && is_upward_on){ // 올라가고 있는 도중에 시작 트리거랑 만나면
            is_upward_on = false;
            is_downward_on = false;
            upward_available = true;
            downward_available = true;

            up_elevator_Lever.spriteRenderer.sprite = up_elevator_Lever.lever_sprites[0]; // up lever off
            down_elevator_Lever.spriteRenderer.sprite = down_elevator_Lever.lever_sprites[0]; // down lever off
        }
        else if (other.gameObject.name == "startTrigger_downward_EV1" && is_downward_on){ // 내려가고 있는 도중에 시작 트리거랑 만나면
            is_upward_on = false;
            is_downward_on = false;
            upward_available = true;
            downward_available = true;

            up_elevator_Lever.spriteRenderer.sprite = up_elevator_Lever.lever_sprites[0]; // up lever off
            down_elevator_Lever.spriteRenderer.sprite = down_elevator_Lever.lever_sprites[0]; // down lever off
        }
    }
}
