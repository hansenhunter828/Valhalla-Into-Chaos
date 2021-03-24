using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Valhalla_Into_Chaos
{
    public partial class Form1 : Form
    {
        int playerHealth = 100;
        int CPUHealth = 100;
        int healTurn = 3;
        bool isPlayerTurn = true;
        Random ranGen = new Random();
        public Form1()
        {
            InitializeComponent();
            GameStart();
        }
        public void GameSetup()
        {
            attackButton.Show();
            defendButton.Show();
            healButton.Show();
            escapeButton.Show();
            mainMenuButton.Show();
            loreButton.Show();
            quitButton.Show();

            playButton.Hide();
            loreButton2.Hide();
            settingButton.Hide();
            quitButton3.Hide();
        }
        public void GameStart()
        {
            attackButton.Hide();
            defendButton.Hide();
            healButton.Hide();
            escapeButton.Hide();
            mainMenuButton.Hide();
            loreButton.Hide();
            quitButton.Hide();

            throwWeaponButton.Hide();
            sendTroopsButton.Hide();
            concussButton.Hide();

            quitButton2.Hide();
            cancelButton.Hide();

            playButton.Show();
            loreButton2.Show();
            settingButton.Show();
            quitButton3.Show();

            InfoTextLabel.Text = "";
        }
        public void GameOver()
        {

        }
        public void BotTurn()
        {
            int botMove = ranGen.Next(1, 2);
            if (botMove == 1)
            {
                int attackMove = ranGen.Next(1, 4);
                if (attackMove == 1)
                {
                    int hitChance = ranGen.Next(1, 11);
                    if (hitChance <= 9)
                    {
                        int throwWeaponDmg = ranGen.Next(12, 17);
                        if (throwWeaponDmg <= 15)
                        {
                            InfoTextLabel.Text = $"Loki throws a weapon at you dealing {throwWeaponDmg} damage.";
                            playerHealth = playerHealth - throwWeaponDmg;
                            isPlayerTurn = true;
                        }
                        else if (throwWeaponDmg > 15)
                        {
                            InfoTextLabel.Text = $"Loki throws a weapon at you penatrating your armor dealing {throwWeaponDmg} damage.";
                            playerHealth = playerHealth - throwWeaponDmg;
                            isPlayerTurn = true;
                        }
                    }
                    else if (hitChance == 10)
                    {
                        InfoTextLabel.Text = "loki throws a weapon and it completely misses you.";
                    }
                }
                if (attackMove == 2)
                {
                    int sendTroopsHit = ranGen.Next(1, 11);
                    if (sendTroopsHit <= 5)
                    {
                        int sendTroopsDmg = ranGen.Next(17, 31);
                        if (sendTroopsDmg <= 20)
                        {
                            InfoTextLabel.Text = $"You command your viking to attack Loki. They struggle against him and deal {sendTroopsDmg} damage.";
                            playerHealth = playerHealth - sendTroopsDmg;
                        }
                        if (sendTroopsDmg >= 21 && sendTroopsDmg <= 25)
                        {
                            InfoTextLabel.Text = $"You command your viking to attack Loki. They succeed against him and deal {sendTroopsDmg} damage.";
                            playerHealth = playerHealth - sendTroopsDmg;
                        }
                        if (sendTroopsDmg >= 26 && sendTroopsDmg <= 30)
                        {
                            InfoTextLabel.Text = $"You command your viking to attack Loki. They ravage him and deal {sendTroopsDmg} damage.";
                            playerHealth = playerHealth - sendTroopsDmg;
                        }
                    }

                }
                if (attackMove == 3)
                {
                    int concussRoll = ranGen.Next(1, 11);
                    int textRoll = ranGen.Next(1, 6);

                    if (concussRoll <= 8)
                    {
                        switch (textRoll)
                        {
                            case 1:
                                InfoTextLabel.Text = "Loki does a backflip and you drop your jaw in awe. Loki has an opportunity to take an extra move.";
                                break;
                            case 2:
                                InfoTextLabel.Text = "Loki stats mocking you and you get offended and start telling him off.";
                                InfoTextLabel.Text += " Loki has an opportunity to take an extra move.";
                                break;
                            case 3:
                                InfoTextLabel.Text = "Loki tells you a very complex riddle and in the time you are trying yo figure it out";
                                InfoTextLabel.Text += " he gets an opportunity to take an extra move.";
                                break;
                            case 4:
                                InfoTextLabel.Text = "Loki says there is something on your face and well you are getting it off your face";
                                InfoTextLabel.Text += " he gets an opportunity to take an extra move.";
                                break;
                            case 5:
                                InfoTextLabel.Text = " Loki asks you to fill out a questionare and as you work on it.";
                                InfoTextLabel.Text += " he gets an opportunity to take an extra move.";
                                break;
                        }
                        BotTurn();
                    }
                }
               
            }
            if (botMove == 2)
            {

            }
            if (botMove == 3)
            {

            }
            isPlayerTurn = true;
        }
        public void RefreshHealth()
        {
            playerHealthLabel.Text = $"{playerHealth}";
            CPUHealthLabel.Text = $"{CPUHealth}";
        }
        #region Player Moves
        private void attackButton_Click(object sender, EventArgs e)
        {
            throwWeaponButton.Show();
            sendTroopsButton.Show();
            concussButton.Show();
        }//compelete

        private void defendButton_Click(object sender, EventArgs e)
        {
            throwWeaponButton.Hide();
            sendTroopsButton.Hide();
            concussButton.Hide();

            InfoTextLabel.Text = "Loki attacks you with his weapon but you are ready for him and block his attack";
            RefreshHealth();
        }//compelete
       
        private void healButton_Click(object sender, EventArgs e)
        {
            if (isPlayerTurn = true && playerHealth < 100 && healTurn == 3)
            {
                int healHealth = ranGen.Next(1, 21);
                healTurn++;

                playerHealth = playerHealth + healHealth;
                if (healHealth <= 5)
                {
                    InfoTextLabel.Text += $"\nYou drink a health potion but it is expired. You heal {healHealth} health.";
                }
                if (healHealth >= 6 && healHealth <= 10)
                {
                    InfoTextLabel.Text += $"\nYou drink a health potion. You heal {healHealth} health.";
                }
                if (healHealth >= 11 && healHealth <= 15)
                {
                    InfoTextLabel.Text += $"\nYou drink a strong health potion. You heal {healHealth} health.";
                }
                if (healHealth >= 16 && healHealth <= 20)
                {
                    InfoTextLabel.Text += $"\nYou summom a professional alchemist to create you the greated health potion." +
                        $" You heal {healHealth} health.";
                }
                isPlayerTurn = false;
            }
            else if (isPlayerTurn == true)
            {
                int overhealth = ranGen.Next(1, 11);
                InfoTextLabel.Text = $"You try to  drink a health potion but there is to much in your system. Take {overhealth} damage.";
            }
            else if (isPlayerTurn == false)
            {
                InfoTextLabel.Text = "It is not your turn";
            }

            if (playerHealth > 100)
            {
                playerHealth = 100;
            }
            RefreshHealth();
        }//compelete

        private void escapeButton_Click(object sender, EventArgs e)
        {

        }//compelete
        #region Attacks
        private void throwWeaponButton_Click(object sender, EventArgs e)
        {
            int hitChance = ranGen.Next(1, 11);

            if (isPlayerTurn == true && hitChance <= 9)
            {
                int throwWeaponDmg = ranGen.Next(12, 17);
                CPUHealth = CPUHealth - throwWeaponDmg;

                if (throwWeaponDmg <= 15)
                {
                    InfoTextLabel.Text = $"You throw your weapon at Loki dealing {throwWeaponDmg} damage.";
                }
                else if (throwWeaponDmg > 15)
                {
                    InfoTextLabel.Text = $"You throw your weapon at Loki penatrating his armor dealing {throwWeaponDmg} damage.";
                }
                isPlayerTurn = false;
            }
            else if (isPlayerTurn = true && hitChance == 10)
            {
                InfoTextLabel.Text = "You throw your weapon and completely miss him.";
                isPlayerTurn = false;
            }
            else if(isPlayerTurn == false)
            {
                InfoTextLabel.Text = "It is not your turn";
            }

            if (isPlayerTurn == false && playerHealth <= 0 || CPUHealth <= 0)
            {
                GameOver();
            }
            else
            {
                BotTurn();
            }
            Thread.Sleep(1000);
            RefreshHealth();

        }//compelete

        private void sendTroopsButton_Click(object sender, EventArgs e)
        {
            int sendTroopsHit = ranGen.Next(1, 11);

            if (isPlayerTurn == true && sendTroopsHit <= 5)
            {
                int sendTroopsDmg = ranGen.Next(17, 31);
                if (sendTroopsDmg <= 20)
                {
                    InfoTextLabel.Text = $"You command your viking to attack Loki. They struggle against him and deal {sendTroopsDmg} damage.";
                }
                if (sendTroopsDmg >= 21 && sendTroopsDmg <= 25)
                {
                    InfoTextLabel.Text = $"You command your viking to attack Loki. They succeed against him and deal {sendTroopsDmg} damage.";
                }
                if (sendTroopsDmg >= 26 && sendTroopsDmg <= 30)
                {
                    InfoTextLabel.Text = $"You command your viking to attack Loki. They ravage him and deal {sendTroopsDmg} damage.";
                }
                CPUHealth = CPUHealth - sendTroopsDmg;
                isPlayerTurn = false;
            }
            else if (isPlayerTurn = true && sendTroopsHit >= 6)
            {
                InfoTextLabel.Text = "You command your vikings to attack Loki but they completely miss where he is and are now lost";
                isPlayerTurn = false;
            }
            else if (isPlayerTurn == false)
            {
                InfoTextLabel.Text = "It is not your turn";
            }

            if (isPlayerTurn == false && playerHealth <= 0 || CPUHealth <= 0)
            {
                GameOver();
            }
            else
            {
                BotTurn();
            }
            Thread.Sleep(1000);
            RefreshHealth();
        }//compelete

        private void concussButton_Click(object sender, EventArgs e)
        {
            int concussRoll = ranGen.Next(1, 11);
            int textRoll = ranGen.Next(1, 6);

            if (isPlayerTurn = true && concussRoll <= 8)
            {
                switch (textRoll)
                {
                    case 1:
                        InfoTextLabel.Text = "You bamboolze loki with a magic trick. You have an opportunity to take an extra move.";
                        break;
                    case 2:
                        InfoTextLabel.Text = "You pretend that you have died Loki starts laughing as you stand back up he stares in shock.";
                        InfoTextLabel.Text += " You have an opportunity to take an extra move.";
                        break;
                    case 3:
                        InfoTextLabel.Text = "You pull up a black board and start teaching a very boring math lesson. Loki falls asleep";
                        InfoTextLabel.Text += " You have an opportunity to take an extra move.";
                        break;
                    case 4:
                        InfoTextLabel.Text = "You point off in a direction and say wow whats that. Loki looks to where you are pointing";
                        InfoTextLabel.Text += " You have an opportunity to take an extra move.";
                        break;
                    case 5:
                        InfoTextLabel.Text = " You throw a flash bang and blind Loki. You have an opportunity to take an extra move.";
                        break;
                }
            }
            else if (isPlayerTurn = true && concussRoll > 8)
            {
                InfoTextLabel.Text = "Your attempt at confusing him has failed";
                isPlayerTurn = false;
            }

            if (isPlayerTurn == false && playerHealth <= 0 || CPUHealth <= 0)
            {
                GameOver();
            }
            else if(isPlayerTurn == false)
            {
                BotTurn();
            }
            RefreshHealth();
        }//compelete
        #endregion
        #endregion
        #region Menu Buttons
        private void loreButton_Click(object sender, EventArgs e)
        {

        }//not complete

        private void quitButton_Click(object sender, EventArgs e)
        {
            quitButton2.Show();
            cancelButton.Show();
        }//compelete

        private void quitButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//compelete

        private void cancelButton_Click(object sender, EventArgs e)
        {
            quitButton2.Hide();
            cancelButton.Hide();
        }//compelete

        private void playButton_Click(object sender, EventArgs e)
        {
            GameSetup();
        }//Complete

        private void loreButton2_Click(object sender, EventArgs e)
        {

        }//not complete

        private void settingButton_Click(object sender, EventArgs e)
        {

        }//not complete

        private void quitButtonTwo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//Complete

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            GameStart();
        }//Complete
        #endregion

    }
}
