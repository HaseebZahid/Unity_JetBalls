using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageUpdaterOnLanguagePreference : MonoBehaviour
{
    public Sprite[] images;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = images[LanguagePreference.instance.langValue];
    }
}
