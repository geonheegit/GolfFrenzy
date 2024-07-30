using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable_block : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] float respawn_time_after_destroyed = 3f;
    [SerializeField] ParticleSystem dustParticle;
    [SerializeField] bool respawn;
    private bool is_touched = false;
    private Vector3 originPos;

    void Start()
    {
        originPos = transform.position;
    }

    IEnumerator Respawn(float sec){
        yield return new WaitForSeconds(sec);
        if(respawn){
            Debug.Log("respawned");

            transform.position = originPos;
            
            is_touched = false;
        }
    }

    IEnumerator Shake(float duration){
        int loopcount = 10;
        float intensity = 0.05f;
        for (int i = 0; i < loopcount; i++){
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + intensity, gameObject.transform.position.y, gameObject.transform.position.z);
            yield return new WaitForSeconds(duration / (loopcount * 2));
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - intensity, gameObject.transform.position.y, gameObject.transform.position.z);
            yield return new WaitForSeconds(duration / (loopcount * 2));
        }
    }

    IEnumerator SummonDestroyParticle(float sec){
        ParticleSystem summoned_dustParticle = Instantiate(dustParticle);
        summoned_dustParticle.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(sec);
        summoned_dustParticle.Stop();
        yield return new WaitForSeconds(2);
        Destroy(summoned_dustParticle);
    }

    // 메인 코루틴
    IEnumerator ShakeSelfBreak(float sec){
        StartCoroutine(Shake(sec));
        StartCoroutine(SummonDestroyParticle(sec));
        yield return new WaitForSeconds(sec);
        transform.position = new Vector3(10000, 10000, 0);

        // 리스폰
        StartCoroutine(Respawn(respawn_time_after_destroyed));
    }

    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"){
            
            if (!is_touched){
                StartCoroutine(ShakeSelfBreak(timer));
            }
            is_touched = true;
            
        }
    }
}
