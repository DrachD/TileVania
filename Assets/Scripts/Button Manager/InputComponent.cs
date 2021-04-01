using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputComponent : MonoBehaviour
{
    [SerializeField] ButtonManager btnManager;
    [SerializeField] private Text _buttonText; // текст кнопки
    [SerializeField] private string _defaultKeyName; // ключ/имя вызова
    [SerializeField] private KeyCode _defaultKeyCode;
    public KeyCode keyCode { get; set; }
    private IEnumerator coroutine;
    private string tmpKey;
    public Text buttonText { get => _buttonText; }
    public string defaultKeyName { get => _defaultKeyName; }
    public KeyCode defaultKeyCode { get => _defaultKeyCode; }
    private void OnValidate()
    {
        _buttonText.text = _defaultKeyCode.ToString();
        btnManager = GetComponentInParent<ButtonManager>();
        btnManager.RefreshUI();
    }
    private void Start()
    {
        Debug.Log(_defaultKeyCode.ToString());
    }
    // событие кнопки, для перехода в режим ожидания
    public void ButtonSetKey()
    {
        tmpKey = _buttonText.text;
        //_buttonText.text = "???";
        //coroutine = Wait();
        //StartCoroutine(coroutine);
    }
    // IEnumerator Wait()
    // {
    //     while (true)
    //     {
    //         yield return null;

    //         if (Input.GetKeyDown(KeyCode.Escape))
    //         {
    //             _buttonText.text = tmpKey;
    //             StopCoroutine(coroutine);
    //         }

    //         KeyCode key = keyCode;

    //         foreach (KeyCode k in KeyCode.GetValues(typeof(KeyCode)))
    //         {
    //             if (Input.GetKeyDown(k))
    //             {
    //                 keyCode = k;
    //                 _buttonText.text = k.ToString();
    //                 btnManager.RefreshUI();
    //                 StopCoroutine(coroutine);
    //             }
    //         }
    //     }
    // }
}