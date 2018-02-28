using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHolder : MonoBehaviour {

    public List<Transform> player1SpawnPositions = new List<Transform>();
    public List<Transform> player2SpawnPositions = new List<Transform>();

    public List<Transform> StoreDoors(int player) {
        if (player == 1) {
            return player1SpawnPositions;
            }
        else {
            return player2SpawnPositions;
            }
        }
}
