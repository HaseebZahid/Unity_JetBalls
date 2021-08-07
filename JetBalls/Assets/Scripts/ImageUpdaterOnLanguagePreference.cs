using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageUpdaterOnLanguagePreference : MonoBehaviour
{
    public bool runInUpdate = false;
    public Sprite[] images;

    // Start is called before the first frame update
    void OnEnable()
    {
        GetComponent<Image>().sprite = images[LanguagePreference.instance.langValue];
        GetComponent<Image>().SetNativeSize();
    }

    private void Update()
    {
        if (runInUpdate)
        {
            GetComponent<Image>().sprite = images[LanguagePreference.instance.langValue];
            GetComponent<Image>().SetNativeSize();
        }
    }
}
