using UnityEngine;
using TMPro;

public class CoinCountView : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TextMeshProUGUI _cointCountText;

    private void Awake()
    {
        _cointCountText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _player.CoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        _player.CoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected(int coinCount)
    {
        _cointCountText.text = coinCount.ToString();
    }
}
