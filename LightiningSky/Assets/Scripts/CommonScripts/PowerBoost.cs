using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBoost : MonoBehaviour
{
    public GameObject m_normalShooting;
    public GameObject m_powerShooting;
    public Button m_powerButton;

    private void Start()
    {
        m_normalShooting.SetActive(true);
        m_powerShooting.SetActive(false);
    }

    public void PowerBoostEnable(Button powerup)
    {
        powerup.interactable = false;
        m_normalShooting.SetActive(false);
        m_powerShooting.SetActive(true);
    }
}
