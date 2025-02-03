using UnityEngine;

public class RaycastClickHandler : MonoBehaviour
{
    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log($"Raycast hit: {hit.collider.gameObject.name}");  // Check what object is hit

                GameObject clickedObject = hit.collider.gameObject;
                PawnController pawn = clickedObject.GetComponentInParent<PawnController>();

                if (pawn != null)
                {
                    Debug.Log($"Player Pawn {pawn.GetPawnId()} clicked!");
                    pawn.PerformActionOnClick();
                }
                else
                {
                    Debug.Log("No pawn detected on click.");
                }
            }

        }
    }
}
