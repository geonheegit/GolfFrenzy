using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator_lever : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject elevatorBody;
    public Sprite[] lever_sprites;
    private elevatorBody elevatorBodyScript;
    public SpriteRenderer spriteRenderer;
    private bool is_touching;
    private bool is_controllable;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        elevatorBody = GameObject.Find("Elevator1");
        elevatorBodyScript = GameObject.Find("Elevator1").GetComponent<elevatorBody>();
        spriteRenderer.sprite = lever_sprites[0];
        is_touching = false;
        is_controllable = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (!elevatorBodyScript.is_upward_on && !elevatorBodyScript.is_downward_on){
            is_controllable = true;
        }
        else{
            is_controllable = false; // 작동 중일 때는 레버조작 불가, 엘베 도착한 뒤 다시 true.
        }

        if (is_touching){
            if(Input.GetKeyDown(KeyCode.E)){
                if(is_controllable){
                    spriteRenderer.sprite = lever_sprites[1]; // turn on

                    if (gameObject.name == "EV1_lever_up" && elevatorBodyScript.upward_available){
                        elevatorBodyScript.is_upward_on = true;
                    }
                    else if (gameObject.name == "EV1_lever_down" && elevatorBodyScript.downward_available){
                        elevatorBodyScript.is_downward_on = true;
                    }

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && is_controllable){
            is_touching = true;

            if (gameObject.name == "EV1_lever_up"){
                GameObject summoned_arrow = Instantiate(arrow);
                summoned_arrow.transform.position = transform.position + new Vector3(0, 2, 0);
            }
            else if (gameObject.name == "EV1_lever_down"){
                GameObject summoned_arrow = Instantiate(arrow);
                summoned_arrow.GetComponent<SpriteRenderer>().flipY = true;
                summoned_arrow.transform.position = transform.position + new Vector3(0, 2, 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player"){
            is_touching = false;
            Destroy(GameObject.FindWithTag("Arrow"));
        }
    }
}
