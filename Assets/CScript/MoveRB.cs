using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveRB : MonoBehaviour
{
    private Vector3 PlayerMovement;
    [SerializeField] private Rigidbody playerBody;
    
    [Space] 
    [SerializeField] private float speed;
    [SerializeField] private float jumpforce;
    
    void Update()
    {
        PlayerMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        
        MovePlayer();
    }// Update is called once per frame

    private void MovePlayer()
    {
        Vector3 move = transform.TransformDirection(PlayerMovement) * speed ;
        playerBody.velocity = new Vector3(move.x, playerBody.velocity.y, move.z);
        
        /*if (move.magnitude >= 0.1f)
        {
            Quaternion faceRotation = Quaternion.LookRotation(playerBody.velocity);
            playerBody.MoveRotation(faceRotation);
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }
    
}
