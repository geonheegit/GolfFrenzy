using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_deathcontroller : MonoBehaviour
{
    private bool isDead;
    [SerializeField] GameObject deathscene;
    public GameObject respawnPos;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Harm"){
            isDead = true;
            Time.timeScale = 0f;
        }
    }

    void Awake(){
        deathscene = GameObject.FindWithTag("Deathscene");
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
            }
        }
    }
}
