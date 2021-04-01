using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AchivementPanel : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text _name;
    [SerializeField] private Text _description;

    private Sprite Icon { get => image.sprite; set => image.sprite = value; }
    private string Name { get => _name.text; set => _name.text = value; }
    private  string Description { get => _description.text; set => _description.text = value; }
    private Queue<Achivement> queueAchivements = new Queue<Achivement>();
    private void Awake()
    {
        AchivementManager.Instance.OnActivateAchivementEvent += ActivateAchivement;
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        StartCoroutine(TemporaryDisplay());
    }
    public void ActivateAchivement(Achivement achivement)
    {
        queueAchivements.Enqueue(achivement);

        gameObject.SetActive(true);
    }
    private IEnumerator TemporaryDisplay()
    {
        while (queueAchivements.Count > 0)
        {
            Achivement ach = queueAchivements.Dequeue();
            Name = ach.Name;
            Icon = ach.Icon;
            Description = ach.Description;
            AudioPlay();

            yield return new WaitForSeconds(4f);
        }

        gameObject.SetActive(false);
    }
    private void AudioPlay()
    {
        ManagerSFX.Instance.AudioPlayAchivement();
    }
}
