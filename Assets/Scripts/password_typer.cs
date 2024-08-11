using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class password_typer : MonoBehaviour
{
    public bool contacted = false;
    public int password;
    [SerializeField] GameObject keypadUI;
    [SerializeField] GameObject keypadmanager_obj;
    [SerializeField] GameObject door_leftover;
    [SerializeField] AudioSource correct_SFX;
    [SerializeField] AudioSource door_open_SFX;
    private keypadmanager keypadmanager;
    private bool active_once = false;
    void Start()
    {
        // keypadUI = GameObject.FindWithTag("keypadUI"); // 그냥 끌어다 놓기로.
        keypadmanager = keypadmanager_obj.GetComponent<keypadmanager>(); 
        keypadmanager.password = password;
    }

    
    void Update()
    {
        if (contacted){
            if (Input.GetKeyDown(KeyCode.E) && !keypadUI.activeSelf){
                keypadUI.SetActive(true);
            }
            else if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape)) && keypadUI.activeSelf){
                keypadUI.SetActive(false);
            }
        }

        if (keypadmanager_obj.GetComponent<Text>().text == "Success" && !active_once){
            Debug.Log("qwd");
            active_once = true;
            transform.parent.GetComponent<Animator>().SetFloat("multiplier", 1);
            correct_SFX.Play();
            door_open_SFX.Play();
        }

        if (transform.parent.GetComponent<SpriteRenderer>().sprite.name == "door1_Frame_8"){
            transform.parent.GetComponent<Animator>().SetFloat("multiplier", 0);
            transform.parent.GetComponent<BoxCollider2D>().isTrigger = true; // 지나갈 수 있게.
            door_leftover.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            contacted = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            contacted = false;
        }
    }
}
