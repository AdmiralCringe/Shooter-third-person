using TMPro;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest[] quest;
    public int currentQuest;

    private string currentTittle;
    private string currentDescription;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public GameObject dialogPanel;
    private bool dialogActive;
}
