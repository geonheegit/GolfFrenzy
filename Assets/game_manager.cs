using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    [SerializeField] GameObject ball_prefab;
    void Start()
    {
        Instantiate(ball_prefab);
    }
}
