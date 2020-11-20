using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Informando que serão utilizados dados das classes data
using MySql.Data.MySqlClient;//Faz a conexão com a base de dados do MySQL
using System.Data;//Traz os dados do sistema
using System.Windows.Forms;
using System.Globalization;

namespace EstacionamentoTeams
{
    class ControleEstacionamentoDAO
    {
        public MySqlCommand sql;
        public MySqlConnection conexao;
        public MySqlDataReader read;
        public DataSet conexaoDataSet;
        public int i, j;
        public string codigo, mensagem, resultado;
        //Criar vetores
        public int[] codigoVet;
        public string[] nomeVet;
        public string[] dtHrEntVet;
        public string[] dtHrSaiVet;
        public double[] valorTotalVet;
        public int flag = 0;
        public ControleEstacionamentoDAO()
        {
            conexaoDataSet = new DataSet();//Abrindo as conexões para utilizar métodos de banco de dados
            conexao = new MySqlConnection("Server=localhost;DataBase=Estacionamento;Uid=root;Password=;");//Abrindo a conexão com o banco de dados
            try
            {
                conexao.Open();//Tentando entrar no banco de dados
                MessageBox.Show("Entrei!");
                flag = 1;
            }
            catch
            {
                MessageBox.Show("Erro!");
                conexao.Close();//Fechando a conexão que não foi acessada
            }//fim do try_catch
            i = 0;
            //InstanciarOsVetor
            codigoVet = new int[50];
            nomeVet = new string[50];
            dtHrEntVet = new string[50];
            dtHrSaiVet = new string[50];
            valorTotalVet = new double[50];
        }//fim do método construtor

        //Criar um método para inserir dados no meu banco de dados
        public void Inserir(string nomeCliente, string dtHrEntrada)
        {
            if(flag == 0)
            {
                conexao.Open();
            }  
            try
            {
                //Comandos para o banco de dados
                codigo = "'" + nomeCliente + "','" + dtHrEntrada + "'";
                resultado = "insert into controle(nomeCliente,dataHoraEntrada) values(" + codigo + ")";
                //Executar esse comando na base de dados
                sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();//Ele é o control + enter
                //Retorno da inserção
                MessageBox.Show(resultado + " Linha(s) Afetada(s)");
            }
            catch(Exception e)
            {
                MessageBox.Show("Erro!\n\n" + e);
            }
            flag = 0;
            conexao.Close();
        }//fim do inserir
        
        //Selecionar os dados da base de dados
        public void SelecionarTudo()
        {
            if (flag == 0)
            {
                conexao.Open();//Abrindo a conexao
                flag = 1;
            }
            string query = "SELECT * FROM controle";
            //Preencher temporariamente os vetores
            for(i = 0; i < 50; i++)
            {
                codigoVet[i] = 0;
                nomeVet[i] = "";
                dtHrEntVet[i] = "";
                dtHrSaiVet[i] = "";
                valorTotalVet[i] = 0;
            }//fim do preenchimento do vetor com dados vazios

            sql = new MySqlCommand(query, conexao);//Executar o comando na base de dados
            read = sql.ExecuteReader();//Executando a leitura dos dados armazenados no banco de dados

            i = 0;//Trabalhando com I zerado
            ConJ = 0;
            //Criar um while para percorrer por todo o banco de dados, coletar o dado encontrado
            //e armazenar temporariamente no vetor
            while (read.Read())
            {
                codigoVet[i] = Convert.ToInt32(read["id_Controle"]);
                nomeVet[i] = "" + read["nomeCliente"];
                dtHrEntVet[i] = "" + read["dataHoraEntrada"];
                dtHrSaiVet[i] = ""+ read["dataHoraSaida"];
                valorTotalVet[i] = Convert.ToDouble(read["valorTotal"]);
                i++;
                ConJ++;
            }//fim do while
            flag = 0;
            conexao.Close();//Fechando com o banco
        }//fim do método que coleta todos os dados do banco de dados

        public int ConJ
        {
            get { return j; }
            set { j = value; }
        }//Fim do método get/set i

        //Método que vai mostrar o conteúdo do banco de dados TOTAL em tela
        public void ConsultarTudo()
        {
            SelecionarTudo();//Chama o método para coleta dos dados no BD
            mensagem = "|   Código   |  Cliente  | Entrada | Saída | Valor Total |";
            for (i = 0; i < ConJ; i++)
            {
                //Acumulando na variável mensangem o conteúdo de cada vetor
                mensagem += "\n| " + codigoVet[i] + " | " + nomeVet[i] + " | " + dtHrEntVet[i] + " | " + dtHrSaiVet[i] + " | " + valorTotalVet[i] + " |";
            }//Fim do For
            MessageBox.Show(mensagem);
        }//fim do consultarTudo

