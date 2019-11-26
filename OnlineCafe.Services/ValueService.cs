using OnlineCafe.Interfaces;
using OnlineCafe.Interfaces.Repository;

namespace OnlineCafe.Services
{
  public class ValueService : IValueService
  {
    private readonly IValueRepository _valueRepository;

    public ValueService(IValueRepository valueRepository)
    {
      _valueRepository = valueRepository;
    }
    public string GetData()
    {
      return _valueRepository.GetValue();
    }

    public string GetValFromRepo()
    {
      return _valueRepository.GetValue();
    }
  }
}
