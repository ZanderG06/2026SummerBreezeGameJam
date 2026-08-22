using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int waveNumber = 1;
    public List<GameObject> towerTypes;

    private ServiceHub serviceHub;

    private void Start()
    {
        serviceHub = ServiceHub.Instance;

        serviceHub.WaveManager.CreateCurrentWave();
    }
}