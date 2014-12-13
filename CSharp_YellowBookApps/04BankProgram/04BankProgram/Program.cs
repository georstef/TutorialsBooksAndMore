using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainNameSpace
{
  struct A { public string Name;}
  enum AccountState { New, Active, UnderAudit, Frozen, Closed }
  /*
   * struct Account
  {
    public AccountState State;
    public string Name;
    public string Address;
    public int AccountNumber;
    public int Balance;
    public int Overdraft;
  }
*/
  //****************************
  //interface
  //****************************
  public interface IAccount
  {
    void PayInFunds(decimal amount);
    bool WithdrawFunds(decimal amount);
    decimal GetBalance();
    string RudeLetterString();
  }

  //****************************
  //abstract class
  //****************************
  public abstract class Account : IAccount
  { 
    //private (not visible in childs)
    private decimal balance = 0; 
    
    //abstract
    public abstract string RudeLetterString(); 

    //virtual
    public virtual bool WithdrawFunds(decimal amount) 
    { 
      if (balance < amount) 
      { 
        return false; 
      } 
      balance = balance - amount; 
      return true; 
    } 
    
    //normal method (cannot be overriden)
    public decimal GetBalance() 
    { 
      return balance; 
    }

    //normal method (cannot be overriden)
    public void PayInFunds(decimal amount) 
    { 
      balance = balance + amount; 
    } 
  }//end abstract

  //****************************
  //normal class 1
  //****************************
  public class CustomerAccount : Account 
  {
    //override (abstract)
    public override string RudeLetterString() 
    { 
      return "You are overdrawn"; 
    } 
  }//end class

  //****************************
  //normal class 2
  //****************************
  public class BabyAccount : Account 
  { 
    //override (virtual)
    public override bool WithdrawFunds(decimal amount) 
    { 
      if (amount > 10) 
      { 
        return false; 
      } 
      return base.WithdrawFunds(amount); 
    }

    //override (abstract)
    public override string RudeLetterString() 
    { 
      return "Tell daddy you are overdrawn"; 
    } 
  }//end class

  class Program
  {
    static void Main(string[] args)
    {
      /*
      foreach (int state in Enum.GetValues(typeof(AccountState)))
      {
        Console.WriteLine(Enum.GetName(typeof(AccountState), state));
      }
      */
      A dd;
      dd.Name = "takis";
      Console.WriteLine(dd.Name);

      A gg;
      gg = dd;
      gg.Name = "soula";
      Console.WriteLine(gg.Name);
      Console.WriteLine(dd.Name);

      Console.ReadKey();
    }
  }
}
