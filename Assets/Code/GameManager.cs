using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints = new Transform[4];
    public static GameManager Instance;
    private void Start() {
        Instance = this;
    }

}
