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
            textBox1.Text =Convert.ToString(pessoa.ConsultarCodigo() + 1);
            textBox1.ReadOnly = true;
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
            pessoa.Deletar(Convert.ToInt32(textBox1.Text));
        }//Fim do botão Deletar

        private void button4_Click(object sender, EventArgs e)
        {
            
            if(textBox2.Text == "")
            {
                maskedTextBox1.Text = "" + pessoa.ConsultarCpf(Convert.ToInt32(textBox1.Text));
                textBox2.Text = pessoa.ConsultarTelefone(Convert.ToInt32(textBox1.Text));
                maskedTextBox2.Text = pessoa.ConsultarNome(Convert.ToInt32(textBox1.Text));
                textBox4.Text = pessoa.ConsultarEndereco(Convert.ToInt32(textBox1.Text));

            }
            else
            {
                pessoa.Atualizar(Convert.ToInt32(textBox1.Text), "CPF", TrataCPF(maskedTextBox1.Text));
                // atualizar Nome
                pessoa.Atualizar(Convert.ToInt32(textBox1.Text), "nome", textBox2.Text);
                //atualizar telefone
                pessoa.Atualizar(Convert.ToInt32(textBox1.Text), "telefone", maskedTextBox2.Text);
                //atualizar endereco
                pessoa.Atualizar(Convert.ToInt32(textBox1.Text), "endereco", textBox4.Text);

               
            }

        }//fim do Atualizar

        public void AtivaCampos()
        { 
          
                textBox1.ReadOnly = false;//Codigo
                maskedTextBox1.ReadOnly = true;//CPF
                textBox2.ReadOnly = true;//nome
                maskedTextBox2.ReadOnly = true;//telefone
                textBox4.ReadOnly = true;//Endereço
         
        }
        public void inativarCompos()
        {

            textBox1.ReadOnly = true;//Codigo
            maskedTextBox1.ReadOnly = false;//CPF
            textBox2.ReadOnly = false;//Nome
            maskedTextBox2.ReadOnly = false;//Telefone
            textBox4.ReadOnly = false;//Endereço

        }
        public void AtivarTodosCampos()
        {
            textBox1.ReadOnly = false;//Codigo
            maskedTextBox1.ReadOnly = false;//CPF
            textBox2.ReadOnly = false;//Nome
            maskedTextBox2.ReadOnly = false;//Telefone
            textBox4.ReadOnly = false;//Endereço

        }

        private void Cadatrar_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.ReadOnly == false)
                {
                    Limpar();                    
                    inativarCompos();
                }
                else
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
 
                Limpar();
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("" + erro);
            }



        }//Fim do botão Cadastrar

        public long TrataCPF(string cpf)
        {
            string tratamento = cpf.Replace(",", "");
            tratamento = tratamento.Replace("-", "");
            return Convert.ToInt64(tratamento);

        }// fim tratamento do Cpf
        public void Limpar()
        {
            textBox1.Text = " " + pessoa.ConsultarCodigo();
            maskedTextBox1.Text = "";//Cpf
            textBox2.Text = "";// nome
            maskedTextBox2.Text = "";//
            textBox4.Text = "";// endereço

            
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            if(textBox1.ReadOnly == true)
            {
                AtivaCampos();

            }
            else 
            { 
                maskedTextBox1.Text = "" + pessoa.ConsultarCpf(Convert.ToInt32(textBox1.Text));
                textBox2.Text = pessoa.ConsultarNome(Convert.ToInt32(textBox1.Text));
                maskedTextBox2.Text = "" + pessoa.ConsultarTelefone(Convert.ToInt32(textBox1.Text));
                textBox4.Text = pessoa.ConsultarEndereco(Convert.ToInt32(textBox1.Text));
            }
           
        }//fim do botão consultar

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
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
