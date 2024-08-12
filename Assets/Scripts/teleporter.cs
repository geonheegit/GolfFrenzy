using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    [SerializeField] AudioSource teleport_ready_SFX;
    [SerializeField] AudioSource teleport_SFX;
    [SerializeField] AudioSource tpcancel_SFX;
    [SerializeField] AudioSource turnon_SFX;
    [SerializeField] GameObject chargebarBG;
    [SerializeField] GameObject chargebar;
    [SerializeField] GameObject destination;
    private float hold_time;
    public float maxsize;
    private bool tpready_active_once = false;
    private bool tpcancel_active_once = false;
    private bool charge_done = false;
    private bool contacted = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        chargebar.transform.localScale = new Vector3(maxsize / (3 / hold_time), chargebar.transform.localScale.y, chargebar.transform.localScale.z);

        if (contacted){

            if (Input.GetKey(KeyCode.E) && !charge_done){
                hold_time += Time.deltaTime;

                if (!tpready_active_once){
                    tpready_active_once = true;
                    tpcancel_active_once = false;
                    tpcancel_SFX.Stop();
                    tpcancel_SFX.time = 0f;

                    teleport_ready_SFX.Play();
                }

                if (!chargebarBG.activeSelf && !chargebar.activeSelf){
                    chargebarBG.SetActive(true);
                    chargebar.SetActive(true);
                }
            }

            if (Input.GetKeyUp(KeyCode.E)){
                teleport_ready_SFX.Stop();
                teleport_ready_SFX.time = 0f;

                hold_time = 0f;
                tpready_active_once = false;
                chargebarBG.SetActive(false);
                chargebar.SetActive(false);

                if (!tpcancel_active_once && !charge_done){
                    tpcancel_SFX.Play();
                }
            }
        }

        if (hold_time >= 3f){
            if (!charge_done){
                turnon_SFX.Play();
            }

            teleport_ready_SFX.Stop();
            charge_done = true;
            chargebarBG.SetActive(false);
            chargebar.SetActive(false);
            StartCoroutine(Teleport());
        }
    }

    private IEnumerator Teleport(){
        hold_time = 0f;
        StartCoroutine(Teleport_Sound());
        yield return new WaitForSeconds(1f);
        GameObject.FindWithTag("Player").transform.position = destination.transform.position;
    }

    IEnumerator Teleport_Sound(){
        teleport_SFX.time = 0.5f;
        teleport_SFX.Play();
        GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(2.5f);
        teleport_SFX.Stop();
        yield return null;
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

            chargebarBG.SetActive(false);
            chargebar.SetActive(false);
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
