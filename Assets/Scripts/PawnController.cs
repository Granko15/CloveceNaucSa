using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour
{
    [SerializeField] private int playerId;
    [SerializeField] private int pawnId;

    public int GetPawnId()
    {
        return pawnId;
    }

    public void PerformActionOnClick()
    {
        Debug.Log($"Action triggered for Pawn {pawnId}");
        // Add your custom logic here (e.g., selecting the pawn, moving it, etc.)
    }
}
