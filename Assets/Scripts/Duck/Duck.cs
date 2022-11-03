using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Duck : MonoBehaviour
{

    [SerializeField] private SODuck duckScriptableObject;
    
    private float attentionRadius = 5f;
    private float duckSpeed = 0.5f;
    private float rotationDuckSpeed = 0.8f;
    private ScriptableObject duckFavFood; 
    private GameObject player;
    public static PlayerController _playerController;
    private Vector3 randomIdlePoint;

    private float idleTimer = 2f;

    private void Start()
    {
        attentionRadius = duckScriptableObject.duckAttentionRadius;
        duckSpeed = duckScriptableObject.duckSpeed;
        rotationDuckSpeed = duckScriptableObject.duckRotationSpeed;
        duckFavFood = duckScriptableObject.duckFavoritFood;
        
        _playerController = PlayerController.Instance;
        
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        
    }
    
    void Update()
    {
        idleTimer -= Time.deltaTime;
        
        if (Vector3.Distance(this.transform.position, player.transform.position) <= attentionRadius && _playerController.GetCurrentDuckFoodInHand == duckFavFood)
        {
            //TODO: draw attention mark above duck
            RotateTowardsTargetDirection(player.transform.position);
            MoveTowardsPlayer();
        }

        if (!(Vector3.Distance(this.transform.position, player.transform.position) <= attentionRadius)) //IDLE if either no player is near duck, or player doesnt holt the right item
        {
            IdleWalk();
        }
    }

    private void RotateTowardsTargetDirection(Vector3 _targetPos)
    {

        //TODO: Bug? Duck rotates towards player pos, but doesnt rotate towards randomIdlePoint pos 
        Vector3 targetDirection = _targetPos - transform.position;
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

    private void IdleWalk()
    {
        if (idleTimer <= 0)
        {
            // Pick random point near duck (Within attentionRadius)
            Vector2 currentPos = new Vector2(transform.position.x, transform.position.z);
            Vector2 ran = currentPos + Random.insideUnitCircle * 5;
            randomIdlePoint = new Vector3(ran.x, transform.position.y, ran.y);

            RotateTowardsTargetDirection(randomIdlePoint);
            idleTimer = 5f; //reset timer
        }
        
        // Walk towards chosen point
        var step = duckSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, randomIdlePoint, step);
    }

    
}