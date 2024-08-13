using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_trigger : MonoBehaviour
{
    [SerializeField] bg_music bg_Music;
    private background_img background_Img;

    void Start()
    {
        bg_Music = GameObject.Find("GameManager").GetComponent<bg_music>();
        background_Img = GameObject.Find("GameManager").GetComponent<background_img>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            if (gameObject.name == "Forest_Music"){
                bg_Music.PlayMusic(1);
                background_Img.currentBG = 1;
            }
            else if (gameObject.name == "Factory_Music"){
                bg_Music.PlayMusic(2);
                background_Img.currentBG = 2;
            }
            else if (gameObject.name == "Boss Fight Music 1"){
                bg_Music.PlayMusic(3);
                background_Img.currentBG = 2;
            }
        }
    }
}
