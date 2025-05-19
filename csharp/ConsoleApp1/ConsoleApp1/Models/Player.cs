using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Player
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public int Amount { get; set; }

    public Player(string name, string email, int amount = 0, int? id = null)
    {
        if(string.IsNullOrEmpty(name)) throw new ArgumentException("Hiányzik a név!");
        if(string.IsNullOrEmpty(email)) throw new ArgumentException("Hiányzik az email!");
        if (!email.Contains("@")) throw new ArgumentException("Nem megfelelő email formátum!");
        this.Name = name;
        this.Email = email;
        this.Amount = amount;
        this.Id = id;
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
}
