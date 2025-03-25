using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAFIO.Model
{
    internal class Tarefa
    {
        
        public int id { get; set; }
        public string nome { get; set; }   

        public string prioridade { get; set; }

        public string data { get; set; }
        public string status { get; set; }

        public Tarefa()
        {

        }

        public Tarefa(int id, string nome, string prioridade, string data, string status)
        {
            this.id = id;
            this.nome = nome;
            this.prioridade = prioridade;
            this.data = data;
            this.status = status;
        }

        public void MarcarComoConcluida()
        {
            this.status = "Concluída";
        }

    }
}
