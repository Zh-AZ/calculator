using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    public GameObject FirstScreen;
    public GameObject SecondScreen;

    private GameObject _currentScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        FirstScreen.SetActive(true);
        _currentScreen = FirstScreen;
    }

    public void SwitchState(GameObject state)
    {
        if (_currentScreen != null)
        {
            _currentScreen.SetActive(false);
            state.SetActive(true);
            _currentScreen = state;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
