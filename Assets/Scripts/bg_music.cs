using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_music : MonoBehaviour
{
    [SerializeField] AudioSource music_player;
    [SerializeField] AudioClip forest_music;
    [SerializeField] AudioClip factory_music;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         
    }
    
    public void PlayMusic(int music_num){
        if (music_num == 1){
            music_player.clip = forest_music;
            music_player.Play();
        }
        else if (music_num == 2){
            music_player.clip = factory_music;
            music_player.Play();
        }
    }
}
