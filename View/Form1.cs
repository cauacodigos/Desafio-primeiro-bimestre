using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DESAFIO.Controller;
using DESAFIO.Model;

namespace DESAFIO
{
    public partial class Form1 : Form
    {
        List<Tarefa> tarefas = new List<Tarefa>();


        public Form1()
        {
            InitializeComponent();

    }

        TarefaController controller = new TarefaController();

        private void btnSalvar_Click(object sender, EventArgs e)
        {


            int id = int.Parse(txtId.Text);
            string nome = txtNome.Text;
            string prioridade = cbPrioridade.Text;
            string data = dtpVencimento.Text;
            string status = cbStatus.Text;

            string msg = controller.AdicionarTarefa(id, nome, prioridade, data, status);
            MessageBox.Show(msg);

            dgv1.DataSource = null;
            dgv1.DataSource = controller.GetTarefas();

            Tarefa t = new Tarefa(id, nome, prioridade, data, status);

           tarefas.Add(t);

            int prioridadeNum = 0;

            if (prioridade == "Alta")
            {
                prioridadeNum = 3;
            }
            else if (prioridade == "Média")
            {
                prioridadeNum = 2;
            }
            else if (prioridade == "Baixa")
            {
                prioridadeNum = 1;
            }

            cht_Valores.Series.Clear();
            cht_Valores.Titles.Clear();
            cht_Valores.Titles.Add("Grafico de Prioridades");
            cht_Valores.ChartAreas[0].AxisX.Title = "Tarefas";
            cht_Valores.ChartAreas[0].AxisY.Title = "Prioridade";
            Series serie = new Series("Valores")
            {
                ChartType = SeriesChartType.Column,
                BorderWidth = 2
            };

            for (int i = 0; i < tarefas.Count; i++) 
            {
                serie.Points.AddXY(tarefas[i].nome, prioridadeNum);
            }

            cht_Valores.Series.Add(serie);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentRow != null)
            {
              
                int tarefaId = Convert.ToInt32(dgv1.CurrentRow.Cells[0].Value);  
          
                controller.MarcarComoConcluida(tarefaId);

                dgv1.DataSource = null;
                dgv1.DataSource = controller.GetTarefas();

            }


        }
    }
}
 
 
