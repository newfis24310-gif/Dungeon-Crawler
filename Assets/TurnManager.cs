using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject dirmen;
    [SerializeField] List<Detector> detectors = new List<Detector>();

    public enum TurnState
    {
        DirectionSelection,
        PLayerMovement,
        TileAction
    }

    /*public void NextState()
    {
        state ++;
        if (state > maxstates)
        {
            state = 1;
        }
        ExecuteState(state);
    }

    public void ExecuteState(int st)
    {
        if(st == 1)
        {
            dirmen.SetActive(true);
            foreach (Detector detector in detectors)
            {
                detector.moveselection = true;
            }
        }
        else if (st == 2)
        {
            dirmen.SetActive(false);
            foreach (Detector detector in detectors)
            {
                detector.moveselection = false;
            }
            Debug.Log("State 2");
        }
    }*/
}
