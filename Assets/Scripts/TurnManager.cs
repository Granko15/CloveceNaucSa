using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public Player player1;
    public Player player2;
    public TextMeshProUGUI turnDisplayText;
    public GameObject playerNamePanel;
    public TMP_InputField player1Input;
    public TMP_InputField player2Input;
    public Button diceRollButton;
    public Button abilitySelectionButton;
    public Button endTurnButton;
    public TextMeshProUGUI diceResultText;

    private Player currentPlayer;
    private Player nextPlayer;  // Track the player who goes second in the current round
    private bool isFirstTurnOfRound = true;  // Track if it's the first or second turn of the round
    public DiceRoller diceRoller;

    void Start()
    {
        SetupInitialUI();
    }

    void Update()
    {
        if (CheckWinConditions())
        {
            enabled = false;  // Stops the game when a player wins
        }
    }

    public void InitializePlayers()
    {
        player1.SetPlayerName(player1Input.text);
        player2.SetPlayerName(player2Input.text);

        playerNamePanel.SetActive(false);
        turnDisplayText.text = "Roll the dice to determine who starts.";
        diceRollButton.interactable = true;
    }

    public void OnDiceRollClicked()
    {
        int player1Roll = diceRoller.RollDiceResult();
        int player2Roll = diceRoller.RollDiceResult();
        diceResultText.text = $"{player1.GetPlayerName()} rolled: {player1Roll}, {player2.GetPlayerName()} rolled: {player2Roll}";

        if (player1Roll == player2Roll)
        {
            HandleTie();
        }
        else
        {
            DetermineStartingPlayer(player1Roll, player2Roll);
            diceRollButton.interactable = false;
        }
    }

    private void DetermineStartingPlayer(int player1Roll, int player2Roll)
    {
        if (player1Roll > player2Roll)
        {
            currentPlayer = player1;
            nextPlayer = player2;
        }
        else
        {
            currentPlayer = player2;
            nextPlayer = player1;
        }

        turnDisplayText.text = $"{currentPlayer.GetPlayerName()} starts the round.";
        abilitySelectionButton.interactable = true;
        isFirstTurnOfRound = true;  // Reset for a new round
    }

    public void PlayerAnsweredCorrectly()
    {
        endTurnButton.interactable = true;
        abilitySelectionButton.interactable = false;
    }

    public void PlayerAnsweredIncorrectly()
    {
        Debug.Log($"{currentPlayer.GetPlayerName()} answered incorrectly. Skipping their turn.");
        MoveToNextTurn();
    }

    public void EndTurn()
    {
        MoveToNextTurn();
    }

    private void MoveToNextTurn()
    {
        if (isFirstTurnOfRound)
        {
            // Switch to the next player for the second turn of the round
            currentPlayer = nextPlayer;
            isFirstTurnOfRound = false;
            Debug.Log("NEXTTTTTTT");
            turnDisplayText.text = $"{currentPlayer.GetPlayerName()}'s Turn.";
        }
        else
        {
            // Both players have taken their turns; reset for the next round
            ResetForNextRound();
        }

        abilitySelectionButton.interactable = true;
        endTurnButton.interactable = false;
    }

    private void ResetForNextRound()
    {
        turnDisplayText.text = "Both players have completed their turns. Roll the dice for the next round.";
        diceResultText.text = "---";

        diceRollButton.interactable = true;
        abilitySelectionButton.interactable = false;
        endTurnButton.interactable = false;
    }

    private void HandleTie()
    {
        Debug.Log("It's a tie! Roll again.");
        turnDisplayText.text = "It's a tie! Roll the dice again.";
        diceRollButton.interactable = true;
        abilitySelectionButton.interactable = false;
    }

    private void SetupInitialUI()
    {
        playerNamePanel.SetActive(true);
        turnDisplayText.text = "Enter player names to start.";
        diceRollButton.interactable = false;
        abilitySelectionButton.interactable = false;
        endTurnButton.interactable = false;
    }

    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public Player GetOpponent()
    {
        return (currentPlayer == player1) ? player2 : player1;
    }

    public bool CheckWinConditions()
    {
        if (player1.pawnsRemaining <= 0)
        {
            Debug.Log($"Player {player2.GetPlayerName()} wins!");
            return true;
        }
        else if (player2.pawnsRemaining <= 0)
        {
            Debug.Log($"Player {player1.GetPlayerName()} wins!");
            return true;
        }
        return false;
    }
}
