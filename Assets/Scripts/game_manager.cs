using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    [SerializeField] GameObject player_prefab;
    [SerializeField] GameObject checkpoint_prefab;
    [SerializeField] GameObject gameover;
    public AudioSource doorOpenSFX;
    public int laser_charge_sfx_number = 1;
    public int laser_blast_sfx_number = 1;
    [SerializeField] AudioSource item_pickupSFX;

    public int currentCamPos; // level_border.cs

    void Awake()
    {
        Instantiate(player_prefab);

        GameObject[] checkpoint_points = GameObject.FindGameObjectsWithTag("Checkpoint");
        foreach (GameObject point in checkpoint_points){
            Instantiate(checkpoint_prefab, point.transform); // 각 체크포인트 지점의 자식오브젝트로서 체크포인트 오브젝트 instantiate.
        }

        currentCamPos = 0;
    }

    void Start()
    {
        doorOpenSFX = GameObject.Find("DoorSound").GetComponent<AudioSource>();
    }

    void Update(){
        // if(Input.GetKeyDown(KeyCode.R)){
        //     Destroy(GameObject.FindWithTag("Player"));
        //     Instantiate(player_prefab);
        //     gameover.SetActive(false);
        // }

        // if(Input.GetKeyDown(KeyCode.Alpha1)){
        //     GameObject.FindWithTag("Player").transform.position = GameObject.Find("Debug1").transform.position;
        // }
        // else if(Input.GetKeyDown(KeyCode.Alpha2)){
        //     GameObject.FindWithTag("Player").transform.position = GameObject.Find("Debug2").transform.position;
        // }
        // else if(Input.GetKeyDown(KeyCode.Alpha3)){
        //     GameObject.FindWithTag("Player").transform.position = GameObject.Find("Debug3").transform.position;
        // }
        // else if(Input.GetKeyDown(KeyCode.Alpha4)){
        //     GameObject.FindWithTag("Player").transform.position = GameObject.Find("Debug4").transform.position;
        // }
        // else if(Input.GetKeyDown(KeyCode.Alpha5)){
        //     GameObject.FindWithTag("Player").transform.position = GameObject.Find("Debug5").transform.position;
        // }
        // else if(Input.GetKeyDown(KeyCode.Alpha6)){
        //     GameObject.FindWithTag("Player").transform.position = GameObject.Find("Debug6").transform.position;
        // }
        
    }

    // Door Sound
    public IEnumerator doorSoundCut(float time, float wait_time){
        yield return new WaitForSeconds(wait_time);
        doorOpenSFX.time = time;
        yield return new WaitForSeconds(2f);
        doorOpenSFX.Stop();

    }

    public void PlaydoorSoundCut(){
        StartCoroutine(doorSoundCut(11f, 2f));
    }
    public void PlayItemPickUpSFX(){
        item_pickupSFX.Play();
    }
}
