using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public  class Selection_Manager 
{

    

    public enum SelectionMode{
        Unit_Selected,
        Tile_Selected,
    }
    // If one unit selected it should be the color of the army color.
    // Easy with sprite renderer imo.
    // Enables Tile selection


    // Tile selection only happens when an unit selected
    // When an unit selected every possible tiles become visible
    // Hovered tile should be the color of the unit.
    // Path of that unit should be dotted.
    // When another click happens unit moves.
    private void Start() {

    }
    private void Update() {
    }
    public void Selected(){
    }
 
}
