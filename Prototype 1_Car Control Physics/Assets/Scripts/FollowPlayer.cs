using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 9, -10);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //take the camera's position and set to the players (vehicle). add an offset so the camera is behind the player
        transform.position = player.transform.position + offset;
    }
}
