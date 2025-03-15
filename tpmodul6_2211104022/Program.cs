using System.Diagnostics;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Debug.Assert(!string.IsNullOrEmpty(title), "Judul tidak boleh null atau kosong");
        Debug.Assert(title.Length <= 100, "Judul maksimal 200 karakter");

        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException("Judul tidak boleh null atau kosong");
        }

        if (title.Length > 100)
        {
            throw new ArgumentException("Judul maksimal 200 karakter");
        }

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }
    public void IncreasePlayCount(int count)
    {
        if (count < 0)
        {
            throw new ArgumentException("Penambahan count tidak boleh negatif");
        }
        if (count > 10000000)
        {
            throw new ArgumentException("Penambahan play count maksimal 10.000.000 per panggilan");
        }
        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Play count mengalami overflow!");
        }
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
        try
        {
            SayaTubeVideo video = new SayaTubeVideo("Tutorial design by contract - Gideon Toranawa Ladiyo");
            video.PrintVideoDetail();

            for (int i = 0; i < 100; i++)
            {
                video.IncreasePlayCount(10000001);
            }

            video.PrintVideoDetail();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
        }
    }
}