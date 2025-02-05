using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PawnController : MonoBehaviour
{
    [SerializeField] private int playerId;
    [SerializeField] private int pawnId;

    private bool isShielded;

    public int GetPawnId()
    {
        return pawnId;
    }

    public void PerformActionOnClick(TurnManager turnManager)
    {
        Debug.Log($"Action triggered for Pawn {pawnId}");
        // Add your custom logic here (e.g., selecting the pawn, moving it, etc.)
        Player currentPlayer = turnManager.GetCurrentPlayer();

        if (currentPlayer != null) 
        {
            string selectedAbility = currentPlayer.GetAbilityToUse();
            if (selectedAbility.Equals("Shoot")) 
            {
                if (currentPlayer.playerId == playerId) // handle friendly fire
                {
                    Debug.Log("You cannot use your own pawn");
                    return;
                }
                Shoot(turnManager.GetOpponent(), currentPlayer); // we clicked oppponent pawn
            }
            else if (selectedAbility.Equals("Shield")) 
            {
                if (currentPlayer.playerId == playerId) 
                {
                    ShieldYourself();
                    return;
                }
                Debug.Log("Cannot apply shield to enemy pawn");
            }
        }
        else 
        {
            Debug.Log("Cannnot apply ability because reference of current Player's turn cannot be accessed");
        }
    }

    private void ShieldYourself()
    {
        isShielded = true;
    }

    private void Shoot(Player opponent, Player currentPlayer) 
    {
        if (isShielded)
        {
            isShielded = false;
            return;
        }
        opponent.pawnsRemaining--;
        currentPlayer.CheckWinCondition();
    }
}
