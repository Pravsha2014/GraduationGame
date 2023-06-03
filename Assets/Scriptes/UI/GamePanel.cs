using System;
using TMPro;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _countdownText;
    [SerializeField] private TMP_Text _endText;
    [SerializeField] private TMP_Text _walletText;
 
    private readonly int _numbersAfterPoint = 2;
    private readonly string _lifeTimeText = "LifeTime: ";
    private float _lifeTime;
    private bool _isCountdownRunning;

    private void OnEnable()
    {
        _isCountdownRunning = true;
        _lifeTime = 0;
        _countdownText.text = _lifeTimeText + GetStringRoundedLifeTime();
    }

    private void Update()
    {
        if (_isCountdownRunning)
        {
            _lifeTime += Time.deltaTime;
            _countdownText.text = _lifeTimeText + GetStringRoundedLifeTime();
        }
    }

    public void StopÑountdown()
    {
        _isCountdownRunning = false;
    }

    public void ShowResult()
    {
        _endText.text = "Game Over\nYour total lifetime: " + GetStringRoundedLifeTime() + "\nYou were able to collect coins: " + _walletText.text;
    }

    private string GetStringRoundedLifeTime() => Math.Round(_lifeTime, _numbersAfterPoint).ToString();
}
