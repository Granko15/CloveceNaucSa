using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    Rigidbody body;

    [SerializeField]
    private float maxRandomForce;

    [SerializeField]
    private float startRollingForce;

    private float forceX;

    private float forceY;

    private float forceZ;

    public int diceFaceNumber = 0;

    void Awake() 
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = true;
        transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360),Random.Range(0, 360), 0);
    }
    void Update()
    {
        if (body != null) 
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                RollDice();
            }
        }
    }

    private void RollDice() 
    {
        body.isKinematic = false;
        forceX = Random.Range(0, maxRandomForce);
        forceY = Random.Range(0, maxRandomForce);
        forceZ = Random.Range(0, maxRandomForce);
        body.AddForce(Vector3.up * startRollingForce);
        body.AddTorque(forceX, forceY, forceZ);

    }
}
