namespace CadastroPessoas_API.Models
{
    public class Cadastro
    {
        public Cadastro(int id, string name, string CPF, string data_nascimento ) { 
            this.Id = id;
            this.name = name;
            this.CPF = CPF;
            this.data_nascimento = data_nascimento;
        }

        public int Id { get; set;}
        public string name { get; set;}
        public string CPF { get; set;}
        public string data_nascimento { get; set;}
    }
}
