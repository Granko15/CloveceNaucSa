using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FaceDetector : MonoBehaviour
{
    DiceRoll dice;
    void Awake()
    {
        dice = FindObjectOfType<DiceRoll>();
    }

    void OnTriggerStay(Collider other)
    {
        if (dice != null) 
        {
            Rigidbody body = dice.GetComponent<Rigidbody>();
            if (body.velocity == Vector3.zero) 
            {
              switch (other.name) { // musime dat opacne cislo ako to na ktore dopadne kocka
                case "1":
                    dice.diceFaceNumber = 6;
                    break;
                case "2":
                    dice.diceFaceNumber = 5;
                    break;
                case "3":
                    dice.diceFaceNumber = 4;
                    break;
                 case "4":
                    dice.diceFaceNumber = 3;
                    break;
                 case "5":
                    dice.diceFaceNumber = 2;
                    break;
                 case "6":
                    dice.diceFaceNumber = 1;
                    break;
              }
              //Debug.Log("Face: " + dice.diceFaceNumber);
            }
        }
    }
}
