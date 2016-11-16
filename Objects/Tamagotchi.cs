using System.Collections.Generic;
using System;

namespace Pet.Objects
{
  public class Tamagotchi
  {
    private string _name;
    private int _hunger;
    private int _boredom;
    private int _rest;
    private int _id;
    private static List<Tamagotchi> _instances = new List<Tamagotchi>{};

    public bool Check()
    {
      if (_hunger <= 0 || _boredom <=0 || _rest <=0)
      {
        return true;
      }
      else {
        return false;
      }
    }

    public Tamagotchi(string name)
    {
      _name = name;
      _hunger = 10;
      _boredom = 10;
      _rest = 10;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public void SetName(string name)
    {
      _name = name;
    }
    public string GetName()
    {
      return _name;
    }

    public void SetHunger()
    {
        _hunger++;
        _boredom--;
        _rest--;
    }
    public int GetHunger()
    {
      return _hunger;
    }

    public void SetBoredom()
    {
      _boredom++;
      _hunger--;
      _rest--;
    }
    public int GetBoredom()
    {
      return _boredom;
    }

    public void SetRest()
    {
      _rest++;
      _hunger--;
      _boredom--;
    }
    public int GetRest()
    {
      return _rest;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Tamagotchi> GetAll()
    {
      return _instances;
    }

    public static Tamagotchi Find(int searchId)
    {
      return _instances[searchId - 1];
    }
  }
}
