using UnityEngine;
using UnityEngine.UI;

public class SubmitExamController : MonoBehaviour
{
    [SerializeField] private Image collectButtonImage;
    [SerializeField] private Image checklistImage;
    [SerializeField] private Sprite interactCollectSprite;
    [SerializeField] private Sprite interactChecklistSprite;
    private Sprite originCollectSprite;
    private Sprite originChecklistSprite;
    private bool isChecked = false;

    private void Start()
    {
        originCollectSprite = collectButtonImage.sprite;
        originChecklistSprite = checklistImage.sprite;
    }

    public void OnChecklist()
    {
        isChecked = !isChecked;
        var interactableCollectButton = collectButtonImage.GetComponent<Button>();
        if (isChecked)
        {
            collectButtonImage.sprite = interactCollectSprite;
            checklistImage.sprite = interactChecklistSprite;
            interactableCollectButton.interactable = true;
        }
        else
        {
            collectButtonImage.sprite = originCollectSprite;
            checklistImage.sprite = originChecklistSprite;
            interactableCollectButton.interactable = false;
        }
    }
}
