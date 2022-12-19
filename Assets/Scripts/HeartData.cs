[System.Serializable]
public class HeartData
{
    public HeartColor heartColor;
    public HeartSize heartSize;

    public HeartData(HeartColor heartColor, HeartSize heartSize)
    {
        this.heartColor = heartColor;
        this.heartSize = heartSize;
    }
}
