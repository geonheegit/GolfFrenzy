using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_border : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 vel = Vector3.zero;
    private float velFloat = 0f;
    private float smoothTime;
    [SerializeField] GameObject gmObj;
    private game_manager gm;
    [SerializeField] GameObject[] camPositions;

    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        gm = gmObj.GetComponent<game_manager>();
        smoothTime = 0.5f;
    }

    void Update()
    {
        // 캠 움직임
        if (gm.currentCamPos == 0){ // 0 = tutorial
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPositions[gm.currentCamPos].transform.position + new Vector3(0, 0, -1f), Time.smoothDeltaTime);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 10, ref velFloat, smoothTime);
        }
        else if (gm.currentCamPos == 1){ // 1 = levelBorder 1
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPositions[gm.currentCamPos].transform.position + new Vector3(0, 0, -1f), Time.smoothDeltaTime);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 13, ref velFloat, smoothTime);
        }
        else if (gm.currentCamPos == 2){ // 2 = levelBorder 2
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPositions[gm.currentCamPos].transform.position + new Vector3(0, 0, -1f), Time.smoothDeltaTime);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 13, ref velFloat, smoothTime);
        }
        else if (gm.currentCamPos == 3){ // 3 = levelBorder 3
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPositions[gm.currentCamPos].transform.position + new Vector3(0, 0, -1f), Time.smoothDeltaTime);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 13, ref velFloat, smoothTime);
        }
        else if (gm.currentCamPos == 4){ // 4 = levelBorder 4
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPositions[gm.currentCamPos].transform.position + new Vector3(0, 0, -1f), Time.smoothDeltaTime);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 15, ref velFloat, smoothTime);
        }
        else if (gm.currentCamPos == 5){ // 5 = levelBorder 5
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPositions[gm.currentCamPos].transform.position + new Vector3(0, 0, -1f), Time.smoothDeltaTime);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 10, ref velFloat, smoothTime);
        }
        else if (gm.currentCamPos == 6){ // 6 = levelBorder 6
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPositions[gm.currentCamPos].transform.position + new Vector3(0, 0, -1f), Time.smoothDeltaTime);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 7, ref velFloat, smoothTime);
        }
        else if (gm.currentCamPos == 7){ // 7 = levelBorder 7
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPositions[gm.currentCamPos].transform.position + new Vector3(0, 0, -1f), Time.smoothDeltaTime);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 7, ref velFloat, smoothTime);
        }
        else if (gm.currentCamPos == 8){
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPositions[gm.currentCamPos].transform.position + new Vector3(0, 0, -1f), Time.smoothDeltaTime);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 7, ref velFloat, smoothTime);
        }
        else if (gm.currentCamPos == 9){
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPositions[gm.currentCamPos].transform.position + new Vector3(0, 0, -1f), Time.smoothDeltaTime);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 7, ref velFloat, smoothTime);
        }
        else if (gm.currentCamPos == 10){
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPositions[gm.currentCamPos].transform.position + new Vector3(0, 0, -1f), Time.smoothDeltaTime);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 10, ref velFloat, smoothTime);
        }
        else if (gm.currentCamPos == 11){
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPositions[gm.currentCamPos].transform.position + new Vector3(0, 0, -1f), Time.smoothDeltaTime);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 13, ref velFloat, smoothTime);
        }
        else if (gm.currentCamPos == 12){
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPositions[gm.currentCamPos].transform.position + new Vector3(0, 0, -1f), Time.smoothDeltaTime);
            mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, 7, ref velFloat, smoothTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        float playerYposOffset = 1.23f;
        float playerXpos;
        float playerYpos;

        if (other.tag == "Player"){
            playerXpos = other.transform.position.x;
            playerYpos = other.transform.position.y + playerYposOffset;

            if (gameObject.name == "t_1" && playerXpos < transform.position.x){ // 플레이어가 왼쪽에서 오른쪽으로 넘어갈 때
                gm.currentCamPos = 1;

            }
            else if (gameObject.name == "t_1" && playerXpos > transform.position.x){ // 플레이어가 오른쪽에서 왼쪽으로 넘어갈 때
                gm.currentCamPos = 0;

            }

            else if (gameObject.name == "1_2" && playerYpos < transform.position.y){
                gm.currentCamPos = 2;

            }
            else if (gameObject.name == "1_2" && playerYpos > transform.position.y){
                gm.currentCamPos = 1;
            }

            else if (gameObject.name == "2_3" && playerXpos < transform.position.x){
                gm.currentCamPos = 3;

            }
            else if (gameObject.name == "2_3" && playerXpos > transform.position.x){ // 플레이어가 오른쪽에서 왼쪽으로 넘어갈 때
                gm.currentCamPos = 2;

            }

            else if (gameObject.name == "3_4" && playerXpos < transform.position.x){
                gm.currentCamPos = 4;

            }
            else if (gameObject.name == "3_4" && playerXpos > transform.position.x){ // 플레이어가 오른쪽에서 왼쪽으로 넘어갈 때
                gm.currentCamPos = 3;

            }

            else if (gameObject.name == "4_5" && playerXpos < transform.position.x){
                gm.currentCamPos = 5;

            }
            else if (gameObject.name == "4_5" && playerXpos > transform.position.x){ // 플레이어가 아래에서 위로 넘어갈 때
                gm.currentCamPos = 4;

            }

            else if (gameObject.name == "5_6" && playerYpos < transform.position.y){
                gm.currentCamPos = 6;

            }
            else if (gameObject.name == "5_6" && playerYpos > transform.position.y){ // 플레이어가 아래에서 위로 넘어갈 때
                gm.currentCamPos = 5;

            }

            else if (gameObject.name == "6_7" && playerYpos < transform.position.y){
                gm.currentCamPos = 7;

            }
            else if (gameObject.name == "6_7" && playerYpos > transform.position.y){ // 플레이어가 아래에서 위로 넘어갈 때
                gm.currentCamPos = 6;

            }

            else if (gameObject.name == "7_8" && playerYpos < transform.position.y){
                gm.currentCamPos = 8;

            }
            else if (gameObject.name == "7_8" && playerYpos > transform.position.y){ // 플레이어가 아래에서 위로 넘어갈 때
                gm.currentCamPos = 7;

            }

            else if (gameObject.name == "8_9" && playerYpos < transform.position.y){
                gm.currentCamPos = 9;

            }
            else if (gameObject.name == "8_9" && playerYpos > transform.position.y){ // 플레이어가 아래에서 위로 넘어갈 때
                gm.currentCamPos = 8;

            }

            else if (gameObject.name == "9_10" && playerYpos < transform.position.y){
                gm.currentCamPos = 10;

            }
            else if (gameObject.name == "9_10" && playerYpos > transform.position.y){ // 플레이어가 아래에서 위로 넘어갈 때
                gm.currentCamPos = 9;

            }

            else if (gameObject.name == "10_11" && playerXpos < transform.position.x){
                gm.currentCamPos = 11;

            }
            else if (gameObject.name == "10_11" && playerXpos > transform.position.x){ // 플레이어가 아래에서 위로 넘어갈 때
                gm.currentCamPos = 10;

            }

            else if (gameObject.name == "11_12" && playerXpos < transform.position.x){
                gm.currentCamPos = 12;

            }
            else if (gameObject.name == "11_12" && playerXpos > transform.position.x){ // 플레이어가 아래에서 위로 넘어갈 때
                gm.currentCamPos = 11;

            }
        }
    }
}
