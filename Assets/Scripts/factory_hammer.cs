using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class factory_hammer : MonoBehaviour
{
    [SerializeField] GameObject hitbox;
    private AudioSource hammer_hit_SFX;
    private SpriteRenderer spriteRenderer;
    private bool playOnce;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hammer_hit_SFX = GetComponent<AudioSource>();
        hitbox.SetActive(false);
        playOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer.sprite.name == "hammerrecolor_2" || spriteRenderer.sprite.name == "hammerrecolor_3"){
            hitbox.SetActive(true);
        }
        else{
            hitbox.SetActive(false);
        }

        if (spriteRenderer.sprite.name == "hammerrecolor_3" && !playOnce){
            playOnce = true;
            hammer_hit_SFX.time = 0;
            hammer_hit_SFX.Play();
        }
        else if (spriteRenderer.sprite.name == "hammerrecolor_7"){
            playOnce = false;
        }
    }
}
