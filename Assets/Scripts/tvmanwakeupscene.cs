using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tvmanwakeupscene : MonoBehaviour
{
    private SpriteRenderer sr;
    private GameObject player;
    [SerializeField] private Sprite tvmanoff;
    [SerializeField] private Sprite tvmanon_1;
    [SerializeField] private Sprite tvmanon_2;
    [SerializeField] private GameObject basic1;
    public GameObject sceneText;
    public GameObject sceneText2;

    private bool loop;
    private bool actonce;
    private int step = 0;

    IEnumerator dstry(float time){
        yield return new WaitForSeconds(time);
        basic1.SetActive(true);
        sceneText.SetActive(false);
        sr.sprite = null;
        player.GetComponent<player_controller>().isStop = false;
        player.GetComponent<SpriteRenderer>().sortingOrder = 1;

    }
    IEnumerator anim(float time, Sprite sp){
        loop = false;
        yield return new WaitForSeconds(time);
        sr.sprite = sp;
        if(step == 4){
            step = 1;
        }
        else{
            step++;
        }
        loop = true;
        if(actonce == false){
            sr.sprite = null;
        }
    }

    IEnumerator startText(float time, GameObject text){
        yield return new WaitForSeconds(time);
        text.SetActive(true);
    }

    void Awake(){
        
        actonce = true;
        loop = false;
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(anim(3f, tvmanon_1));
        StartCoroutine(startText(6f, sceneText));
        
        

    }
    
    void Update(){
        if(player == null){
            player = GameObject.FindWithTag("Player");
            player.GetComponent<SpriteRenderer>().sortingOrder = - 100;
            player.transform.position = this.transform.position;
            player.GetComponent<player_controller>().isStop = true;
        }

        if(loop){



            if(step == 1){
                StartCoroutine(anim(0.2f, tvmanon_1));
            }
            else if(step == 2)
            {
                StartCoroutine(anim(0.1f, tvmanon_2));
            }
            else if(step == 3){
                StartCoroutine(anim(0.2f, tvmanon_1));
            }
            else{
                StartCoroutine(anim(1f, tvmanon_2));
            }
            
        }

        if(sceneText.GetComponent<TextPrint>().done && actonce){
            loop = false;
            actonce = false;
            StartCoroutine(startText(3.5f, sceneText2));
            StartCoroutine(dstry(2f));
        }
        
    }
}
