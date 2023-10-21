using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    public Slider hungerBar;
    public int totalHunger;
    public int curHunger;

    // Start is called before the first frame update
    void Start()
    {
        curHunger = 0;
        hungerBar.maxValue = totalHunger;
        hungerBar.value = curHunger;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool FeedAnimal(int amount)
    {
        curHunger += amount;
        hungerBar.value = curHunger;

        if (curHunger >= totalHunger)
        {
            curHunger = totalHunger;
            //FIXME: GameManger
            var score = GameObject.Find("Human").GetComponent<HumanController>().score += 1;
            Debug.Log("Score: " + score);
            return true;
        }
        return false;
    }
}
