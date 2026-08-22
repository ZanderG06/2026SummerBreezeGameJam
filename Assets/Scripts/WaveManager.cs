using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject ArmorEnemy;
    public GameObject fastEnemy;
    public GameObject waveButton;

    private TextMeshProUGUI waveButtonText;
    private List<GameObject> currentWave = new List<GameObject>();
    private List<int> waveEnemyCounts = new List<int> { 5, 10, 15 }; // Example counts for each wave
    private ServiceHub serviceHub;

    private void Start()
    {
        serviceHub = ServiceHub.Instance;

        waveButtonText = waveButton.GetComponentInChildren<TextMeshProUGUI>();

        CreateCurrentWave();
    }

    public void CreateCurrentWave()
    {
        currentWave = new List<GameObject>();
        for (int i = 0; i < waveEnemyCounts[serviceHub.GameManager.waveNumber - 1]; i++)
        {
            int enemyType = Random.Range(0, 3); // Randomly select enemy type
            switch (enemyType)
            {
                case 0:
                    currentWave.Add(basicEnemy);
                    break;
                case 1:
                    currentWave.Add(ArmorEnemy);
                    break;
                case 2:
                    currentWave.Add(fastEnemy);
                    break;
            }
        }
    }

    public void StartWaveCoroutine()
    {
        waveButton.SetActive(false);
        StartCoroutine(BeginWave());
    }

    IEnumerator BeginWave()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < currentWave.Count; i++)
        {
            GameObject enemyPrefab = currentWave[i];
            Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
        serviceHub.GameManager.waveNumber++;
        waveButton.SetActive(true);
        waveButtonText.text = "Start Wave " + serviceHub.GameManager.waveNumber;
        CreateCurrentWave();
    }
}