        //Consultar os dados de acordo com a posição, ou melhor, o código que cada um
        public string ConsultarNomeBD(int idControle)
        {
            SelecionarTudo();//Coletar todos os dados do banco de dados e armazena no vetor
            for(i=0; i < ConJ; i++)
            {
                if(idControle == codigoVet[i])//Buscando o código digitado no vetor
                {
                    return nomeVet[i];//Monstrando o conteúdo da coluna nome
                }//fim do if
            }//fim do for
            return "Não encontrado";
        }//fim do ConsultarNomeBD

        public string ConsultarDataHoraEntrada(int idControle)
        {
            SelecionarTudo();//Pegar Dados do BD
            for(i=0; i < ConJ; i++)
            {
                if(idControle == codigoVet[i])
                {
                    return dtHrEntVet[i];//mostra em tela a data e hora armazenada
                }//fim do if
            }//fim do for
            return "Não Encontrado";
        }//fim do consultarDataHoraEntrada

        public string ConsultarDataHoraSaida(int idControle)
        {
            SelecionarTudo();//Pegar Dados do BD
            for (i = 0; i < ConJ; i++)
            {
                if (idControle == codigoVet[i])
                {
                    return dtHrSaiVet[i];//mostra em tela a data e hora armazenada
                }//fim do if
            }//fim do for
            return "Não Encontrado";
        }//fim do consultarDataHoraEntrada

        public double ConsultarValorTotal(int idControle)
        {
            SelecionarTudo();//Pegar Dados do BD
            for (i = 0; i < ConJ; i++)
            {
                if (idControle == codigoVet[i])
                {
                    return valorTotalVet[i];//mostra em tela a data e hora armazenada
                }//fim do if
            }//fim do for
            return 0;
        }//fim do consultarDataHoraEntrada

        //Criar o método para atualizar dados no meu banco de dados
        public void AtualizarDadosNome(string nome, int idControle)
        {
            try
            {
                if(flag == 0)
                {
                    conexao.Open();
                    flag = 1;
                }//Abrindo a conexão
                //Criar código para atualização do dado no banco de dados
                codigo = "Update controle set nomeCliente = '" + nome + "' where id_Controle = '" + idControle + "'";
                //Executar comando
                sql = new MySqlCommand(codigo, conexao);
                resultado = "" + sql.ExecuteNonQuery();//Control entre, tô executando o dado na minha base
            }
            catch(Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);
            }
            flag = 0;
            conexao.Close();//Fechando
        }//fim do atualizar nome

        //Criar o método para atualizar dados no meu banco de dados
        public void AtualizarValorTotal(double valorTotal, int idControle)
        {
            try
            {
                if (flag == 0)
                {
                    conexao.Open();
                    flag = 1;
                }//Abrindo a conexão
                //Criar código para atualização do dado no banco de dados
                codigo = "Update controle set valorTotal = '" + valorTotal.ToString().Replace(",",".") + "' where id_Controle = '" + idControle + "'";
                //Executar comando
                sql = new MySqlCommand(codigo, conexao);
                resultado = "" + sql.ExecuteNonQuery();//Control entre, tô executando o dado na minha base
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);
            }
            flag = 0;
            conexao.Close();//Fechando
        }//fim do atualizar nome

        public void AtualizarDataHoraEntrada(string dtHrEntrada, int idControle)
        {
            try
            {
                if (flag == 0)
                {
                    conexao.Open();
                    flag = 1;
                }//Abrindo a conexão
                //Criar código para atualização do dado no banco de dados
                codigo = "Update controle set dataHoraEntrada = '" + dtHrEntrada + "' where id_Controle = '" + idControle + "'";
                //Executar comando
                sql = new MySqlCommand(codigo, conexao);
                resultado = "" + sql.ExecuteNonQuery();//Control entre, tô executando o dado na minha base
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);
            }
            flag = 0;
            conexao.Close();//Fechando
        }//fim do atualizar

        public void AtualizarDataHoraSaida(string dtHrSaida, int idControle)
        {
            try
            {
                if (flag == 0)
                {
                    conexao.Open();
                    flag = 1;
                }//Abrindo a conexão
                //Criar código para atualização do dado no banco de dados
                codigo = "Update controle set dataHoraSaida = '" + dtHrSaida + "' where id_Controle = '" + idControle + "'";
                //Executar comando
                sql = new MySqlCommand(codigo, conexao);
                resultado = "" + sql.ExecuteNonQuery();//Control entre, tô executando o dado na minha base
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);
            }
            flag = 0;
            conexao.Close();//Fechando
        }//fim do atualizar

        //Método para apagar os conteúdos da base de dados
        public void Excluir(int idControle)
        {
            if(flag == 0)
            {
                conexao.Open();
                flag = 1;
            }
            try
            {
                //Apagando uma linha de dado do meu banco
                codigo = "delete from controle where id_Controle = '" + idControle + "'";
                //Executando no banco de dados
                sql = new MySqlCommand(codigo, conexao);
                resultado = "" + sql.ExecuteNonQuery();//Fim da execução e retorno do dado
                //Resposta para o comando
                MessageBox.Show("Dado apagado com sucesso!");
            }
            catch(Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);
            }
            flag = 0;
            conexao.Close();
        }//fim do excluir
    }//fim da classe
}//Fim do controle
