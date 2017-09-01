using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RandomImage();
                SetWinnings();
            }
            
        }

        int money, bet, reelValue;

        public void SetWinnings()
        {
            money = 100;
            moneyLabel.Text = money.ToString();
        }

        public void RandomImage()
        {
            string[] imgURLs = new string[] {"/images/Bar.png", "/images/Bell.png", "/images/Cherry.png", "/images/Clover.png",
            "/images/Diamond.png", "/images/HorseShoe.png", "/images/Lemon.png", "/images/Orange.png", "/images/Plum.png",
            "/images/Seven.png", "/images/Strawberry.png", "/images/Watermellon.png" };

            Random randomImage = new Random();
            reelsImageMap1.ImageUrl = imgURLs[randomImage.Next(0, 11)];
            reelsImageMap2.ImageUrl = imgURLs[randomImage.Next(0, 11)];
            reelsImageMap3.ImageUrl = imgURLs[randomImage.Next(0, 11)];
        }

        protected void leverButton_Click(object sender, EventArgs e)
        {
            string betBox = betTextBox.Text;

            bool betBoxResult = int.TryParse(betBox, out bet);
            
            if (betBoxResult)
            {
                bet = int.Parse(betBox);
                money = int.Parse(moneyLabel.Text);
                money = money - bet;
                moneyLabel.Text = money.ToString();

                RandomImage();
                CalcReelValue();
                WinOrLose();

                bet = bet * reelValue;
                money = money + bet;

                moneyLabel.Text = money.ToString();
                betTextBox.Text = "";
                return;
            }
            else return;
        }

        public void CalcReelValue()
        {
            if (reelsImageMap1.ImageUrl == "/images/Bar.png" ||
                reelsImageMap2.ImageUrl == "/images/Bar.png" ||
                reelsImageMap3.ImageUrl == "/images/Bar.png")
            {
                reelValue = 0;
                return;
            }
            else if (reelsImageMap1.ImageUrl == "/images/Seven.png" &&
                reelsImageMap2.ImageUrl == "/images/Seven.png" &&
                reelsImageMap3.ImageUrl == "/images/Seven.png")
            {
                reelValue = 100;
                return;
            }
            else if (reelsImageMap1.ImageUrl == "/images/Cherry.png" ||
                reelsImageMap2.ImageUrl == "/images/Cherry.png" ||
                reelsImageMap3.ImageUrl == "/images/Cherry.png")
            {
                reelValue = 2;
                return;
            } 
            else if ((reelsImageMap1.ImageUrl == "/images/Cherry.png" && reelsImageMap2.ImageUrl == "/images/Cherry.png") ||
                (reelsImageMap1.ImageUrl == "/images/Cherry.png" && reelsImageMap3.ImageUrl == "/images/Cherry.png") ||
                reelsImageMap2.ImageUrl == "/images/Cherry.png" && reelsImageMap3.ImageUrl == "/images/Cherry.png")
            {
                reelValue = 3;
                return;
            }  
            else if (reelsImageMap1.ImageUrl == "/images/Cherry.png" &&
                reelsImageMap2.ImageUrl == "/images/Cherry.png" &&
                reelsImageMap3.ImageUrl == "/images/Cherry.png")
            {
                reelValue = 4;
                return;
            }
                
            else reelValue = 0;
        }

        public void WinOrLose()
        {
            if (reelValue == 0)
            {
                winOrLoseLabel.Text = "Sorry, you lost $" + bet + ". Better luck next time!";
                return;
            }
            else
            {
                winOrLoseLabel.Text = "You bet $" + bet + " and won $" + (bet = bet * reelValue) + "!";
                return;
            }
        }
    }
}