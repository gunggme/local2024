using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCube : MonoBehaviour
{
    public List<string> ItemNames = new List<string>()
    {
        "Boost",
        "Boost",
        "Boost",
        "Boost",
        "MegaBoost",
        "MegaBoost",
        "MegaBoost",
        "100 Gold",
        "100 Gold",
        "500 Gold",
        "1000 Gold",
        "Shop"
    };

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            int ranIndex = Random.Range(0, ItemNames.Count);
            PlayerCar playerCar = FindObjectOfType<PlayerCar>();
            switch (ItemNames[ranIndex])
            {
                case "Boost":
                    playerCar.StartCoroutine(playerCar.Boost(BoostType.Boost));
                    gameManager.EventOn("Boost!");
                    SoundManager.Instance.SoundPlay(9, AudioType.FBX, 5);
                    break;
                case "MegaBoost":
                    playerCar.StartCoroutine(playerCar.Boost(BoostType.MegaBoost));
                    gameManager.EventOn("Mega Boost!!");
                    SoundManager.Instance.SoundPlay(10, AudioType.FBX, 5);
                    break;
                case "100 Gold":
                    gameManager.UpdateGoldText(100);
                    gameManager.EventOn("+ $ 100");
                    SoundManager.Instance.SoundPlay(0, AudioType.FBX);
                    break;
                case "500 Gold":
                    SoundManager.Instance.SoundPlay(0, AudioType.FBX);
                    gameManager.UpdateGoldText(500);
                    gameManager.EventOn("+ $ 500");
                    break;
                case "1000 Gold":
                    SoundManager.Instance.SoundPlay(0, AudioType.FBX);
                    gameManager.UpdateGoldText(1000);
                    gameManager.EventOn("+ $ 1000");
                    break;
                case "Shop":
                    gameManager.OpenShop();
                    gameManager.EventOn("ShopOpen!");
                    break;
            }
            Debug.Log(ItemNames[ranIndex]);
            Destroy(gameObject);
        }
    }
}
