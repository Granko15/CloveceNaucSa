using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
   DiceRoll dice;

   [SerializeField]
   TextMeshProUGUI diceThrow;
    void Awake()
    {
        dice = FindObjectOfType<DiceRoll>();
    }

    void Update()
    {
        if (dice != null)
        {
            if (dice.diceFaceNumber != 0) 
            {
                diceThrow.text = dice.diceFaceNumber.ToString();

            }
        }
    }
}
