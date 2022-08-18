using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrderController : MonoBehaviour
{
    [SerializeField] Transform finishLine;

    public List<GameObject> aiList;
    

    private void Start()
    {
        var a = FindObjectsOfType<AIMovement>();

        for (int i = 0; i < a.Length; i++)
        {
            aiList.Add(a[i].gameObject);
        }
        aiList.Add(FindObjectOfType<PlayerController>().gameObject);

    }

    private void Update()
    {
        if (GameController.Instance.GetLevelState == LevelState.Paint  || GameController.Instance.GameState == GameState.Victory) return;

        List<GameObject> newAiList = aiList.OrderBy(x => Vector3.Distance(x.transform.position, finishLine.position)).ToList();

        UIController.Instance.firstPlayer.text = $" 1. {newAiList[0].name}";
        UIController.Instance.secondPlayer.text = $" 2. {newAiList[1].name}";
        UIController.Instance.thirdPlayer.text = $" 3. {newAiList[2].name}";
        UIController.Instance.fourthPlayer.text = $" 4. {newAiList[3].name}";
        UIController.Instance.fiftPlayer.text = $" 5. {newAiList[4].name}";
        UIController.Instance.sixtPlayer.text = $" 6. {newAiList[5].name}";
        UIController.Instance.seventhPlayer.text = $" 7. {newAiList[6].name}";
        UIController.Instance.eighthPlayer.text = $" 8. {newAiList[7].name}";
        UIController.Instance.ninthPlayer.text = $" 9. {newAiList[8].name}";
        UIController.Instance.tenthPlayer.text = $" 10. {newAiList[9].name}";
        UIController.Instance.eleventhPlayer.text = $" 11. {newAiList[10].name}";

    }
}
