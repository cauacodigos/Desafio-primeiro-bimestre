using DESAFIO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DESAFIO.Controller
{


    internal class TarefaController
    {
        Tarefa tarefa = new Tarefa();

        public static List<Tarefa> tarefas = new List<Tarefa>();

        public string AdicionarTarefa(int id, string nome, string prioridade, string data, string status)
        {
            tarefa = new Tarefa(id, nome, prioridade, data, status);
            tarefas.Add(tarefa);

            return "Tarefa cadastrada com sucesso!";       
        }

        public List<Tarefa> GetTarefas()
        {
            return tarefas;
        }


        public void MarcarComoConcluida(int id)
        {
            for (int i = 0; i < tarefas.Count; i++)
            {
                if (tarefas[i].id == id)
                {
                    
                    tarefas[i].status = "Concluído";
                    break;

                }

                
            }
        }
    }
}
