using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_music : MonoBehaviour
{
    [SerializeField] AudioSource music_player;
    [SerializeField] AudioClip forest_music;
    [SerializeField] AudioClip factory_music;
    [SerializeField] AudioClip bossfight1_music;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         
    }
    
    public void PlayMusic(int music_num){
        music_player.time = 0f;
        if (music_num == 1){
            music_player.volume = 0.015f;
            music_player.clip = forest_music;
            music_player.Play();
        }
        else if (music_num == 2){
            music_player.volume = 0.015f;
            music_player.clip = factory_music;
            music_player.Play();
        }
        else if (music_num == 3){
            music_player.volume = 0.01f;
            music_player.clip = bossfight1_music;
            music_player.Play();
        }
    }
}
