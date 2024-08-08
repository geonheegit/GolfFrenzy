using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_trigger : MonoBehaviour
{
    [SerializeField] bg_music bg_Music;

    void Start()
    {
        bg_Music = GameObject.Find("GameManager").GetComponent<bg_music>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            if (gameObject.name == "Forest_Music"){
                bg_Music.PlayMusic(1);
            }
            else if (gameObject.name == "Factory_Music"){
                bg_Music.PlayMusic(2);
            }
        }
    }
}
