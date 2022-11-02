using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoDuck : MonoBehaviour
{

    [SerializeField] private float attentionRadius = 5f;
    [SerializeField] private float duckSpeed = 0.5f;
    [SerializeField] private float rotationDuckSpeed = 0.8f;

    [SerializeField] private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= attentionRadius)
        {
            //TODO: draw attention mark above duck
            RotateTowardsPlayerDirection();
            MoveTowardsPlayer();
        }
        
        
    }

    private void RotateTowardsPlayerDirection()
    {
        Vector3 targetDirection = player.transform.position - transform.position;
        float singleStep = rotationDuckSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    
    private void MoveTowardsPlayer()
    {
        if(Vector3.Distance(transform.position, player.transform.position) > 1f)
        {
            var step = duckSpeed * Time.deltaTime; //calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            //TODO: Stop duck moving when within a certain radius of player, so player & duck doenst collide
        }
    }

    
}