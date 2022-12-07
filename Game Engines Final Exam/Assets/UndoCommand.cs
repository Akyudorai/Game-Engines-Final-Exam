using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoCommand : Command
{
    public static List<GameObject> pelletsEaten = new List<GameObject>();    

    public override void Invoke() 
    {   
        // If there is at least 1 pellet in the pellet chain, we can perform this command.
        if (pelletsEaten.Count > 0) 
        {       
            // Store a list of pellets to be turned on after loop
            List<GameObject> pelletsToUndo = new List<GameObject>();

            // Loop through the chain and restore the state of the pellet while removing a point.
            int count = Mathf.Min(pelletsEaten.Count, 7);

            for (int i = 0; i < count; i++) 
            {                                   
                // First check to see if we have a pellet that is valid
                if (pelletsEaten[(pelletsEaten.Count-1)-i] != null) 
                {
                    // Add the pellet to the undo list
                    pelletsToUndo.Add(pelletsEaten[(pelletsEaten.Count-1)-i]);
                } 

                // If there are no more pellets to turn on, break the loop early.
                else break;
            }         

            // Now re-enable all pellets that are in the undo list
            for (int i = 0; i < pelletsToUndo.Count; i++)  
            {
                pelletsToUndo[i].SetActive(true);
                pelletsEaten.Remove(pelletsToUndo[i]);
                GameManager.GetInstance().RemovePoint();
            }
        } 

        else {
            Debug.Log("No pellets to undo.");
        }
    }
}
