using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int waveNumber = 1;
    public List<GameObject> towerTypes;
    private List<int> towerTypeCost = new List<int> { 100, 300, 325 }; // Example costs for each tower type
    public GameObject towerButton;
    public GameObject deletionWarning;
    public TextMeshProUGUI currencyUI;

    public int currentTowerTypeIndex = 0;
    public int currency = 300;
    private TextMeshProUGUI towerButtonText;

    private void Start()
    {
        towerButtonText = towerButton.GetComponentInChildren<TextMeshProUGUI>();
        towerButtonText.text = towerTypes[currentTowerTypeIndex].name;
        currencyUI.text = $"${currency}";
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
        towerButtonText.text = $"{towerTypes[currentTowerTypeIndex].name} - ${towerTypeCost[currentTowerTypeIndex]}";
    }
}