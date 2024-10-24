using System;

namespace JOGO_DA_MEMORIA
{
    public partial class Form1 : Form

    {
        // Objeto Random para gerar números aleatórios
        Random random = new Random();
        List<string> icons = new List<string>()
            {

             "!", "!", "N", "N", ",", ",", "k", "k",
             "b", "b", "v", "v", "w", "w", "z", "z"

              };

        Label firstClicked = null;
        Label secondClicked = null;

        public Form1()
        {
            InitializeComponent();
            // Atribui os ícones aleatoriamente às labels na interface
            AssignIconsToSquares();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private void AssignIconsToSquares()
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                return;
            }


            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {

                if (clickedLabel.ForeColor == Color.Black)
                    return;

            }

            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.Black;

                return;
            }
            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            if (firstClicked.Text == secondClicked.Text)

            {
                firstClicked = null;
                secondClicked = null;
                CheckForWinner();
                return;
            }

            timer1.Start();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;

            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }
        
        private void CheckForWinner()
        {
            
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            
            MessageBox.Show("Todos os itens foram combinados");
        }
    }
}

