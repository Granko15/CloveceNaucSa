using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public Player player1;
    public Player player2;
    public TextMeshProUGUI turnDisplayText;
    public GameObject playerNamePanel;  // Panel with the input fields
    public TMP_InputField player1Input;
    public TMP_InputField player2Input;
    public Button startButton;
    public Button endTurnButton;
    private Player currentPlayer;
    public GameMenu gameMenu;

    void Start()
    {
        // Initialize panel and button listener
        playerNamePanel.SetActive(true);  // Show the input panel
        currentPlayer = player1;  // Player 1 starts the game
        DisplayCurrentPlayerTurn();
    }

    // Called when "Start Game" button is clicked
    public void InitializePlayers()
    {
        // Set player names from the input fields
        player1.GetComponent<Player>().SetPlayerName(player1Input.text);
        player2.GetComponent<Player>().SetPlayerName(player2Input.text);

        // Debug to confirm names
        Debug.Log($"Player 1: {player1Input.text}, Player 2: {player2Input.text}");

        // Hide the player name input panel and show the turn UI
        playerNamePanel.SetActive(false);
        currentPlayer = player1;  // Player 1 starts the game
        DisplayCurrentPlayerTurn();
    }    

    public bool CheckWinner()
    {
        if (player1.CheckWinCondition())
        {
            Debug.Log("Player 1 wins!");
            return true;
        }
        else if (player2.CheckWinCondition())
        {
            Debug.Log("Player 2 wins!");
            return true;
        }
        return false;
    }
    // Switch to the next player
    public void NextTurn()
    {
      
        currentPlayer = (currentPlayer == player1) ? player2 : player1;  // Toggle between players
        Debug.Log($"Switching to Player {currentPlayer.GetPlayerName()}'s turn.");
        DisplayCurrentPlayerTurn();
    
    }

    private void GameOver()
    {
        Debug.Log($"{currentPlayer.name} wins!");
    }

    // Display the current player's turn in the UI
    private void DisplayCurrentPlayerTurn()
    {
        string playerName = currentPlayer.GetPlayerName();
        turnDisplayText.text = $"{playerName}'s Turn";
        Debug.Log($"It's {playerName}'s turn.");
    }

    // Get the current player
    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }

}
