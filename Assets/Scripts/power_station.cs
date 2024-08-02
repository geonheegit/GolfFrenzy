using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class power_station : MonoBehaviour
{
    [SerializeField] AudioSource turnOnSFX;
    [SerializeField] AudioSource accessDeniedSFX;
    [SerializeField] bool contacted = false;
    private item_selection item_Selection;
    private inventory inventory;
    private fan_control_tower fan_Control_Tower;

    private Light2D red_LED;
    private Light2D green_LED;
    private Light2D blueLight;

    public bool turnedOn = false;

    void Start()
    {
        inventory = GameObject.FindWithTag("Inventory").GetComponent<inventory>();
        item_Selection = GameObject.Find("Selection").GetComponent<item_selection>();
        fan_Control_Tower = GameObject.FindWithTag("FanControlTower").GetComponent<fan_control_tower>();
        
        red_LED = GameObject.Find("Red_LED_PT").GetComponent<Light2D>();
        green_LED = GameObject.Find("Green_LED_PT").GetComponent<Light2D>();
        blueLight = GameObject.Find("Blue_Light_PT").GetComponent<Light2D>();

        green_LED.intensity = 0;
        blueLight.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (contacted){
            if (Input.GetKeyDown(KeyCode.E)){
                if (!turnedOn){
                    if (inventory.GetItemName(item_Selection.slotNumber) == "Yellow Keycard"){
                        // Debug.Log("On");
                        turnOnSFX.Play();
                        turnedOn = true;

                        // Lights
                        StartCoroutine(StartUpLight(2f));

                        // FanControlTower
                        fan_Control_Tower.powered = true;
                        
                    }
                    else{
                        Debug.Log("Yellow Keycard required.");
                        accessDeniedSFX.Play();
                    }
                }
                else{
                    Debug.Log("The Power Tower already turned on.");
                }
            }
        }
    }

    private IEnumerator StartUpLight(float time){
        float final_volumeIntensity = 0.03f;
        float impact_volumeIntensity = 0.5f;

        yield return new WaitForSeconds(1.9f); // 처음에 켜질 때 위이잉 시간

        blueLight.intensity = 1f;
        blueLight.volumeIntensity = impact_volumeIntensity;
        green_LED.intensity = 1f;
        red_LED.intensity = 0f;
        for (int i = 0; i < 30; i++){
            blueLight.volumeIntensity -= (impact_volumeIntensity - final_volumeIntensity) / 30;
            yield return new WaitForSeconds(time / 30);
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
