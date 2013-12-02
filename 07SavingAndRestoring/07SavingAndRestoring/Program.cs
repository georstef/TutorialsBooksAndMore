using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07SavingAndRestoring
{
  public interface IAccount { 
    void PayInFunds(decimal amount); 
    bool WithdrawFunds(decimal amount); 
    decimal GetBalance(); 
    string GetName(); 
  }

  public class CustomerAccount : IAccount
  {
    private decimal balance = 0;
    private string name;

    public CustomerAccount(string newName, decimal initialBalance)
    {
      name = newName;
      balance = initialBalance;
    }

    public virtual bool WithdrawFunds(decimal amount)
    {
      if (balance < amount)
      {
        return false;
      }
      balance = balance - amount;
      return true;
    }

    public void PayInFunds(decimal amount)
    {
      balance = balance + amount;
    }

    public decimal GetBalance()
    {
      return balance;
    }

    public string GetName()
    {
      return name;
    }

    // --------------------------------
    public bool Save(string filename)
    {
      System.IO.TextWriter textOut = null;
      try { 
        textOut = new System.IO.StreamWriter(filename);
        Save(textOut);
      } 
      catch { 
        return false; 
      } 
      finally {
        if (textOut != null) {
          textOut.Close();
        }
      }
      return true; 
    }

    public void Save(System.IO.TextWriter textOut) { 
      textOut.WriteLine(name); 
      textOut.WriteLine(balance); 
    }
    // --------------------------------
    public static CustomerAccount Load(string filename) { 
      CustomerAccount result = null; 
      System.IO.TextReader textIn = null; 
      try { 
        textIn = new System.IO.StreamReader(filename); 
        string nameText = textIn.ReadLine(); 
        string balanceText = textIn.ReadLine(); 
        decimal balance = decimal.Parse(balanceText); 
        result = new CustomerAccount(nameText, balance); 
      } 
      catch { 
        return null; 
      } 
      finally {
        if (textIn != null) {
          textIn.Close();
        }
      } 
      return result; 
    }

    public static CustomerAccount Load(System.IO.TextReader textIn) { 
      CustomerAccount result = null; 
      try { 
        string name = textIn.ReadLine(); 
        string balanceText = textIn.ReadLine(); 
        decimal balance = decimal.Parse(balanceText); 
        result = new CustomerAccount(name, balance); 
      } 
      catch { 
        return null; 
      } 
      return result; 
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
    }
/*
    public void Save(System.IO.TextWriter textOut) 
    { 
      textOut.WriteLine(bankHashtable.Count); 
      foreach (CustomerAccount account in bankHashtable.Values) 
      { 
        account.Save(textOut); 
      } 
    }

    public static HashBank Load(System.IO.TextReader textIn) 
    { 
      HashBank result = new HashBank(); 
      string countString = textIn.ReadLine(); 
      int count = int.Parse(countString); 
      for (int i = 0; i < count; i++) 
      { 
        CustomerAccount account = CustomerAccount.Load(textIn); 
        result.bankHashtable.Add(account.GetName(), account); 
      } 
      return result; 
    }
*/
  }
}
