using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRegister : MonoBehaviour
{

    void Start()
    {
        TextMeshProUGUI textForRegistration = GetComponent<TextMeshProUGUI>();
        EndGameManager.endManager.RegisterScoreText(textForRegistration);
        textForRegistration.text = "Score: 0";
    }


}
