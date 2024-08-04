using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class big_door : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] AudioSource keycardTaggedSFX;
    [SerializeField] bool contacted = false;
    private item_selection item_Selection;
    private inventory inventory;

    [SerializeField] GameObject onoff_LED;
    [SerializeField] GameObject greenKeyCard_verify;
    [SerializeField] GameObject yellowKeyCard_verify;
    [SerializeField] Sprite tagged_img;

    
    private bool greencard;
    private bool yellowcard;
    public bool powered;
    private bool doorOpenSFX_played = false;

    private game_manager gm;
    void Start()
    {
        anim = GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<game_manager>();
        anim.SetFloat("animSpeed", 0f);

        inventory = GameObject.FindWithTag("Inventory").GetComponent<inventory>();
        item_Selection = GameObject.Find("Selection").GetComponent<item_selection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (contacted){
            if (Input.GetKeyDown(KeyCode.E)){
                if (powered){
                    if (inventory.GetItemName(item_Selection.slotNumber) == "Green Keycard"){
                        if (!greencard){
                            greencard = true;
                            Debug.Log("Green Keycard tagged.");

                            // sound
                            keycardTaggedSFX.Play();

                            // img
                            greenKeyCard_verify.GetComponent<SpriteRenderer>().sprite = tagged_img;
                        }
                        else{
                            Debug.Log("You already tagged green keycard.");
                            // notice sound
                        }
                    }
                    else if (inventory.GetItemName(item_Selection.slotNumber) == "Yellow Keycard"){
                        if (!yellowcard){
                            yellowcard = true;
                            Debug.Log("Yellow Keycard tagged.");

                            // sound
                            keycardTaggedSFX.Play();

                            // img
                            yellowKeyCard_verify.GetComponent<SpriteRenderer>().sprite = tagged_img;
                        }
                        else{
                            Debug.Log("You already tagged yellow keycard.");
                            // notice sound
                        }
                    }
                    else{
                        Debug.Log("Need to tag both green and yellow keycards to open the door.");
                        // error sound
                    }
                }
                else{
                    Debug.Log("Need Power Supply.");
                    // error sound
                }
            }
        }

        if (greencard && yellowcard && powered){
            anim.SetFloat("animSpeed", 1f);
            if (!doorOpenSFX_played){
                doorOpenSFX_played = true;

                gm.doorOpenSFX.time = 0.3f;
                gm.doorOpenSFX.Play();
                gm.PlaydoorSoundCut();
            }
        }

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f){
            Destroy(gameObject);
        }

        if (powered){
            onoff_LED.GetComponent<Light2D>().color = Color.green;
        }
    }

    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"){
            contacted = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Player"){
            contacted = false;
        }
    }
}
