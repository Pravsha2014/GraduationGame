using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class WalletText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void ChangeValue(int value)
    {
        _text.text = "Collected coins: " + value.ToString();
    }
}
