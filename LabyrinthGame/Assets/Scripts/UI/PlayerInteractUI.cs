using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    private GameData gameData;
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private TextMeshProUGUI doorText;
    [SerializeField] private GameObject containerDoorTextGameObject; 

    private void Update()
    {
        gameData = SaveSystem.Load();

        var interactableObjects = PlayerInteract.Instance.GetInteractableObject();

        if (interactableObjects.Item1 != null || interactableObjects.Item2 != null)
        {
            Show();
        }
        else
        {
            Hide();
        }

        if (interactableObjects.Item2 != null)
        {
            UpdateDoorText();
            ShowDoorText();
        }
        else
        {
            HideDoorText();
        }
    }
    private void Show()
    {
        containerGameObject.SetActive(true);
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
    }

    private void UpdateDoorText()
    {
        doorText.text = "Find " + (5 - gameData.totalKeys).ToString() + " keys";
    }

    private void ShowDoorText()
    {
        containerDoorTextGameObject.SetActive(true);
    }

    private void HideDoorText()
    {
        containerDoorTextGameObject.SetActive(false);
    }
}
