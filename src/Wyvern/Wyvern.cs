using Wyvern.Database;
using Microsoft.AspNetCore;
namespace Wyvern
{
  private WyvernDatabase db;
  public class Wyvern
  {
    public Wyvern()
    {
      
    }
    public Wyvern WithDatabase(WyvernDatabase database)
    {
      this.db = database;
    }
    public void Start()
    {
      
    }
  }
}