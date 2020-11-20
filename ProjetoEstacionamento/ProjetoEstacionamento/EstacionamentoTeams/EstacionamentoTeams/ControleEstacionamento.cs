using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstacionamentoTeams
{
    class ControleEstacionamento
    {
        private int codigo;
        private string nome;
        private string dtHrEntrada;
        private string dtHrSaida;
        private double valorTotal;
        public ControleEstacionamento()
        {
            ConsultarCodigo = 0;
            ConsultarNome = "";
            ConsultarDtHrEntrada = "";
            ConsultarDtHrSaida = "";
            ConsultarTotal = 0;
        }//fim do construtor

        //métodos modificadores
        public int ConsultarCodigo
        {
            get { return codigo;  }
            set { codigo = value; }
        }//fim do consultarCodigo
        public string ConsultarNome
        {
            get { return nome; }
            set { nome = value; }
        }//fim do consultarCodigo
        public string ConsultarDtHrEntrada
        {
            get { return dtHrEntrada; }
            set { dtHrEntrada = value; }
        }//fim do consultarCodigo
        public string ConsultarDtHrSaida
        {
            get { return dtHrSaida; }
            set { dtHrSaida = value; }
        }//fim do consultarCodigo
        public double ConsultarTotal
        {
            get { return valorTotal; }
            set { valorTotal = value; }
        }//fim do consultarCodigo

        //Realizar o calculo da hora no estacionamento
        public double CalcularPeriodo(string dtHrEntrada, string dtHrSaida)
        {
            try
            {
                //01/01/2001 01:01:01
                string hrEntrada = "" + dtHrEntrada.Substring(11, 5);//Coletando a parte Time de um dateTime
                string hrSaida = "" + dtHrSaida.Substring(11, 5);//Coletando a parte das horas
                                                                 //Coletando o pedaço da hora e o pedaço do minuto
                int horaEntrada = Convert.ToInt32(hrEntrada.Substring(0, 2)); //Retirando a parte corresponde a hora e transformando em inteiro
                int minutoEntrada = Convert.ToInt32(hrEntrada.Substring(3, 2)); //Retirando a parte corresponde a hora e transformando em inteiro
                int horaSaida = Convert.ToInt32(hrSaida.Substring(0, 2)); //Retirando a parte corresponde a hora e transformando em inteiro
                int minutoSaida = Convert.ToInt32(hrSaida.Substring(3, 2));//Retirando a parte corresponde a minutos e transformando em inteiro
                                                                           //Transformando para minutos
                int periodoHora = horaSaida - horaEntrada;
                int periodoMinuto = minutoSaida - minutoEntrada;
                //Transformando para minutos
                ConsultarTotal = ((periodoHora * 60) + periodoMinuto) * 0.17;
                
                //Mostrar o resultado em tela
            }
            catch
            {
                MessageBox.Show("Dado Inválido!");
            }//fim do catch
            return ConsultarTotal; //Retornar o consultarTotal
        }//fim do método de calculo 
    }//Fim da classe ControleEstacionamento
}//fim do Projeto Estacionamento Teams
