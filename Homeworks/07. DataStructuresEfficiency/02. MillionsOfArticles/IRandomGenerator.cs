namespace _02.MillionsOfArticles
{
    public interface IRandomGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        double GetRandomDouble(int min, int max);
    }
}