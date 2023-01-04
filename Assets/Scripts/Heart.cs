[System.Serializable]
public class Heart
{
    public HeartColor heartColor;
    public HeartSize heartSize;

    public Heart(HeartColor heartColor, HeartSize heartSize)
    {
        this.heartColor = heartColor;
        this.heartSize = heartSize;
    }
}
