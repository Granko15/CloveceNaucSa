using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class DiceRoller : MonoBehaviour
{
    //public TextMeshProUGUI resultText;  // Reference to the text element for dice result

    public int RollDiceResult()
    {
        int diceResult = Random.Range(1, 7);  // Random number between 1 and 6
        //resultText.text = $"You rolled a {diceResult}";
        Debug.Log($"You rolled a {diceResult}");
        return diceResult;
    }
}
