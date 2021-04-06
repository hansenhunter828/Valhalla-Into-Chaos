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
using System.Media;

namespace Valhalla_Into_Chaos
{
    public partial class Form1 : Form
    {
        #region Variables
        int playerHealth = 100;
        int CPUHealth = 100;

        int healTurn = 0;
        int troopsTurn = 0;
        int concussTurn = 0;

        int botHealTurn = 0;

        bool playerBlocking = false;

        Random ranGen = new Random();
        #region SoundPlayers
        SoundPlayer hurtSound = new SoundPlayer(Properties.Resources.hurtSound);
        SoundPlayer healSound = new SoundPlayer(Properties.Resources.healSound);
        SoundPlayer buttonClickSound = new SoundPlayer(Properties.Resources.buttonClick);
        #endregion
        #endregion
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
            backButton2.Hide();

            quitButton4.Hide();
            replayButton.Hide();

            InfoTextLabel.Text = "";
            playerHealthLabel.Text = "";
            CPUHealthLabel.Text = "";
            gameOverLabel.Text = "";

            playerHealth = 100;
            CPUHealth = 100;

            CPUPictureBox.Show();
            playerPictureBox.Show();
        }
        public void GameStart()
        {
            backButton2.Hide();
            attackButton.Hide();
            defendButton.Hide();
            healButton.Hide();
            escapeButton.Hide();
            mainMenuButton.Hide();
            loreButton.Hide();
            quitButton.Hide();
            quitButton4.Hide();
            replayButton.Hide();
            backButton.Hide();

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
            playerHealthLabel.Text = "";
            CPUHealthLabel.Text = "";

            CPUPictureBox.Hide();
            playerPictureBox.Hide();
        }
        public void GameOver()
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

            playButton.Hide();
            loreButton2.Hide();
            settingButton.Hide();
            quitButton3.Hide();

            playerPictureBox.Hide();
            CPUPictureBox.Hide();

            InfoTextLabel.Text = "";
            playerHealthLabel.Text = "";
            CPUHealthLabel.Text = "";

            quitButton4.Show();
            replayButton.Show();

