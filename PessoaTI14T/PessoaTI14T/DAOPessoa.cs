using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PessoaTI14T
{
    class DAOPessoa
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public string resultado;
        public int contador;
        public string msg;
        public int i;
        public int[] vetorCodigo;// vetor Codigo
        public long[] vetorCpf;// vetor CPF
        public string[] vetorNome;// vetor nome
        public string[] vetorTelefone;// vetor telefone
        public string[] vetorEndereco;// vetor endereço
        public int contarcodigo;

        public DAOPessoa()
        {
            conexao = new MySqlConnection("server=localhost;dataBase=turma14t;Uid=root;password=;");
            try
            {
                conexao.Open();
              
            }
            catch (Exception e)
            {
                 MessageBox.Show(" algo deu errado\n\n " + e);// mostra o erro em tela
                conexao.Close();// fecha a conexão com banco de dados 
            }

        }// fim do DAOPessoa

        public void Inserir(long cpf, string nome, string telefone, string edereco)
        {
            try
            {
                dados = "('', '" + cpf + "', '" + nome + "', '" + telefone + "', '" + edereco + "')";
                comando = "Insert into PessoaTI14T(codigo, cpf, nome, telefone, edereco) values " + dados;

                MySqlCommand sql = new MySqlCommand(comando, conexao);
                resultado = " " + sql.ExecuteNonQuery();// Executa o insert no BD

                if( resultado == "1") 
                { 
                    MessageBox.Show(resultado + " Cadastrado com sucesso ");
                }
                else
                {
                    MessageBox.Show(resultado + " Não Cadastrado  ");
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(" algo deu errado\n\n " + e);

            }

        }// Fim do método inserir

        public void Preenchervetor()
        {
            string query = " select * from PessoaTI14T ";
            // instanciar
            vetorCodigo = new int[100];
            vetorCpf = new long[100];
            vetorNome = new string[100];
            vetorTelefone = new string[100];
            vetorEndereco = new string[100];
            
            //preencher com valores inciciais 
            for (i = 0; i < 100; i++)
            {
                vetorCodigo[i] = 0;
                vetorCpf[i] = 0;
                vetorNome[i] = "";
                vetorTelefone[i] = "";
                vetorEndereco[i] = "";
                

            }//fim do for
             //Creando o consulta do BD-Banco de dados 

            MySqlCommand coletar = new MySqlCommand(query, conexao);

            //Leitura do banco de dados 

            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contarcodigo = 0;
            contador = 0;

            //Preencher os valores com dados do banco de dados

            while (leitura.Read())//Enquanto For verdadeiro, executa o que esta no While
            {
                vetorCodigo[i] = Convert.ToInt32(leitura["codigo"]);
                vetorCpf[i] = Convert.ToInt64(leitura["cpf"]);
                vetorNome[i] = leitura["Nome"] + "";
                vetorTelefone[i] = leitura["telefone"] + "";
                vetorEndereco[i] = leitura["edereco"] + "";
                contarcodigo = contador;
                i++;
                contador++;

            }// fim do while

            // fecha a leitura do banco de dados

            leitura.Close();


        }//fim do medoto de preencher o vetor

        // metodo de consulta de todos banco de dados

        public string Consultar()
        {
            //preencher o ventor
            Preenchervetor();

            msg = "";

            for (i = 0; i < contador; i++)
            {

                msg += " codigo " + vetorCodigo[i] +
                       "  cpf " + vetorCpf[i] +
                       " nome " + vetorNome[i] +
                       " telefone " + vetorTelefone[i] +
                       "  endereco " + vetorEndereco[i] +
                       "\n\n ";

            }// fim do for

            return msg;

        }// fim do metodo de consulta
        public int ConsultarCodigo()
        {
            Preenchervetor();
            return vetorCodigo[contarcodigo];


        }//fim do consultar codigo

        public long ConsultarCpf(int cod)
        {
            Preenchervetor();
            for(i=0; i<contador; i++)
            { 
                if (vetorCodigo[i] == cod)
                {
                    return vetorCpf[i];
                }//fim do if
            }
            return -1;
        }//Fim consultar cpf

        public string ConsultarNome(int cod)
        {
            Preenchervetor();
            for(i=0; i<contador; i++)
            {
                if (vetorCodigo[i] == cod)
                {
                    return vetorNome[i];
                }

            }
            return "Nome Não encontrado";
        }// Fim  do consultar Nome
         public string ConsultarTelefone(int cod)
        {
            Preenchervetor();
            for(i=0; i<contador; i++)
            {
                if(vetorCodigo[i] == cod)
                {
                    return vetorTelefone[i];
                }

            }
            return " telefone Não encontrado";
        }//Fim do Consultar telefone

        public string ConsultarEndereco(int cod)
        {
            Preenchervetor();
            for (i = 0; i < contador; i++)
            {
                if (vetorCodigo[i] == cod)
                {
                    return vetorEndereco[i];
                }

            }
            return "Endereço Não encontrado";
        }// Fim  do consultar Nome

        public string Atualizar (int cod,string campo, string novoDado)
        {
            try
            {
                string query = "update pessoaTI14T set" + campo + " = '" + novoDado + "' where codigo = '" + cod + "'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    return "Atualizado";
                }
                
            }
            catch(Exception erro)
            {
                MessageBox.Show("" + erro);
            }
            return "Não Atualizado";

        }// fim do atualizar

        public string Atualizar(int cod, string campo, long novoDado)
        {
            try
            {
                string query = "update pessoaTI14T set" + campo + " = '" + novoDado + "' where codigo = '" + cod + "'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    return "Atualizado";
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
            return "Não Atualizado";
        }// fim do atualizar

        public void Deletar(int cod)
        {
            try
            { 
                string query = "update pessoaTI14T set = '" + cod + "'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    MessageBox.Show(resultado + " Deletado com sucesso ");
                }
                else
                {
                    MessageBox.Show(resultado + " Não Deletado  ");
                }

            }
            catch (Exception erro)
            {

                MessageBox.Show("" + erro);

            }
        }//fim do deletar


    }// fim da classe 


}//fim do projeto
