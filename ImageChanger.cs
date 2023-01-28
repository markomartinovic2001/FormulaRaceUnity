using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Image imageToChange;
    public Sprite[] sprites;
    public int currentSpriteIndex = 0;
    public int tracksIndex = 0;
    public GameObject firstTrack;
    public GameObject[] tracks;

    public void ChangeImageNext()
    {
        currentSpriteIndex++;
        if (currentSpriteIndex >= sprites.Length)
        {
            currentSpriteIndex = 0;
        }
        imageToChange.sprite = sprites[currentSpriteIndex];
    }
    public void ChangeImagePrevious()
    {
        if (currentSpriteIndex <= 0)
        {
            currentSpriteIndex = sprites.Length - 1;
        }
        else
        {
            currentSpriteIndex -= 1;
        }
        imageToChange.sprite = sprites[currentSpriteIndex];
    }
        public void PickTrack()
    {
        var trackPicked = Instantiate(tracks[currentSpriteIndex]);
    }
}