            if (playerHealth <= 0)
            {
                gameOverLabel.Text += "Game Over!";
                gameOverLabel.Text += "\n\n Loki Defeated You";
            }
            if (CPUHealth <= 0)
            {
                gameOverLabel.Text += "Game Over!";
                gameOverLabel.Text += "\n\n You Defeated Loki";
            }
        }
        public void BotTurn()
        {
            botHealTurn++;
            int botMove = ranGen.Next(1, 101);
            if (playerBlocking == false)
            {
                if (botMove <= 79)
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
                                InfoTextLabel.Text += $"\nLoki throws a weapon at you dealing {throwWeaponDmg} damage.";
                                playerHealth = playerHealth - throwWeaponDmg;

                                hurtSound.Play();
                            }
                            else if (throwWeaponDmg > 15)
                            {
                                InfoTextLabel.Text += $"\nLoki throws a weapon at you penatrating your armor dealing {throwWeaponDmg} damage.";
                                playerHealth = playerHealth - throwWeaponDmg;

                                hurtSound.Play();
                            }
                        }
                        else if (hitChance == 10)
                        {
                            InfoTextLabel.Text += "\nloki throws a weapon and it completely misses you.";
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
                                InfoTextLabel.Text += $"\nLoki commands his draugr army to attack you. They struggle against you and deal {sendTroopsDmg} damage.";
                                playerHealth = playerHealth - sendTroopsDmg;
                                hurtSound.Play();
                            }
                            if (sendTroopsDmg >= 21 && sendTroopsDmg <= 25)
                            {
                                InfoTextLabel.Text += $"\nLoki commands his draugr army to attack you. They succeed against you and deal {sendTroopsDmg} damage.";
                                playerHealth = playerHealth - sendTroopsDmg;
                                hurtSound.Play();
                            }
                            if (sendTroopsDmg >= 26 && sendTroopsDmg <= 30)
                            {
                                InfoTextLabel.Text += $"\nLoki commands his draugr army to attack you. They ravage you and deal {sendTroopsDmg} damage.";
                                playerHealth = playerHealth - sendTroopsDmg;
                                hurtSound.Play();
                            }
                        }
                        else
                        {
                            InfoTextLabel.Text += "\nLoki's army gets lost and cant find you";

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
                                    InfoTextLabel.Text = "\nLoki does a backflip and you drop your jaw in awe. Loki has an opportunity to take an extra move.";
                                    break;
                                case 2:
                                    InfoTextLabel.Text += "\nLoki stats mocking you and you get offended and start telling him off.";
                                    InfoTextLabel.Text += " Loki has an opportunity to take an extra move.";
                                    break;
                                case 3:
                                    InfoTextLabel.Text += "\nLoki tells you a very complex riddle and in the time you are trying to figure it out";
                                    InfoTextLabel.Text += " he gets an opportunity to take an extra move.";
                                    break;
                                case 4:
                                    InfoTextLabel.Text += "\nLoki says there is something on your face and well you are getting it off your face";
                                    InfoTextLabel.Text += " he gets an opportunity to take an extra move.";
                                    break;
                                case 5:
                                    InfoTextLabel.Text += "\nLoki asks you to fill out a questionare and as you work on it.";
                                    InfoTextLabel.Text += " he gets an opportunity to take an extra move.";
                                    break;
                            }
                            BotTurn();
                        }
                        else
                        {
                            InfoTextLabel.Text += "\nLoki attempts to confuse you but fails";
                        }
                    }

                }
                if (botMove >= 80 && botHealTurn % 3 == 0)
                {
                    if (CPUHealth < 100)
                    {
                        int healHealth = ranGen.Next(1, 21);
                        CPUHealth = CPUHealth + healHealth;
                        if (healHealth <= 5)
                        {
                            InfoTextLabel.Text += $"\nLoki drinks a health potion but it is expired. Loki heals {healHealth} health.";
                            healSound.Play();
                        }
                        if (healHealth >= 6 && healHealth <= 10)
                        {
                            InfoTextLabel.Text += $"\nLoki drinks a health potion. Loki heals {healHealth} health.";
                            healSound.Play();
                        }
                        if (healHealth >= 11 && healHealth <= 15)
                        {
                            InfoTextLabel.Text += $"\nLoki drinks a strong health potion. Loki heals {healHealth} health.";
                            healSound.Play();
                        }
                        if (healHealth >= 16 && healHealth <= 20)
                        {
                            InfoTextLabel.Text += $"\nLoki summoms a professional alchemist to create hum the greated health potion." +
                                $" Loki heals {healHealth} health.";
                            healSound.Play();
                        }
                    }
                    if (CPUHealth >= 100)
                    {
                        int overHeal = ranGen.Next(1, 21);
                        CPUHealth = CPUHealth - overHeal;
                        InfoTextLabel.Text += $"Loki drinks a health potions but has to much in his system. Loki takes {overHeal} damage";
                    }

                }
                if (botMove >= 80 && botHealTurn % 3 != 0)
                {
                    InfoTextLabel.Text += "\nLoki tries to heal but he can not find any health potions";
                }

            }
            else if (playerBlocking == true)
            {
                playerBlocking = false;
            }

        }
        public void RefreshHealth()
        {
            playerHealthLabel.Text = $"Health: {playerHealth}";
            CPUHealthLabel.Text = $"Health: {CPUHealth}";
        }
        #region Player Moves
        private void attackButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            throwWeaponButton.Show();
            sendTroopsButton.Show();
            concussButton.Show();
        }//compelete
        private void defendButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            healTurn++;
            troopsTurn++;
            concussTurn++;

            throwWeaponButton.Hide();
            sendTroopsButton.Hide();
            concussButton.Hide();

            playerBlocking = true;

            InfoTextLabel.Text = "Loki attacks you with his weapon but you are ready for him and block his attack";
            RefreshHealth();
        }//compelete
        private void healButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            healTurn++;
            troopsTurn++;
            concussTurn++;
            if (playerHealth < 100 && healTurn % 3 == 0)
            {
                int healHealth = ranGen.Next(1, 21);
                healTurn++;
                troopsTurn++;
                concussTurn++;

                playerHealth = playerHealth + healHealth;
                if (healHealth <= 5)
                {
                    InfoTextLabel.Text = $"\nYou drink a health potion but it is expired. You heal {healHealth} health.";
                    healSound.Play();
                }
                if (healHealth >= 6 && healHealth <= 10)
                {
                    InfoTextLabel.Text = $"\nYou drink a health potion. You heal {healHealth} health.";
                    healSound.Play();
                }
                if (healHealth >= 11 && healHealth <= 15)
                {
                    InfoTextLabel.Text = $"\nYou drink a strong health potion. You heal {healHealth} health.";
                    healSound.Play();
                }
                if (healHealth >= 16 && healHealth <= 20)
                {
                    InfoTextLabel.Text = $"\nYou summom a professional alchemist to create you the greated health potion." +
                        $" You heal {healHealth} health.";
                    healSound.Play();
                }
            }
            else if (playerHealth >= 100)
            {
                int overhealth = ranGen.Next(1, 11);
                InfoTextLabel.Text = $"You try to  drink a health potion but there is to much in your system. Take {overhealth} damage.";
                playerHealth = playerHealth - overhealth;
            }
            else
            {
                InfoTextLabel.Text = "You cant heal yet.";
            }

            if (playerHealth > 100)
            {
                playerHealth = 100;
            }
            RefreshHealth();
            BotTurn();
        }//compelete
        private void escapeButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            GameStart();
        }//compelete
        #region Attacks
        private void throwWeaponButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            int hitChance = ranGen.Next(1, 11);
            healTurn++;
            troopsTurn++;
            concussTurn++;

            if (hitChance <= 9)
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
            }
            else if ( hitChance == 10)
            {
                InfoTextLabel.Text = "You throw your weapon and completely miss him.";
            }

            if (playerHealth <= 0 || CPUHealth <= 0)
            {
                GameOver();
            }
            else
            {
                BotTurn();
            }
            if (playerHealth > 0 && CPUHealth > 0)
            {
                RefreshHealth();
            }


        }//compelete
        private void sendTroopsButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            int sendTroopsHit = ranGen.Next(1, 11);
            healTurn++;
            troopsTurn++;
            concussTurn++;

            if (sendTroopsHit <= 5 && troopsTurn % 3 == 0)
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

            }
            else if (sendTroopsHit >= 6)
            {
                InfoTextLabel.Text = "You command your vikings to attack Loki but they completely miss where he is and are now lost";
            }
            if (playerHealth <= 0 || CPUHealth <= 0)
            {
                GameOver();
            }
            else
            {
                BotTurn();
            }

            RefreshHealth();
        }//compelete
        private void concussButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            healTurn++;
            troopsTurn++;
            concussTurn++;

            int concussRoll = ranGen.Next(1, 11);
            int textRoll = ranGen.Next(1, 6);

            if ( concussRoll <= 8 && concussTurn % 4 == 0)
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
            else if (concussRoll > 8)
            {
                InfoTextLabel.Text = "Your attempt at confusing him has failed";

            }

            if (playerHealth <= 0 || CPUHealth <= 0)
            {
                GameOver();
            }

            RefreshHealth();
        }//compelete
        #endregion
        #endregion
        #region Menu Buttons
        private void loreButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            GameStart();
            attackButton.Hide();
            defendButton.Hide();
            healButton.Hide();
            escapeButton.Hide();
            mainMenuButton.Hide();
            loreButton2.Hide();
            quitButton.Hide();
            playButton.Hide();
            settingButton.Hide();
            quitButton3.Hide();
            backButton2.Show();

            menuLabel.Text = "You as Odin have created this civilization but your family disagrees with your decisions " +
                            "and decided the only way to get the way they want is to kill you and take your place. You must defend your " +
                            "life so your family doesn't create some terrible things and unleash them upon your world.";
        }//not complete
        private void quitButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            quitButton2.Show();
            cancelButton.Show();
        }//compelete
        private void quitButton2_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            Application.Exit();
        }//compelete
        private void cancelButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            quitButton2.Hide();
            cancelButton.Hide();
        }//compelete
        private void playButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            GameSetup();
        }//Complete
        private void loreButton2_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            loreButton2.Hide();
            playButton.Hide();
            settingButton.Hide();
            quitButton3.Hide();
            backButton.Show();
            menuLabel.Text = "You as Odin have created this civilization but your family disagrees with your decisions " +
                "and decided the only way to get the way they want is to kill you and take your place. You must defend your " +
                "life so your family doesn't create some terrible things and unleash them upon your world.";
        }//complete
        private void settingButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            loreButton2.Hide();
            playButton.Hide();
            settingButton.Hide();
            quitButton3.Hide();
            backButton.Show();
            menuLabel.Text = "How to Play:";
            menuLabel.Text += "\n\nDefending will negate all incoming damage";
            menuLabel.Text += "\n\nThere are 3 attacks and can only be used every so many turns";
            menuLabel.Text += "\n\nHealing will heal a random amount of health between 1 and 20 health";
            menuLabel.Text += "\n\nYour goal is to defeat Loki in a turn based combat system";
            menuLabel.Text += "\n\nGood luck and have fun!";

        }//complete
        private void quitButtonTwo_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            Application.Exit();
        }//Complete
        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            GameStart();
        }//Complete
        private void replayButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            GameSetup();
        }//complete
        private void quitButton4_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            Application.Exit();
        }//complete
        private void backButton_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            loreButton2.Show();
            playButton.Show();
            settingButton.Show();
            quitButton3.Show();
            backButton.Hide();
            menuLabel.Text = "";
        }//complete
        private void backButton2_Click(object sender, EventArgs e)
        {
            buttonClickSound.Play();
            attackButton.Show();
            defendButton.Show();
            healButton.Show();
            escapeButton.Show();
            mainMenuButton.Show();
            loreButton.Show();
            quitButton.Show();
            backButton2.Hide();

            playerPictureBox.Show();
            CPUPictureBox.Show();
            menuLabel.Text = "";
        }//complete
        #endregion
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            #region Brushes
            SolidBrush brownBrush = new SolidBrush(Color.SaddleBrown);
            SolidBrush sandyBrownBrush = new SolidBrush(Color.SandyBrown);
            #endregion
            #region Background
            //Outline
            e.Graphics.FillRectangle(brownBrush, 0, 0, 20, 500);
            e.Graphics.FillRectangle(brownBrush, 0, 0, 800, 20);
            e.Graphics.FillRectangle(brownBrush, 762, 0, 20, 500);
            e.Graphics.FillRectangle(brownBrush, 0, 460, 800, 20);
            //Inside
            e.Graphics.FillRectangle(sandyBrownBrush, 20, 20, 745, 440);
            #endregion
        }
    }
}
