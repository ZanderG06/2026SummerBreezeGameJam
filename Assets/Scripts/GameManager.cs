using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int waveNumber = 1;
    public List<GameObject> towerTypes;
    public GameObject towerButton;
    public GameObject deletionWarning;

    public int currentTowerTypeIndex = 0;
    private TextMeshProUGUI towerButtonText;

    private void Start()
    {
        towerButtonText = towerButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ChangeTowerType()
    {
        currentTowerTypeIndex++;
        if (currentTowerTypeIndex == towerTypes.Count)
        {
            towerButtonText.text = "Remove Tower";
            deletionWarning.SetActive(true);
            return;
        }
        deletionWarning.SetActive(false);
        if (currentTowerTypeIndex > towerTypes.Count) currentTowerTypeIndex = 0;
        towerButtonText.text = towerTypes[currentTowerTypeIndex].name;
    }
}