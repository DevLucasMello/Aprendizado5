using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace EstacionamentoTeams
{
    public partial class Form1 : Form
    {
        ControleEstacionamentoDAO bd;
        ControleEstacionamento model;
        private int codigo;
        private string nome;
        private string dtHrEntrada;
        private string dtHrSaida;
        private double valorTotal;
        public Form1()
        {
            InitializeComponent();
            model = new ControleEstacionamento();//Criando vínculo com a classe que tem o calculo do banco de dados
            bd = new ControleEstacionamentoDAO();//Criando vínculo com a classe que acessa o meu banco de dados
            maskedTextBox1.ReadOnly = true;//Campo de Leitura apenas
            maskedTextBox5.ReadOnly = true;//Campo valor total
            ConsultarCodigo = 0;
            ConsultarNome = "";
            ConsultarDtHrEntrada = "";
            ConsultarDtHrSaida = "";
            ConsultarValor = 0;
        }//fim do construtor
        //Métodos gets e sets
        public int ConsultarCodigo
        {
            get { return codigo; }
            set { this.codigo = value; }
        }//fim do consultarCodigo
         //Métodos gets e sets
        public string ConsultarNome
        {
            get { return nome; }
            set { this.nome = value; }
        }//fim do consultarCodigo
         //Métodos gets e sets
        public string ConsultarDtHrEntrada
        {
            get { return dtHrEntrada; }
            set { this.dtHrEntrada = value; }
        }//fim do consultarCodigo
         //Métodos gets e sets
        public string ConsultarDtHrSaida
        {
            get { return dtHrSaida; }
            set { this.dtHrSaida = value; }
        }//fim do consultarCodigo
         //Métodos gets e sets
        public double ConsultarValor
        {
            get { return valorTotal; }
            set { this.valorTotal = value; }
        }//fim do consultarCodigo
        private void Form1_Load(object sender, EventArgs e)
        {

        }//fim do formLoad

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultarNome        = maskedTextBox2.Text;//Coletando o nome digitado pelo usuário
            ConsultarDtHrEntrada = maskedTextBox3.Text; //Coletando data e hora de entrada
            //Converte a cultura
            bd.Inserir(ConsultarNome,ConsultarDtHrEntrada);//Cadastrar o usuário no Banco de Dados
            Limpar();
        }//Para cadastrar o meu usuário

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//Campo Nome Cliente

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//Nome desse DataHoraEntrada

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           
        }//Campo código

        private void button2_Click(object sender, EventArgs e)
        {
            maskedTextBox1.ReadOnly = false;
            
            
            ConsultaIndividual();//Retornar os conteúdos em cada campo
        }//Fim do consultar

        public void ConsultaIndividual()
        {
            try
            {
                maskedTextBox2.Text = bd.ConsultarNomeBD(Convert.ToInt32(maskedTextBox1.Text));//Preenchendo o campo nome
                maskedTextBox3.Text = "" + bd.ConsultarDataHoraEntrada(Convert.ToInt32(maskedTextBox1.Text));//Preenchendo o campo dtHrEntrada
                maskedTextBox4.Text = "" + bd.ConsultarDataHoraSaida(Convert.ToInt32(maskedTextBox1.Text));//Preenchendo o campo dtHrSaida
                maskedTextBox5.Text = "" + bd.ConsultarValorTotal(Convert.ToInt32(maskedTextBox1.Text));//Preenchendo o campo valor total
            }
            catch
            {
                MessageBox.Show("Informe o código!!!");
                maskedTextBox2.Text = "Informe o Código";
                maskedTextBox3.Text = "Informe o Código";
                maskedTextBox4.Text = "Informe o Código";
                maskedTextBox5.Text = "Informe o Código";
            }//Fim do catch
        }//Consulta Individual



        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//Campo para saida - Data e hora

        private void maskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }//Campo para valor Total

        public void Limpar()
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            maskedTextBox5.Text = "";
        }//fim do limpar
        private void button5_Click(object sender, EventArgs e)
        {
            bd.ConsultarTudo();//Fim do método que faz a consulta de todos os dados do vetor
        }//Botão Consultar Tudo

        private void button3_Click(object sender, EventArgs e)
        { 
            //Tornando todos os campos editáveis
            maskedTextBox1.ReadOnly = false;
            maskedTextBox2.ReadOnly = false;
            maskedTextBox3.ReadOnly = false;
            maskedTextBox4.ReadOnly = false;
            //Atualização da base de dados
            try
            {
                if ((maskedTextBox1.Text == "") && (maskedTextBox2.Text == "") && (maskedTextBox3.Text == "") && (maskedTextBox4.Text == ""))
                {
                    MessageBox.Show("Um ou mais campos estão vazios!");
                }
                else
                {
                    bd.AtualizarDadosNome(maskedTextBox2.Text, Convert.ToInt32(maskedTextBox1.Text));
                    bd.AtualizarDataHoraEntrada(maskedTextBox3.Text, Convert.ToInt32(maskedTextBox1.Text));
                    bd.AtualizarDataHoraSaida(maskedTextBox4.Text, Convert.ToInt32(maskedTextBox1.Text));
                    MessageBox.Show("Dado Atualizado com Sucesso!");
                    Limpar();
                }
                
            }
            catch
            {
                MessageBox.Show("Informe o código que deverá ser atualizado e o respectivo campo!");
            }//Atualizando o nome do usuário na base de dados
        }//Botão Atualizar

        private void button4_Click(object sender, EventArgs e)
        {
            bd.Excluir(Convert.ToInt32(maskedTextBox1.Text));//Excluindo um dade da base de dados
            Limpar();
        }//fim do botão apagar

        private void button6_Click(object sender, EventArgs e)
        {
            //Realizando o calculo do valor total e preenchendo o campo valorTotal
            maskedTextBox5.Text = "" + model.CalcularPeriodo(maskedTextBox3.Text, maskedTextBox4.Text);
            //Atualizando o valor a ser pago no banco de dados
            bd.AtualizarValorTotal(Convert.ToDouble(maskedTextBox5.Text),Convert.ToInt32(maskedTextBox1.Text));
        }//fim do calcular total
    }//fim da classe de formulário
}//fim do projeto
