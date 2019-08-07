using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    [SerializeField]
    private Player player;
    private Vector3 startPosition;

    void Awake() {
        startPosition = transform.position;
    }
    
    void Update() {
        transform.position = new Vector3(player.transform.position.x - 1, startPosition.y, -1f);
    }

}