using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(11, 4.5f, 0);

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
