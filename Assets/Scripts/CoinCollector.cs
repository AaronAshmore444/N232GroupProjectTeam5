using UnityEngine;

using TMPro;



public class CoinCollector : MonoBehaviour

{

    public int coinsCollected = 0;

    public TextMeshProUGUI coinText;



    void OnTriggerEnter(Collider other)

    {

        if (other.CompareTag("Collectible"))

        {

            coinsCollected++;

            Destroy(other.gameObject);

            coinText.text = "Coins: " + coinsCollected;

        }

    }

}
