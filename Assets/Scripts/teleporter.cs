using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    [SerializeField] AudioSource teleporter_contacted_SFX;
    [SerializeField] AudioSource teleport_ready_SFX;
    [SerializeField] AudioSource teleport_SFX;
    [SerializeField] AudioSource tpcancel_SFX;
    [SerializeField] AudioSource turnon_SFX;
    // [SerializeField] GameObject chargebarBG;
    // [SerializeField] GameObject chargebar;
    [SerializeField] GameObject teleporter_door;
    [SerializeField] GameObject teleporter_door_active;
    [SerializeField] GameObject teleporter_wall;
    [SerializeField] GameObject teleporter_ready_obj;
    [SerializeField] GameObject teleporter_teleporting_obj;
    [SerializeField] GameObject redLight;
    [SerializeField] GameObject greenLight;

    // tp door frames
    [SerializeField] Sprite[] tp_door;

    [SerializeField] ParticleSystem door_closed_particle;
    [SerializeField] ParticleSystem teleport_particle;
    [SerializeField] ParticleSystem teleporter_contacted_particle;
    [SerializeField] GameObject destination;
    public float hold_time;
    // public float maxsize;
    private bool tpready_active_once = false;
    private bool tpcancel_active_once = false;
    private bool charge_done = false;
    private bool contacted = false;
    private Coroutine door_coroutine;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (contacted){

            if (Input.GetKey(KeyCode.E) && !charge_done){
                hold_time += Time.deltaTime;

                if (!tpready_active_once){
                    tpready_active_once = true;
                    tpcancel_active_once = false;
                    tpcancel_SFX.Stop();
                    tpcancel_SFX.time = 0f;

                    teleport_ready_SFX.Play();
                    teleporter_wall.SetActive(true);

                    door_coroutine = StartCoroutine(Animate_Door(3f));

                    teleporter_ready_obj.SetActive(true);
                    redLight.SetActive(true);
                }

                // if (!chargebarBG.activeSelf && !chargebar.activeSelf){
                //     chargebarBG.SetActive(true);
                //     chargebar.SetActive(true);
                // }
            }

            if (Input.GetKeyUp(KeyCode.E)){
                teleport_ready_SFX.Stop();
                teleport_ready_SFX.time = 0f;

                hold_time = 0f;
                tpready_active_once = false;
                // chargebarBG.SetActive(false);
                // chargebar.SetActive(false);

                if (!tpcancel_active_once && !charge_done){
                    tpcancel_SFX.Play();
                    teleporter_wall.SetActive(false);
                    teleporter_ready_obj.SetActive(false);
                    redLight.SetActive(false);

                    StopCoroutine(door_coroutine);
                    teleporter_door.GetComponent<SpriteRenderer>().sprite = tp_door[0];
                }
            }

            if (teleporter_door.GetComponent<SpriteRenderer>().sprite == tp_door[12]){
                StopCoroutine(door_coroutine);
                teleporter_door.GetComponent<SpriteRenderer>().sprite = tp_door[12];
                // 단일 스프라이트 소환
            }
        }

        if (hold_time >= 3f){
            if (!charge_done){
                turnon_SFX.Play();
                teleporter_door.SetActive(false);
                teleporter_door_active.SetActive(true);
                teleporter_wall.SetActive(true);
                teleporter_teleporting_obj.SetActive(true);
                greenLight.SetActive(true);
                door_closed_particle.Play();
                StartCoroutine(DelayedTeleportParticle(0.7f));
                StartCoroutine(Teleport_Sound());
            }

            teleport_ready_SFX.Stop();
            charge_done = true;
            // chargebarBG.SetActive(false);
            // chargebar.SetActive(false);
            StartCoroutine(Teleport());
           
        }
    }

    private IEnumerator Teleport(){
        hold_time = 0f;

        yield return new WaitForSeconds(2f);
        
        GameObject.FindWithTag("Player").transform.position = destination.transform.position;
    }

    private IEnumerator DelayedTeleportParticle(float time){
        yield return new WaitForSeconds(time);
        teleport_particle.Play();
    }

    IEnumerator Teleport_Sound(){
        teleport_SFX.time = 0.5f;
        teleport_SFX.Play();
        yield return new WaitForSeconds(2.5f);
        teleport_SFX.Stop();
        yield return null;
    }

    IEnumerator Animate_Door(float time){
        for (int i = 0; i < 13; i++){
            yield return new WaitForSeconds(time / 13);
            teleporter_door.GetComponent<SpriteRenderer>().sprite = tp_door[i];
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            contacted = true;
            teleporter_contacted_SFX.Play();
            teleporter_contacted_particle.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            contacted = false;

            // chargebarBG.SetActive(false);
            // chargebar.SetActive(false);
            teleport_ready_SFX.Stop();
            teleport_ready_SFX.time = 0f;
            tpcancel_SFX.Stop();
            tpcancel_SFX.time = 0f;
            teleport_SFX.Stop();
            teleport_SFX.time = 0f;
            hold_time = 0f;
            charge_done = false;
            tpready_active_once = false;
            tpcancel_active_once = false;
        }
    }
}
