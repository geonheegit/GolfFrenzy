using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_gear : MonoBehaviour
{
    [SerializeField] GameObject box_spawn;
    private AudioSource box_break_SFX;
    [SerializeField] GameObject box_break_effect_obj;
    void Start()
    {
        box_break_SFX = transform.parent.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactives"){
            StartCoroutine(ResetBox(other.gameObject));

            
        }
    }

    IEnumerator ResetBox(GameObject box){
        box_break_effect_obj.transform.position = box.transform.position;
        box_break_effect_obj.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(0.01f);

        box.transform.position = new Vector3(box_spawn.transform.position.x, box_spawn.transform.position.y, 9);
        box.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        box.GetComponent<Rigidbody2D>().gravityScale = 1f;
        box_break_SFX.Play();
    }
}
