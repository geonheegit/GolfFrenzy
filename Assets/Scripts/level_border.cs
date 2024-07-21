using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class level_border : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 vel = Vector3.zero;
    private float velFloat = 0f;
    [SerializeField] GameObject gmObj;
    private game_manager gm;

    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        gm = gmObj.GetComponent<game_manager>();
    }

    void Update()
    {
        // 캠 움직임
        if (gm.currentCamPos == 0){ // 0 = tutorial
            mainCam.transform.position = Vector3.SmoothDamp(mainCam.transform.position, GameObject.Find("tutorialcam").transform.position + new Vector3(0, 0, -1f), ref vel, 0.5f);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 10, ref velFloat, 0.5f);
        }
        else if (gm.currentCamPos == 1){ // 1 = levelBorder 1
            mainCam.transform.position = Vector3.SmoothDamp(mainCam.transform.position, GameObject.Find("1cam").transform.position + new Vector3(0, 0, -1f), ref vel, 0.5f);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 13, ref velFloat, 0.5f);
        }
        else if (gm.currentCamPos == 2){ // 2 = levelBorder 2
            mainCam.transform.position = Vector3.SmoothDamp(mainCam.transform.position, GameObject.Find("2cam").transform.position + new Vector3(0, 0, -1f), ref vel, 0.5f);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 13, ref velFloat, 0.5f);
        }
        else if (gm.currentCamPos == 3){ // 3 = levelBorder 3
            mainCam.transform.position = Vector3.SmoothDamp(mainCam.transform.position, GameObject.Find("3cam").transform.position + new Vector3(0, 0, -1f), ref vel, 0.5f);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 7, ref velFloat, 0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            if (gameObject.name == "t_1" && other.transform.position.x < transform.position.x){ // 플레이어가 왼쪽에서 오른쪽으로 넘어갈 때
                gm.currentCamPos = 1;

            }
            else if (gameObject.name == "t_1" && other.transform.position.x > transform.position.x){ // 플레이어가 오른쪽에서 왼쪽으로 넘어갈 때
                gm.currentCamPos = 0;

            }
            else if (gameObject.name == "1_2" && other.transform.position.x < transform.position.x){
                gm.currentCamPos = 2;

            }
            else if (gameObject.name == "1_2" && other.transform.position.x > transform.position.x){ // 플레이어가 오른쪽에서 왼쪽으로 넘어갈 때
                gm.currentCamPos = 1;

            }
            else if (gameObject.name == "2_3" && other.transform.position.x < transform.position.x){
                gm.currentCamPos = 3;

            }
            else if (gameObject.name == "2_3" && other.transform.position.x > transform.position.x){ // 플레이어가 오른쪽에서 왼쪽으로 넘어갈 때
                gm.currentCamPos = 2;

            }
        }
    }
}
