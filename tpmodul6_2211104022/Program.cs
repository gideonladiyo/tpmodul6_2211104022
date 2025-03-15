public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Random random = new Random();
        // random int 5 digits
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }
    public void IncreasePlayCount(int count)
    {
        playCount += count;
    }
    public void PrintVideoDetail()
    {
        Console.WriteLine($"ID: {id}, Title: {title}, Play count: {playCount}");
    }
}

public class Program
{
    static void Main()
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial design by contract - Gideon Toranawa Ladiyo");
        video.PrintVideoDetail();
    }
}