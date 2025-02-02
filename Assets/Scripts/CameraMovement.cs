using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private GameObject player;

    [SerializeField] private float chaseSpeed;
    [SerializeField] private float height;
    [SerializeField] private float rearDistance;

    private Vector3 currentVector;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + height, player.transform.position.z -rearDistance);
        transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        currentVector = new Vector3(player.transform.position.x, player.transform.position.y + height, player.transform.position.z - rearDistance);
        transform.position = Vector3.Lerp(transform.position, currentVector, chaseSpeed * Time.deltaTime);
    }
}
