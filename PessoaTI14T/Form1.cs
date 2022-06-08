using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PessoaTI14T
{
    public partial class Form1 : Form
    {

        DAOPessoa pessoa;
        public Form1()
        {
            InitializeComponent();
            pessoa = new DAOPessoa();// Abrindo a conexão com o banco de dados
        }// fim do construtor

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }//Fim do botão Deletar

        private void button4_Click(object sender, EventArgs e)
        {

        }//fim do Atualizar

        private void Cadatrar_Click(object sender, EventArgs e)
        {
            try
            {
                //int codigo = Convert.ToInt32(textBox1.Text);// coletar o campo
                string tratamentoCPF = maskedTextBox1.Text.Replace(",", "");
                tratamentoCPF = tratamentoCPF.Replace("-", "");
                long cpf = Convert.ToInt64(tratamentoCPF);// coletar o campo cpf
                string nome = textBox2.Text;// coletar o campo
                string telefone = maskedTextBox2.Text;// coletar o campo
                string edereco = textBox4.Text;// coletar o campo
                // chamar o metodo inserir 
                pessoa.Inserir(cpf, nome, telefone, edereco);//Imserir no banco de dados do formulario
            }
            catch (Exception erro)
            {

                MessageBox.Show("" + erro);
            }



        }//Fim do botão Cadastrar

        private void Consultar_Click(object sender, EventArgs e)
        {

            maskedTextBox1.Text = "" + pessoa.ConsultarCpf(Convert.ToInt32(textBox1.Text));
            textBox2.Text = pessoa.ConsultarNome(Convert.ToInt32(textBox1.Text));
            maskedTextBox2.Text = "" + pessoa.ConsultarTelefone(Convert.ToInt32(textBox1.Text));
            textBox4.Text = pessoa.ConsultarEndereco(Convert.ToInt32(textBox1.Text));

        }//fim do botão consultar

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim textBox Codigo

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }// maskedTextBox CPF

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }// TextBox Nome

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//MaskedTextBox Telefone

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//TextBox Endereço
    }// Fim da classe 
}//Fim do projeto
