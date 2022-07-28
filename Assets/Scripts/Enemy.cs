using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables
    //movement variables
    public float moveSpeed;
    public float movementBuffer;
    public float minMovementBuffer;
    public float maxMovementBuffer;

    //bonus movement
    public float bonusMovement;
    public float minBonusMovement;
    public float maxBonusMovement;

    //other variables
    private CharacterController CharacterController;
    private Vector3 moveDirection;
    private Vector3 actualDirection;
    private Transform playerTransform;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
       playerTransform = GameObject.FindWithTag("Player").transform;
       CharacterController = GetComponent<CharacterController>();
       StartCoroutine(EnemyMovementRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform);
        actualDirection = transform.TransformDirection(moveDirection);
        CharacterController.Move(moveSpeed * actualDirection * Time.deltaTime);
    }

    private IEnumerator EnemyMovementRoutine()
    {
        while (true)
        {
            //randomize movementBuffer
            float _modifBuffer = UnityEngine.Random.Range(minMovementBuffer,maxMovementBuffer);

            moveDirection = Vector3.right + Vector3.forward;
            yield return new WaitForSeconds(_modifBuffer);

            moveDirection = Vector3.left + Vector3.forward;
            yield return new WaitForSeconds(_modifBuffer);
        }
    }
}
