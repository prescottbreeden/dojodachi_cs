using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace dojodachi.Models
{
  public class Dojodachi
  {
    public int Happiness { get; set; }
    public int Fullness { get; set; }
    public int Energy { get; set; }
    public int Meals { get; set; }
    public string Image { get; set; }
    public string Status { get; set; }
    public bool IsDead { get; set; }
    public bool MegaDachi { get; set; }

    public Dojodachi()
    {
      Happiness = 20;
      Fullness = 20;
      Energy = 50;
      Meals = 3;
      Image = "~/images/dachi1.png";
      Status = "Dojodachi is functioning within normal parameters.";
    }

    public void Feed()
    {
      if (!IsDead && Meals > 0 && !MegaDachi)
      {
        Random rand = new Random();
        Fullness += rand.Next(5, 10);
        Meals--;
        CheckIfDead();
        UpdateStatus();
      }
    }

    public void Play()
    {
      if (!IsDead && !MegaDachi)
      {
        Random rand = new Random();

        if (rand.Next(1, 5) == 1)
          Status = "Dojodachi doesn't want to play.";

        else
        {
          Happiness += rand.Next(5, 10);
          Energy -= 5;
          CheckIfDead();
          UpdateStatus();
        }
      }
    }

    public void Work()
    {
      if (!IsDead && !MegaDachi)
      {
        Random rand = new Random();
        Meals += rand.Next(1, 3);
        Energy -= 5;
        CheckIfDead();
        UpdateStatus();
      }
    }

    public void Sleep()
    {
      if (!IsDead && !MegaDachi)
      {
        Energy += 15;
        Fullness -= 5;
        Happiness -= 5;
        CheckIfDead();
        UpdateStatus();
      }
    }

    public void CheckIfDead()
    {
      if (Happiness <= 0 || Energy <= 0 || Fullness <= 0)
      {
        Image = "~/images/death.png";
        IsDead = true;
      }
    }

    public void UpdateStatus()
    {
      if (!IsDead)
      {
        IsFeeling();

        if (Meals <= 0)
          Status = "You've run out of meals!";

        if (Fullness >= 100 && Energy >= 100 && Happiness >= 100)
          Win();
      }
      else
      {
        if (Fullness <= 0 && Happiness <= 0)
          Status = "Dojodachi died of depression and starvation. This is why we can't have nice things.";

        else if (Fullness <= 0)
          Status = "Dojodachi starved to death. This is why we can't have nice things.";

        else if (Happiness <= 0)
          Status = "Dojodachi died from depression. This is why we can't have nice things.";

        else if (Energy <= 0)
          Status = "Dojodachi died of exhaustion. This is why we can't have nice things.";
      }
    }

    public void IsFeeling()
    {
      int[] stats = { Fullness, Energy, Happiness };
      int minStat = (from s in stats select s).Min();

      if (Energy == minStat)
        Status = "Dojoadachi is tired.";

      else if (Happiness == minStat)
        Status = "Dojodachi is sad.";

      else Status = "Dojodachi is hungry.";
    }

    public void Win()
    {
      Status = "Congrats! Dojodachi is now MEGA DOJODACHI!!!";
      Image = "~/images/dachi2.png";
      MegaDachi = true;
    }
  }
}