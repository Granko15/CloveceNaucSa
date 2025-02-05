using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerId;  // Unique ID for the player
    public string playerName;  // Player's name
    public int pawnsRemaining = 6;  // Number of pawns the player starts with
    public bool isWinner = false;
    public string abilityToUse = null;


    private void Start()
    {
        Debug.Log($"Player {playerName} (ID: {playerId}) has {pawnsRemaining} pawns.");
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public string GetPlayerName()
    {
        return playerName;
    }
    public void SetAbilityToUse(string ability)
    {
        abilityToUse = ability;
    }

    public string GetAbilityToUse() 
    {
        return abilityToUse;

    }
    public bool CanHealAPawn() 
    {
        return HasPawnsRemaining() && pawnsRemaining < 6;

    }

    public void Heal() 
    {
        pawnsRemaining++;
    }

    public void UsePawn(int pawnId)
    {
        return;
    }

    public void ResetPawns()
    {
        pawnsRemaining = 6;  // Reset to default value or custom value if needed
        Debug.Log($"Player {playerName}'s pawns have been reset to {pawnsRemaining}.");
    }

    public bool HasPawnsRemaining()
    {
        return pawnsRemaining > 0;
    }

    public bool CheckWinCondition()
    {
        if (pawnsRemaining == 0)
        {
            isWinner = true;
            Debug.Log($"Player {playerName} is the winner!");
            return isWinner;
        }
        return isWinner;
    }
}