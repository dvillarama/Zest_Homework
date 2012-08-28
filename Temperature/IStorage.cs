
namespace Temperature
{
    public interface IStorage
    {
        FarenheitCount Query(double celsius);
        CelsiusCount[] QueryAll();
    }
}
