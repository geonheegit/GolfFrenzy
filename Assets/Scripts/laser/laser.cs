using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class laser : MonoBehaviour
{
    public bool detected = false;
    private GameObject laserEffect;
    private GameObject laserWarning;
    private game_manager gm;
    private Light2D laserblast_red_led;
    private Light2D laserblast_yellow_led;
    [SerializeField] AudioSource laserChargeSFX;
    [SerializeField] AudioSource laserShotSFX;
    [SerializeField] float norm_volume;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<game_manager>();

        for (int i = 0; i < transform.childCount; i++){
            if (transform.GetChild(i).gameObject.name == "Laser Effect"){
                laserEffect = transform.GetChild(i).gameObject;
            }
        }

        for (int i = 0; i < transform.childCount; i++){
            if (transform.GetChild(i).gameObject.name == "Warning"){
                laserWarning = transform.GetChild(i).gameObject;
            }
        }

        for (int i = 0;i < laserEffect.transform.childCount; i++){
            if (laserEffect.transform.GetChild(i).gameObject.name == "redLight"){
                laserblast_red_led = laserEffect.transform.GetChild(i).gameObject.GetComponent<Light2D>();
            }
            else if (laserEffect.transform.GetChild(i).gameObject.name == "yellowLight"){
                laserblast_yellow_led = laserEffect.transform.GetChild(i).gameObject.GetComponent<Light2D>();
            }
        }

        laserEffect.SetActive(false);
        laserWarning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if (detected){
        //     StartCoroutine(ActiveLaser(1f, true));
        // }
        // else{
        //     StartCoroutine(ActiveLaser(0f, false));
        // }
        laserChargeSFX.volume = norm_volume / gm.laser_charge_sfx_number;
        laserShotSFX.volume = norm_volume / gm.laser_blast_sfx_number;
    }

    public IEnumerator ActiveLaser(float time, bool on){
        if (on){
            laserWarning.SetActive(true);
            laserChargeSFX.time = 0.5f; // offset
            gm.laser_charge_sfx_number += 1;
            laserChargeSFX.Play();
        }
        
        yield return new WaitForSeconds(time);

        if (on){
            laserEffect.SetActive(true);
            StartCoroutine(ShrinkLED_ARC(2f));
            gm.laser_charge_sfx_number -= 1;
            laserChargeSFX.Stop();
            laserShotSFX.time = 0.5f; // offset
            gm.laser_blast_sfx_number += 1;
            laserShotSFX.Play();
        }
        else{
            yield return new WaitForSeconds(5f);
            laserEffect.SetActive(false);
            gm.laser_blast_sfx_number -= 1;
        }

        laserWarning.SetActive(false);
    }

    IEnumerator ShrinkLED_ARC(float time){
        float origin_red_inner_angle = laserblast_red_led.pointLightInnerAngle;
        float origin_red_outer_angle = laserblast_red_led.pointLightOuterAngle;
        float origin_yellow_inner_angle = laserblast_yellow_led.pointLightInnerAngle;
        float origin_yellow_outer_angle = laserblast_yellow_led.pointLightOuterAngle;

        for (int i = 0; i < 59; i++){
            yield return new WaitForSeconds(time / 60);
            laserblast_red_led.pointLightInnerAngle -= origin_red_inner_angle / 60;
            laserblast_red_led.pointLightOuterAngle -= origin_red_outer_angle / 60;
            laserblast_yellow_led.pointLightInnerAngle -= origin_yellow_inner_angle / 60;
            laserblast_yellow_led.pointLightOuterAngle -= origin_yellow_outer_angle / 60;
        }

        yield return new WaitForSeconds(3f);

        laserblast_red_led.pointLightInnerAngle = origin_red_inner_angle;
        laserblast_red_led.pointLightOuterAngle = origin_red_outer_angle;
        laserblast_yellow_led.pointLightInnerAngle = origin_yellow_inner_angle;
        laserblast_yellow_led.pointLightOuterAngle = origin_yellow_outer_angle;
    }
}
