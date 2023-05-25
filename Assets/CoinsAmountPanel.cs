using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsAmountPanel : MonoBehaviour
{
    public TMP_Text coins;

    private void Update()
    {
        coins.text = EconomyManager.Instance.GetPlayerCoins().ToString();
    }
}
