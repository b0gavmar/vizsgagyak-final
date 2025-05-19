using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Player
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public int? Amount { get; set; }

    public Player(string name,  int amount = 0, int? id = null, string? email = null)
    {
        if(string.IsNullOrEmpty(name)) throw new ArgumentException("Hiányzik a név!");
        if (!email.Contains("@") && email!=null) throw new ArgumentException("Nem megfelelő email formátum!");
        this.Name = name;
        this.Email = email;
        this.Amount = amount;
        this.Id = id;
    }

    public Player(int id)
    {
        Id = id;
        Name = null;
        Email = null;
        Amount = null;
    }

    public Player()
    {
        
    }

    public bool HasAmount()
    {
        if (Amount > 0)
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    public int GetAmount()
    {
        if (HasAmount())
        {
            return (int)Amount;
        }
        else
        { 
            return 0; 
        }
    }

    public void AddAmount(int num)
    {
        if (num > 0)
        {
            Amount += num;
        }
        else
        {
            throw new ArgumentException("Az összeg nem lehet negativ");
        }
    }

    public void Fogadas(int num)
    {
        if (HasAmount() && num!>Amount)
        {
                Amount -= num;
        }
        else
        {
            throw new ArgumentException("Nincs elég összeg");
        }
    }

    public override string ToString()
    {
        return $"{Name} - {Amount} - ({Email}) - {Id}";
    }
}
