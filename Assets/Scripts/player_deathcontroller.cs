using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_deathcontroller : MonoBehaviour
{
    public bool isDead = false;
    public GameObject deathscene;
    public GameObject respawnPos;
    [SerializeField] GameObject falling_spikes_prefab;
    [SerializeField] GameObject falling_objects_prefab;
    private Vector3 falling_spikes_origin_pos;
    private Vector3 falling_objects_origin_pos;
    private Vector3 boss_origin_pos;
    private void OnTriggerEnter2D(Collider2D other){
        
        if(other.tag == "Harm"){
            Debug.Log("dd");
            isDead = true;
            Time.timeScale = 0f;
        }
    }

    void Awake(){
        deathscene = GameObject.FindWithTag("Deathscene");
    }

    void Start()
    {
        falling_objects_origin_pos = GameObject.FindWithTag("Falling Objects").transform.position;
        falling_spikes_origin_pos = GameObject.FindWithTag("Falling Spikes").transform.position;
        boss_origin_pos = GameObject.FindWithTag("Boss").transform.position;
    }

    void Update()
    {
        if(isDead){
            deathscene.SetActive(true);
            if(Input.GetKeyDown(KeyCode.R)){
                Time.timeScale = 1f;
                isDead = false;
                deathscene.SetActive(false);
                transform.position = respawnPos.transform.position;
                GetComponent<Rigidbody2D>().gravityScale = 3f;
                ResetObjects();
                
            }
        }
    }

    private void ResetObjects(){
        GameObject.Find("bossfight_lever").GetComponent<bossfight1_lever>().active_once = false;
        GameObject.FindWithTag("Boss").transform.position = boss_origin_pos;
        Destroy(GameObject.FindWithTag("Falling Spikes"));
        GameObject new_falling_spikes = Instantiate(falling_spikes_prefab);
        new_falling_spikes.transform.position = falling_spikes_origin_pos;
        Destroy(GameObject.FindWithTag("Falling Objects"));
        GameObject new_falling_objects = Instantiate(falling_objects_prefab);
        new_falling_objects.transform.position = falling_objects_origin_pos;
    }
}
